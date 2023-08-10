using TCB.G1Group.Domain.Models;

namespace TCB.G1Group.InterfaceService;

public interface IBoardService:IBaseService<BoardModel>
{
    public Task<List<Message>> GetBoardMessages(long boardId);
    public Task<BoardModel> CreateNewBoard(long ownerId, string nickName);
    public Task<Message> ChangeBoardMessageStatus(long messageId, Message message);
    public Task<BoardModel> StopBoard(long boardId);
    public Task<List<BoardModel>> GetBoardFromClientId(long clientId);
    public Task<BoardModel> GetBoard(long boardId);
    public Task<BoardModel> FindBoardByNickName(string nickName);
}