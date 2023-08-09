using System.ComponentModel;
using TCB.G1Group.Domain.Models;

namespace TCB.G1Group.Domain.Modles;

public class User : ModelBase
{
    [Description("telegram_client_id")] public long TelegramClientId { get; set; }
    [Description("password")] public string Password { get; set; }
    [Description("phone_number")] public string? PhoneNumber { get; set; }
}