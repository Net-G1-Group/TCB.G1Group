using TCB.G1Group.TelegramBot.Managers;

namespace TCB.G1Group.TelegramBot.Controllers;

public class HomeController:ControllerBase
{
    public HomeController(ControllerManager controllerManager) : base(controllerManager)
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
}