using TCB.G1Group.TelegramBot.Managers;
using Telegram.Bot.Polling;

namespace TCB.G1Group.TelegramBot.Controllers;

public abstract class ControllerBase
{
    protected readonly ControllerManager _controllerManager;

    public ControllerBase(ControllerManager controllerManager)
    {
        _controllerManager = controllerManager;
    }


    public virtual async Task Handle(Context context)
    {
        await UpdateHandler(context);
        await HandleAction(context);
    }

    protected abstract Task UpdateHandler(Context context);

    protected abstract Task HandleAction(Context context);

}