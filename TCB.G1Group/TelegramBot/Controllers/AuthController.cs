using TCB.G1Group.Domain.ViewModels;
using TCB.G1Group.TelegramBot.Managers;

namespace TCB.G1Group.TelegramBot.Controllers;

public class AuthController:ControllerBase
{
      private readonly AuthService _authService;

    public AuthController(AuthService authService, ControllerManager controllerManager) : base(controllerManager)
    {
        _authService = authService;
    }

    public async Task LoginUserStart(Context context)
    {
        await context.SendTextMessage("Please Enter Login to Sign In");
        context.Session.Action = nameof(LoginUserLogin);
    }

    private async Task LoginUserLogin(Context context)
    {
        context.Session.AuthView.PhoneNumber = context.Update.Message.Text;

        await context.SendTextMessage( "Enter your password: ");
        context.Session.Action = nameof(LoginUserPassword);
    }

    private async Task LoginUserPassword(Context context)
    {
        var password = context.Update.Message.Text;
        var client = await _authService.Login(new AuthView()
            {
                PhoneNumber = context.Session.AuthView.PhoneNumber,
                Password = context.Update.Message.Text,
                ChatId = context.Update.Message.Chat.Id
            });
        if (client is not null)
            await context.SendTextMessage($"Client id: {client.Id}\n Nickname: {client.NickName}");
        else {
            await context.SendTextMessage( "User not found!");
        }
        context.Session.Controller = null;
        context.Session.Action = null;

        await context.Forward(this._controllerManager);
    }

    public async Task RegistrationStart(Context context)
    {
        
        await context.SendTextMessage("Enter your phone number as \"+998900000000\"");
        context.Session.Action = nameof(RegistrationPhoneNumber);
    }

    public async Task RegistrationPhoneNumber(Context context)
    {
        context.Session.AuthView.PhoneNumber = context.Update.Message.Text;
        await context.SendTextMessage("Please Enter your password");
        context.Session.Action = nameof(RegistrationPassword);
    }

    public async Task RegistrationPassword(Context context)
    {
        context.Session.AuthView.Password = context.Update.Message.Text;
        context.Session.AuthView.ChatId = Convert.ToInt64(context.Update.Message.Text);

        await _authService.RegisterUser(context.Session.AuthView);
        
        await context.SendTextMessage("You Succesfully registired");

        context.Session.Controller = null;
        context.Session.Action = null;

        await context.Forward(this._controllerManager);
    }


    protected override Task UpdateHandler(Context context)
    {
        return Task.CompletedTask;
    }

    protected override async Task HandleAction(Context context)
    {
        switch (context.Session.Action)
        {
            case nameof(RegistrationStart):
            {
                await RegistrationStart(context);
                break;
            }
            case nameof(RegistrationPhoneNumber):
            {
                await RegistrationPhoneNumber(context);

                break;
            }
            case nameof(RegistrationPassword):
            {
                await RegistrationPassword(context);


                break;
            }
            case nameof(LoginUserStart):
            {
                await LoginUserStart(context);
                break;
            }
            case nameof(LoginUserLogin):
            {
                await LoginUserLogin(context);
                break;
            }
            case nameof(LoginUserPassword):
            {
                await LoginUserPassword(context);
                break;
            }
        }

        return;
    }
}