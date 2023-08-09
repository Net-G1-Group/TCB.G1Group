using Npgsql;
using TCB.G1Group.DataService.Interface;
using TCB.G1Group.Domain.Modles;

namespace TCB.G1Group.DataService;

public class UserDataService:DataProvider,IUserDataService
{
    public readonly string _connection = "";
    public UserDataService(string connection) : base(connection)
    {
        _connection = connection;
    }
    public async Task<User> Create(User data)
    {
        var reader = await this.ExecuteWithResult(UserDataQuerys.insertQuery, new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p1", data.TelegramClientId),
            new NpgsqlParameter("@p2", data.PhoneNumber),
            new NpgsqlParameter("@p3", data.Password),
        });
        List<User> result = new List<User>();
        while (reader.Read())
            result.Add(this.ReaderDataToModel(reader));

        return result.ElementAtOrDefault(0);
    }

    public async Task<User> Update(long Id,User data)
    {
        await this.ExecuteNonResult(UserDataQuerys.updateQuery, new NpgsqlParameter[]
        {
            
            new NpgsqlParameter("@p1", data.PhoneNumber),
            new NpgsqlParameter("@p2", data.Password),
            new NpgsqlParameter("@p4", data.TelegramClientId),
        });
        return data; 
    }

    public async Task<User> Delete(long id)
    {
        return await FindById(id);
    }

    public async Task<List<User>> GetAll()
    {
        var reader = await this.ExecuteWithResult(UserDataQuerys.selectQuery, null);
        List<User> result = new List<User>();
        while (reader.Read())
            result.Add(this.ReaderDataToModel(reader));

        return result;
    }

    public async Task<User> FindById(long Id)
    {
        var reader = await this.ExecuteWithResult(UserDataQuerys.selectByIdQuery, new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p0", Id)
        });
        List<User> result = new List<User>();
        while (reader.Read())
            result.Add(this.ReaderDataToModel(reader));

        return result.ElementAtOrDefault(0);
    }

    public async Task<User> FindPhoneAndPassword(string phoneNumber, string password)
    {
        var reader = await this.ExecuteWithResult(UserDataQuerys.selectByLoginAndPassword, new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p0", phoneNumber),
            new NpgsqlParameter("@p1", password)
        });
        List<User> result = new List<User>();
        while (reader.Read())
            result.Add(this.ReaderDataToModel(reader));

        return result.ElementAtOrDefault(0);
    }
    private User ReaderDataToModel(NpgsqlDataReader reader)
    {
        return new User()
        {
            Id= reader.GetInt32(0),
            TelegramClientId = reader.GetInt32(1),
            PhoneNumber = reader.GetString(2),
            Password = reader.GetString(3)
            
        };
    }
}