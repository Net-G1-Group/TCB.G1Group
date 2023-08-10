using System.Threading.Channels;
using TCB.G1Group.Confugration;
using TCB.G1Group.DataService;
using TCB.G1Group.Domain.Enums;
using TCB.G1Group.Domain.Models;
using TCB.G1Group.Domain.Modles;
using TCB.G1Group.TelegramBot;


/*TelegramBot  bot=new TelegramBot();
bot.Start();
Console.ReadKey();*/
UserDataService userdata = new UserDataService(Settings.dbConnectionString);
User user = new User
{
    TelegramClientId = 0123,
    Password = "password",
    PhoneNumber = "s3145354"
};
ClientDataService clientData = new ClientDataService(Settings.dbConnectionString);
Client client = new Client
{
    UserId = 12,
    NickName = "nick",
    IsPremium = false,
    Status = ClientStatus.Enabled
};

await userdata.Create(user);
await clientData.Create(client);
Console.WriteLine();



