using TCB.G1Group.TelegramBot.Controllers;
using TCB.G1Group.TelegramBot.Managers;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace TCB.G1Group.TelegramBot;

public static class Extension
{
    public static async Task Forward(this Context context, ControllerManager controllerManager)
    {
        ControllerBase baseController = await controllerManager.GetControllerBySessionData(context.Session );
        await baseController.Handle(context);
    }
    
    public static async Task<Message> SendTextMessage(this Context context, string text,IReplyMarkup replyMarkup = null )
    {
        return await TelegramBot._client.SendTextMessageAsync(context.Update.Message!.Chat.Id, text,replyMarkup : replyMarkup);
    }
}