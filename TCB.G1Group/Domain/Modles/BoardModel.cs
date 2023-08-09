using System.ComponentModel;
using TCB.G1Group.Domain.Enums;

namespace TCB.G1Group.Domain.Modles;

public class BoardModel:ModelBase
{
    [Description("nickname")]
    public string NickName { get; set; }
    
    [Description("owner_id")]
    public long OwnerId { get; set; }
    
    [Description("board_status")]
    public BoardStatus BoardStatus { get; set; }

    public List<Message> MessageList { get; set; }

}