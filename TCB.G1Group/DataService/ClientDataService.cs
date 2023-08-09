using System.Data;
using Npgsql;
using TCB.G1Group.DataService.Interface;
using TCB.G1Group.Domain.Enums;
using TCB.G1Group.Domain.Models;

namespace TCB.G1Group.DataService;

public class ClientDataService : DataProvider, IDataService<Client>  , IClientDataService
{

    public ClientDataService(string connectionString) 
        : base(connectionString)
    {
    }
    
    public async Task<Client> Create(Client data)
    {
        var result = await this.ExecuteNonResult(ClientQuery.SelectQuyer, new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p0", data.Id),
            new NpgsqlParameter("@p1", data.UserId),
            new NpgsqlParameter("@p2", data.NickName),
            new NpgsqlParameter("@p3", data.Status),
            new NpgsqlParameter("@p4", data.IsPremium)
        });

        return await FindById(data.Id);
    }

    public async Task<Client> Update(Client data)
    {
        var result = await this.ExecuteNonResult(ClientQuery.UpdateQuery, new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p0", data.Id),
            new NpgsqlParameter("@p1", data.UserId),
            new NpgsqlParameter("@p2", data.NickName),
            new NpgsqlParameter("@p3", data.Status),
            new NpgsqlParameter("@p4", data.IsPremium)
        });

        return await FindById(data.Id);
    }

    public async Task<Client> Delete(Client data)
    {
        Client client = await this.FindById(data.Id);
        var result = await this.ExecuteWithResult(ClientQuery.DeleteQuery, new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p0", data.Id)
        });

        return client;
    }

    public async Task<List<Client>> GetAll()
    {
        var result = await this.ExecuteWithResult(ClientQuery.SelectQuyer, null);

        List<Client> clients = new List<Client>();

        while (result.Read())
        {
            clients.Add(ReaderDataModel(result));
        }

        return clients;
    }

    public async Task<Client> FindById(long Id)
    {
        var result = await this.ExecuteWithResult(ClientQuery.SelectByIdQuyer, new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p0", Id)
        });

        List<Client> clients = new List<Client>();

        while (result.Read())
        {
            clients.Add(ReaderDataModel(result));
        }

        return clients.FirstOrDefault();
    }

    public async Task<Client> FindByNickName(string nickName)
    {
        var result = await this.ExecuteWithResult(ClientQuery.SelectByNickNameQuery, new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p2", nickName)
        });

        List<Client> clients = new List<Client>();
        while (result.Read())
        {
            clients.Add(ReaderDataModel(result));
        }

        return clients.FirstOrDefault();
    }

    public async Task<Client> FindByUserId(long user_id)
    {
        var result = await this.ExecuteWithResult(ClientQuery.SelectByUserIdQuery, new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p1", user_id)
        });
        List<Client> clients = new List<Client>();
        while (result.Read())
        {
            clients.Add(ReaderDataModel(result));
        }

        return clients.FirstOrDefault();
    }

    public Client ReaderDataModel(NpgsqlDataReader reader)
    {
        Client client = new Client()
        {
            Id = reader.GetInt32(0),
            UserId = reader.GetInt32(1),
            NickName = reader.GetString(2),
            Status = (ClientStatus)reader.GetInt32(3),
            IsPremium = reader.GetBoolean(4)
        };
        return client;
    }

}