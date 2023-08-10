namespace TCB.G1Group.TelegramBot.Controllers;

public interface IClientDashBoardController
{
    Task StartDashBoard(Context context);
    Task CreateBoard(Context context);
    Task CreateAnonymChat(Context context);
    Task Settings(Context context);
}