using TCB.G1Group.DataService;
using TCB.G1Group.Domain.Models;
using TCB.G1Group.InterfaceService;

namespace TCB.G1Group;

public class BoardService:IBoardService
{
    private BoardDataService boardDataService;
    public async Task<BoardModel> Create(BoardModel data)
    {
        return await boardDataService.Create(data);
    }

    public async Task<BoardModel> Update(long Id, BoardModel data)
    {
       return await boardDataService.Update(Id, data);
    }

    public async Task<BoardModel> Delete(long boardId)
    {
        return await boardDataService.Delete(boardId);
    }

    public async Task<List<BoardModel>> GetAll()
    {
        return await boardDataService.GetAll();
    }

    public async Task<BoardModel> FindById(long Id)
    {
        return await boardDataService.FindById(Id);
    }

    public async Task<List<Message>> GetBoardMessages(long boardId)
    {
        return await boardDataService._messageDataService.GetMessagesByBoardIdState(boardId);
    }

    public async Task<BoardModel> CreateNewBoard(long ownerId, string nickName)
    {
        BoardModel boardModel = new BoardModel()
        {
            OwnerId = ownerId,
            NickName = nickName
        };
        await boardDataService.Create(boardModel);
        throw new Exception("Error CreateNewBoard@ ");
    }

    public async Task<Message> ChangeBoardMessageStatus(long messageId, Message message)
    {
        return await boardDataService._messageDataService.Update(messageId, message);
    }

    public async Task<BoardModel> StopBoard(long boardId)
    {
        return boardDataService.Stop(boardId).Result;
    }

    public async Task<List<BoardModel>> GetBoardFromClientId(long clientId)
    {
        var list = GetAll();
        return list.Result.Where(x => x.OwnerId == clientId).ToList();
    }

    public async Task<BoardModel> GetBoard(long boardId)
    {
        return boardDataService.FindById(boardId).Result;
    }

    public async Task<BoardModel> FindBoardByNickName(string nickName)
    {
        return await boardDataService.FindByNickName(nickName);
    }
}