using Npgsql;
using TCB.G1Group.Domain.Enums;
using TCB.G1Group.Domain.Models;

namespace TCB.G1Group.DataService;

public class ConversationDataService : DataProvider
{

    public ConversationDataService(string connectionString) : base(connectionString)
    {
        
    }

    public async Task<List<AnonymChat>> GetAll()
    {
        var reader = await this.ExecuteWithResult(AnonymChatQuery.Select, null);
        List<AnonymChat> anonymChats = new List<AnonymChat>();
        while (reader.Read())
        {
            anonymChats.Add(this.ReaderDataAnonymChat(reader));
        }

        return anonymChats;
    }

    public async Task<AnonymChat?> FindGetById(long id)
    {
        var reader = await this.ExecuteWithResult(AnonymChatQuery.SelectById, new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p0", id)
        });
        List<AnonymChat> anonymChats = new List<AnonymChat>();
        while (reader.Read())
        {
            anonymChats.Add(this.ReaderDataAnonymChat(reader));
        }

        return anonymChats.ElementAtOrDefault(0);
    }

    public async Task<AnonymChat?> FindByFromId(long fromId)
    {
        var reader = await this.ExecuteWithResult(AnonymChatQuery.SelectByFromId, new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p2" , fromId)
        });
        List<AnonymChat> anonymChats = new List<AnonymChat>();
        while (reader.Read())
        {
            anonymChats.Add(this.ReaderDataAnonymChat(reader));
        }

        return anonymChats.ElementAtOrDefault(0);
    }

    public async Task<AnonymChat?> FindByToId(long toId)
    {
        var reader = await this.ExecuteWithResult(AnonymChatQuery.SelectByToId, new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p3", toId)
        });
        List<AnonymChat> anonymChats = new List<AnonymChat>();
        while (reader.Read())
        {
            anonymChats.Add(this.ReaderDataAnonymChat(reader));
        }

        return anonymChats.ElementAtOrDefault(0);
    }

    public async Task<AnonymChat?> Delete(long id)
    {
        AnonymChat anonymChat = await FindGetById(id);
        var result = await ExecuteNonResult(AnonymChatQuery.Delete, new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p0", id)
        });
        return anonymChat;
    }

    public async Task<AnonymChat?> Update(long id, AnonymChat chat)
    {
        var result = await ExecuteNonResult(AnonymChatQuery.UpdateById, new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p0", id),
            new NpgsqlParameter("@p1" , chat.CreatedDate),
            new NpgsqlParameter("@p2" , chat.FromId),
            new NpgsqlParameter("@p3" , chat.ToId),
            new NpgsqlParameter("@p4" , chat.State)
        });
        return await FindGetById(id);
    }

    public async Task<AnonymChat?> CreateAnonymChat(AnonymChat chat)
    {
        var result = await ExecuteNonResult(AnonymChatQuery.Insert, new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p0", chat.Id),
            new NpgsqlParameter("@p1" , chat.CreatedDate),
            new NpgsqlParameter("@p2" , chat.FromId),
            new NpgsqlParameter("@p3" , chat.ToId),
            new NpgsqlParameter("@p4" , chat.State)
        });
        return await FindGetById(chat.Id);
    }


    private AnonymChat ReaderDataAnonymChat(NpgsqlDataReader reader)
    {
        return new AnonymChat()
        {
            Id = reader.GetInt64(0),
            CreatedDate = reader.GetDateTime(1),
            FromId = reader.GetInt64(2),
            State = (ChatState)Enum.Parse(typeof(ChatState), reader.GetString(3)),
            ToId = reader.GetInt64(4)
        };
    }

}