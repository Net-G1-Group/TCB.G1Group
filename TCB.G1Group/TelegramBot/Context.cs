using TCB.G1Group.Domain.ViewModels;
using Telegram.Bot.Types;

namespace TCB.G1Group.TelegramBot;

public class Context
{
    public Session Session { get; set; }
    public Update  Update { get; set; }
}