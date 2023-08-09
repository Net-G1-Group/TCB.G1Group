using TCB.G1Group.TelegramBot.Managers;

namespace TCB.G1Group.TelegramBot.Controllers;

public class LoginControler:ControllerBase
{
    private readonly AuthService _authService;

    public LoginControler(ControllerManager controllerManager,AuthService authService) : base(controllerManager)
    {
        _authService = authService;
    }

    protected override async Task UpdateHandler(Context context)
    {
        
    }

    protected override async Task HandleAction(Context context)
    {
        switch (context.Session.Action)
        {
            case nameof(LoginStepFirst):
            {
                await LoginStepFirst(context);
                break;
            }
            case nameof(LoginStepLast):
            {
                await LoginStepLast(context);
                break;
            }
            default:
            {
                await LoginStepStart(context);
                break;
            }
        }
    }

    public async Task LoginStepStart(Context context)
    {
        await Extension.SendTextMessage(context, "Enter your Phone Number ");
        context.Session.Action = nameof(LoginStepFirst);
    }

    private async Task LoginStepFirst(Context context)
    {
        context.Session.AuthView.PhoneNumber = context.Update.Message!.Contact!.PhoneNumber;

        if (string.IsNullOrEmpty(context.Update.Message.Contact.PhoneNumber))
        {
            await Extension.SendTextMessage(context, "Enter your Phone Number ");
            return;
        }

        await Extension.SendTextMessage(context, "Enter Your Password");
        context.Session.Action=nameof(LoginStepLast);
    }

    private async Task LoginStepLast(Context context)
    {
        context.Session.AuthView.Password = context.Update!.Message!.Text;
        if (string.IsNullOrEmpty(context.Update.Message.Text))
        {
            await Extension.SendTextMessage(context, "Enter Your Password");
            return;
        }

        context.Session.Controller = null;
        context.Session.Action = null;
        await Extension.SendTextMessage(context, "Successful");
        await Extension.Forward(context, _controllerManager);
    }
    
}