using Npgsql;
using TCB.G1Group.Domain.Models;

namespace TCB.G1Group.DataService.Interface;

public interface IClientDataService
{
    public Task<Client> FindByNickName(string nickName);
    public Task<Client> FindByUserId(long user_id);
    public Client ReaderDataModel(NpgsqlDataReader reader);
}