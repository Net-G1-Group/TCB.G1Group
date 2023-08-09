using TCB.G1Group.Domain.Enums;

namespace TCB.G1Group.Domain.Modles;

public class Message
{
    public long FromId { get; set; }
    public object _Message { get; set; }
    public long ChatId { get; set; }
    public MessageType Type { get; set; }
    public long BoardId { get; set; }
    
    
    
}