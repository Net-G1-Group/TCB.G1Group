using TCB.G1Group.TelegramBot.Managers;
using Telegram.Bot.Types;

namespace TCB.G1Group.TelegramBot.Controllers;

public class BoardController:ControllerBase
{
    public BoardController(ControllerManager controllerManager) : base(controllerManager)
    {
    }

    protected override async Task UpdateHandler(Context context)
    {
        throw new NotImplementedException();
    }

    protected override async Task HandleAction(Context context)
    {
        throw new NotImplementedException();
    }

    public async Task Start(Context context)
    {
       await context.SendTextMessage("Create Board /CreateBoard\nList All Board /ListAllBoard");
    }

    public async Task Create(Context context)
    {
        if (string.IsNullOrEmpty(context.Update.Message?.Text))
        {
            await context.SendTextMessage("Place Enter Nick Name");
            return;
        }
        
        //Board board=_boardService.FindByNickName(context.Update.Message.text);
        // if(board is null)
        // {
        //      Extension.SendTextMessage(context, "this nick name is busy");
        // }
        //context.Session.BoardView.Id=board.Id
        context.Session.Action = null;
        await context.SendTextMessage( "successful");
    }

    public async Task PrintBoard(Context context)
    {
        //foreach(var board in _boardService.GetAll())
        //  Extension.SendTextMessage(context, board.NickName);

        await context.SendTextMessage( "write on the board\n/yes or /no");
        context.Session.Action = nameof(BoardStepFirst);
    }

    public async Task BoardStepFirst(Context context)
    {
        if (string.IsNullOrEmpty(context.Update.Message?.Text))
        {
            await context.SendTextMessage( "write on the board\n/yes or /no");
            return;
        }

        if (context.Update.Message.Text == "/no")
        {
            await Start(context);
        }

        if (context.Update.Message.Text != "/yes")
        {
            await context.SendTextMessage( "place write on the board\n/yes or /no");
            return;
        }

        await context.SendTextMessage("you can write thank you");
        context.Session.Action = nameof(WriteToBoard);
        
    }

    public async Task WriteToBoard(Context context)
    {
        if (string.IsNullOrEmpty(context.Update.Message?.Text))
        {
            await context.SendTextMessage( "you can write thank you");
            return;   
        }
        
        context.Session.Action = nameof(Start);

    }
    
    
    
}