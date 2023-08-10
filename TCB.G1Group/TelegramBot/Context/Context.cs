using TCB.G1Group.Domain.ViewModels;
using Telegram.Bot.Types;

namespace TCB.G1Group.TelegramBot;

public class Context:ContextBase
{
    public Session Session { get; set; }
 
}