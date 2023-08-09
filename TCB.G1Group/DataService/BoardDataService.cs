
using TCB.G1Group.DataService.Interface;
using TCB.G1Group.Domain.Models;

namespace TCB.G1Group.DataService;

public class BoardDataService:DataProvider,IBoardDataService
{
    public async Task<BoardModel> Create(BoardModel data)
    {
        throw new NotImplementedException();
    }

    public async Task<BoardModel> Update(BoardModel data)
    {
        throw new NotImplementedException();
    }

    public async Task<BoardModel> Delete(BoardModel data)
    {
        throw new NotImplementedException();
    }

    public async Task<List<BoardModel>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<BoardModel> FindById(long Id)
    {
        throw new NotImplementedException();
    }

    public async Task<BoardModel> FindByNickName(string nickName)
    {
        throw new NotImplementedException();
    }

    public BoardDataService(string connectionString) : base(connectionString)
    {
    }
}