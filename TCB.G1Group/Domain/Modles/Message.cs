using System.ComponentModel;
using TCB.G1Group.Domain.Enums;

namespace TCB.G1Group.Domain.Modles;

public class Message
{
    [Description("from_id")]
    public long FromId { get; set; }
    [Description("message")]
    public object _Message { get; set; }
    [Description("chat_id")]
    public long ChatId { get; set; }
    [Description("type")]
    public MessageType Type { get; set; }
    [Description("board_id")]
    public long BoardId { get; set; }
}
