using System.ComponentModel;

namespace TCB.G1Group.Domain.Modles;

public class User
{
    [Description("client_id")]
    public long TelegramClientId { get; set; }
    [Description("password")]
    public string Password { get; set; }
    [Description("phone_number")]
    public string PhoneNumber { get; set; }
}