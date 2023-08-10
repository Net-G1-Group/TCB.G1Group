using TCB.G1Group.TelegramBot.Managers;
using Telegram.Bot.Types.ReplyMarkups;

namespace TCB.G1Group.TelegramBot.Controllers;

public class ClientDashBoardController : ControllerBase, IClientDashBoardController
{
    private readonly BoardController _boardController;

    public ClientDashBoardController(ControllerManager controllerManager, BoardController boardController) : base(
        controllerManager)
    {
        _boardController = boardController;
    }

    public async Task StartDashBoard(Context context)
    {
        await context.SendTextMessage("Quyidagilardan birini tanlang : " +
                                                 "\n /CreateBoard\t/CreadAnonymChat\t/Settings");
        context.Session.Action = nameof(HandleAction);
    }

    public async Task CreateBoard(Context context)
    {
        await _boardController.Create(context);
        await context.SendTextMessage( "Board is created successfully");
    }

    public async Task CreateAnonymChat(Context context)
    {
        throw new NotImplementedException();
    }

    public async Task Settings(Context context)
    {
        throw new NotImplementedException();
    }

    protected override async Task UpdateHandler(Context context)
    {
        throw new NotImplementedException();
    }

    protected override async Task HandleAction(Context context)
    {
        switch (context.Session.Action)
        {
            case nameof(CreateBoard):
                await CreateBoard(context);
                break;
            case nameof(CreateAnonymChat):
                await CreateAnonymChat(context);
                break;
            case nameof(Settings):
                await Settings(context);
                break;
        }
    }
}