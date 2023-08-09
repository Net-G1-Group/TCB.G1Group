using TCB.G1Group.DataService.Interface;
using TCB.G1Group.Domain.ViewModels;

namespace TCB.G1Group.TelegramBot.SessinManager;

public class SessionManager
{
    private readonly IUserDataService _userDataService;
    private List<Session> sessions = new List<Session>();

    public SessionManager(IUserDataService userDataService)
    {
        _userDataService = userDataService;
    }

    public async Task<Session> GetSessionByChatId(long chatId)
    {
        var lastSession = sessions.Find(x => x.TelegramChatId == chatId);
        if (lastSession is null)
        {
            var session = new Session()
            {
                Action = null,
                Controller = null,
                Id = 0,
                TelegramChatId = chatId
            };
            sessions.Add(session);
            return session;
        }

        return lastSession;
    }
}