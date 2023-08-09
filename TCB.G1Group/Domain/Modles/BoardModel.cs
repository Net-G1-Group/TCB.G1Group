using System.ComponentModel;
using TCB.G1Group.Domain.Enums;

namespace TCB.G1Group.Domain.Modles;

public class BoardModel:ModelBase
{
    [Description("board_id")]
    public ModelBase BoardId { get; set; }
    
    [Description("nickname")]
    public string NickName { get; set; }
    
    [Description("owner_id")]
    public ModelBase OwnerId { get; set; }
    
    [Description("board_status")]
    public BoardStatus BoardStatus { get; set; }
}