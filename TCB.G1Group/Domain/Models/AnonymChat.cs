using System.ComponentModel;
using TCB.G1Group.Domain.Enums;

namespace TCB.G1Group.Domain.Models;

public class AnonymChat : ModelBase
{
    [Description("create_date")] public DateTime CreatedDate { get; set; }
    [Description("from_id")] public long FromId { get; set; }
    [Description("to_id")] public long ToId { get; set; }
    [Description("state")] public ChatState State { get; set; }
}