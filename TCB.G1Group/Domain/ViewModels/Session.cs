using TCB.G1Group.Domain.Modles;

namespace TCB.G1Group.Domain.ViewModels;

public class Session
{
    public long Id { get; set; }
    public long TelegramChatId { get; set; }
    public long? ClientId { get; set; }
    public string? Controller { get; set; }
    public string? Action { get; set; }
    public User? user { get; set; }
    public BoardView BoardView { get; set; }
    public AuthView AuthView { get; set; }
}