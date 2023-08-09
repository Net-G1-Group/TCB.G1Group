using TCB.G1Group.Domain.Models;

namespace TCB.G1Group.DataService.Interface;

public interface IMessageDataService : IDataService<Message>
{
    Task<List<Message>> GetMessagesByBoardId(long Id);
    Task<List<Message>> GetMessagesByAnonymChatId(long Id);
    Task<List<Message>> GetMessagesByBoardIdState(long Id);
    Task<List<Message>> GetMessagesByAnonymChatIdState(long Id);
    
}