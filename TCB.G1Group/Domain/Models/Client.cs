using System.ComponentModel;
using TCB.G1Group.Domain.Enums;

namespace TCB.G1Group.Domain.Models;

public class Client : ModelBase
{
    [Description("user_id")] public long UserId { get; set; }
    [Description("nick_name")] public string? NickName { get; set; }
    [Description("is_premium")] public bool IsPremium { get; set; }
    [Description("status")] public ClientStatus Status { get; set; }
}