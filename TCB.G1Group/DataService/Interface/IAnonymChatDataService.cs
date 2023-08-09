using TCB.G1Group.Domain.Models;

namespace TCB.G1Group.DataService.Interface;

public interface IAnonymChatDataService:IDataService<AnonymChat>
{
    public Task<AnonymChat> FindByFromId(long id);
    public Task<AnonymChat> FindByToId(long id);

}