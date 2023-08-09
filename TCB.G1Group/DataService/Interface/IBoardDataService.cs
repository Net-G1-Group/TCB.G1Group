using TCB.G1Group.Domain.Models;
namespace TCB.G1Group.DataService.Interface;

public interface IBoardDataService:IDataService<BoardModel>
{
    public Task<BoardModel> FindByNickName(string nickName);
}