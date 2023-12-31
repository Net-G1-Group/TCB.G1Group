using TCB.G1Group.TelegramBot.Managers;
using Telegram.Bot.Types.Enums;

namespace TCB.G1Group.TelegramBot.Controllers;

public class HomeController:ControllerBase
{
    public HomeController(ControllerManager controllerManager) : base(controllerManager)
    {
    }

    protected override async Task UpdateHandler(Context context)
    {
        var update = context.Update;
        if (update.Type == UpdateType.Message && update.Message!.Type == MessageType.Text)
        {
            var text = update.Message.Text;
            if (text is not null)
                switch (text)
                {
                    case "/start":
                        await this.Start(context);
                        break;
                    case "/login":
                        await this.Login(context);
                        break;
                    case "/register":
                        await this.Register(context);
                        break;
                    case nameof(Register):
                        await this.Register(context);
                        break;
                }
        }
    }

    public async Task Start(Context context)
    {
        await context.SendTextMessage("Welcome!");
        context.Session.Action = nameof(HandleAction);
    }
    
    public async Task Login(Context context)
    {
        context.Session.Controller = nameof(AuthController);
        context.Session.Action = nameof(AuthController.LoginUserStart);
    
        await context.Forward(_controllerManager);
    }
    
    public async Task Register(Context context)
    {
        context.Session.Controller = nameof(AuthController);
        context.Session.Action = nameof(AuthController.RegistrationStart);
    
        await context.Forward(_controllerManager);
    }

    
    
    
    protected override async Task HandleAction(Context context)
    {
        switch (context.Session.Action)
        {
            case nameof(Register):
                Console.WriteLine(nameof(Register));
                await Register(context);
                break;
            case nameof(Login):
                await Login(context);
                break;
        }
    }
}