using TCB.G1Group.Confugration;
using TCB.G1Group.DataService;
using TCB.G1Group.Domain.Enums;
using TCB.G1Group.Domain.Models;
using TCB.G1Group.TelegramBot;

//
// BoardModel boardModel = new BoardModel
// {
//     Id = 0,
//     NickName = "Elnur1211",
//     OwnerId = 0,
//     BoardStatus = BoardStatus.Processing,
//     MessageList = new List<Message>()
// };
// MessageDataService message = new TCB.G1Group.DataService.MessageDataService(Settings.com);
// BoardDataService v = new BoardDataService(Settings.com,message);
// var a = v.Create(boardModel);
// var s = v.Create(boardModel);
// var b = v.Update(1,boardModel);  
// //
// var kk = v.BoardMessages(1);
// var qq = v.BoardMessageState(1);
// var k = v.Delete(1);
// Console.WriteLine();

TelegramBot  bot=new TelegramBot();
bot.Start();
Console.ReadKey();