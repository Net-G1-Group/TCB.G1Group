using TCB.G1Group.Domain.Modles;
using TCB.G1Group.TelegramBot.Managers;

namespace TCB.G1Group.TelegramBot.Controllers;

public class RegisterController:ControllerBase
{
    private readonly AuthService _authService;

    public RegisterController(ControllerManager controllerManager,AuthService authService) : base(controllerManager)
    {
        _authService = authService;
    }

    protected override async Task UpdateHandler(Context context)
    {
        throw new NotImplementedException();
    }

    protected override async Task HandleAction(Context context)
    {
        switch (context.Session.Action)
        {
            case nameof(RegisterStepFirst):
            {
               await RegisterStepFirst(context);
               break;
            }
            case nameof(RegisterStepLast):
            {
                await RegisterStepLast(context);
                break;
            }
            default:
            {
                await ResisterStepStart(context);
                break;
            }
        }
    }


    public async Task ResisterStepStart(Context context)
    {
        await context.SendTextMessage(context, "Enter Your Phone Number");
        context.Session.Action = nameof(RegisterStepFirst);
    }

    private async Task RegisterStepFirst(Context context)
    {
        if (string.IsNullOrEmpty(context.Update.Message?.Text))
        {
            await context.SendTextMessage(context, "Enter Your Phone Number");
            return;
        }
        context.Session.AuthView.PhoneNumber = context.Update.Message.Text;
        context.Session.Action = nameof(RegisterStepLast);
        await context.SendTextMessage(context, "Enter Your Password");

    }

    private async Task RegisterStepLast(Context context)
    {
        if (string.IsNullOrEmpty(context.Update.Message?.Text))
        {
            await context.SendTextMessage(context, "Enter Your Password");
            return;
        }

        await _authService.RegisterUser(new User()
        {
            Password = context.Update.Message.Text,
            PhoneNumber = context.Session.AuthView.PhoneNumber
        });

        context.Session.Action = null;
        context.Session.Controller = null;
        await context.Forward(context,_controllerManager);
    }
    
}