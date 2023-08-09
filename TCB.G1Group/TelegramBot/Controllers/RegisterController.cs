using TCB.G1Group.TelegramBot.Managers;

namespace TCB.G1Group.TelegramBot.Controllers;

public class RegisterController:ControllerBase
{
    public RegisterController(ControllerManager controllerManager) : base(controllerManager)
    {
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
        await Extension.SendTextMessage(context, "Enter Your Phone Number");
        context.Session.Action = nameof(RegisterStepFirst);
    }

    public async Task RegisterStepFirst(Context context)
    {
        if (string.IsNullOrEmpty(context.Update.Message?.Text))
        {
            await Extension.SendTextMessage(context, "Enter Your Phone Number");
            return;
        }
        context.Session.AuthView.PhoneNumber = context.Update.Message.Text;
        context.Session.Action = nameof(RegisterStepLast);
        await Extension.SendTextMessage(context, "Enter Your Password");

    }

    public async Task RegisterStepLast(Context context)
    {
        if (string.IsNullOrEmpty(context.Update.Message?.Text))
        {
            await Extension.SendTextMessage(context, "Enter Your Password");
            return;
        }

        context.Session.Action = null;
        context.Session.Controller = null;
        await Extension.Forward(context,_controllerManager);
    }
    
}