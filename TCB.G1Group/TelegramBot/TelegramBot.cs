using TCB.G1Group.Confugration;
using TCB.G1Group.DataService;
using TCB.G1Group.TelegramBot.Managers;
using TCB.G1Group.TelegramBot.SessinManager;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace TCB.G1Group.TelegramBot;

public class TelegramBot
{
   

    public static TelegramBotClient _client { get; set; }

    private SessionManager SessionManager { get; set; }
    private ControllerManager controllerManager { get; set; }
    private List<Func<Context, CancellationToken, Task>> updateHandlers { get; set; }
    
  
    public TelegramBot()
    {
        _client = new TelegramBotClient(Settings.TelegramBotToken);

            controllerManager = new ControllerManager();
        SessionManager = new SessionManager(controllerManager._userDataService);
        
        updateHandlers = new List<Func<Context, CancellationToken, Task>>();
    }

    public async Task Start()
    {
        //Session handler
        this.updateHandlers.Add(async (context, token) =>
        {
            if (context.Update?.Message?.Chat.Id is null)
                throw new Exception("Chat id not found to find session");
            
            var session = await SessionManager.GetSessionByChatId(context.Update.Message.Chat.Id);
            context.Session = session;
        });
        
        //Log handler
        this.updateHandlers.Add(async (context, token) =>
        {
            Console.WriteLine("Log -> {0} | {1} | {2}", DateTime.Now, context.Session.TelegramChatId, context.Update.Message?.Text ?? context.Update.Message?.Caption);
        });
        
        
        this.updateHandlers.Insert(this.updateHandlers.Count, async (context, token) =>
        {
            await context.Forward(this.controllerManager);
        });
        
        await StartReceiver();
    }

    private async Task StartReceiver()
    {
        var cancellationToken = new CancellationToken();
        var options = new ReceiverOptions();
        _client.StartReceiving(OnUpdate, ErrorMessage, options, cancellationToken);

        Console.WriteLine("{0} | Bot is starting...", DateTime.Now);
        Console.ReadKey();
    }

    private async Task OnUpdate(ITelegramBotClient bot, Update update, CancellationToken token)
    {
        Context context = new Context()
        {
            Update = update
        };
        
        try
        {
            foreach (var updateHandler in this.updateHandlers)
                await updateHandler(context, token);
        }
        catch (Exception e)
        {
            Console.WriteLine("Handler Error: " + e.Message);
        }
        
    }


    private async Task ErrorMessage(ITelegramBotClient bot, Exception exception, CancellationToken token)
    {
        // Handle any errors that occur during message processing here.
    }
 
}