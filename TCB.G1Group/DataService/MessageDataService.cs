using System.Data;
using Npgsql;
using TCB.G1Group.DataService.Interface;
using TCB.G1Group.DBQuerys;
using TCB.G1Group.Domain.Enums;
using TCB.G1Group.Domain.Models;

namespace TCB.G1Group.DataService;

public class MessageDataService : DataProvider, IMessageDataService
{
    public MessageDataService(string connectionString) : base(connectionString)
    {
    }

    public async Task<Message> Create(Message message)
    {
        NpgsqlParameter[]? parameters = new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p1", message.FromId),
            new NpgsqlParameter("@p2", message._Message),
            new NpgsqlParameter("@p3", message.ChatId),
            new NpgsqlParameter("@p4", message.Type),
            new NpgsqlParameter("@p5", message.BoardId),
            new NpgsqlParameter("@p6", message.State)
        };
        var reader = await ExecuteWithResult(MessageDataQuery.InsertQuery, parameters);
        return await this.NpgSqlDataReaderToMessage(reader);
    }

    public async Task<Message> Update(long Id, Message message)
    {
        Message messageDB = await this.FindById(Id);
        messageDB = new Message
        {
            Id = Id,
            FromId = message.FromId,
            _Message = message._Message,
            ChatId = message.ChatId,
            Type = message.Type,
            BoardId = message.BoardId,
            State = message.State
        };
        NpgsqlParameter[]? parameters = new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p6", message.State),
            new NpgsqlParameter("@p2", message._Message),
            new NpgsqlParameter("@p0", message.Id)
        };
        var reader = await base.ExecuteWithResult(MessageDataQuery.UpadeteQuery, parameters);
        return await this.NpgSqlDataReaderToMessage(reader);
    }

    public async Task<Message> Delete(long Id)
    {
        NpgsqlParameter[]? parameters = new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p0", Id)
        };
        return await this.NpgSqlDataReaderToMessage(await base.ExecuteWithResult(MessageDataQuery.DeleteQuery,
            parameters));
    }

    public async Task<List<Message>> GetAll()
    {
        List<Message> messages = new List<Message>();
        var reader = await base.ExecuteWithResult(MessageDataQuery.SelectQuery, null);
        while (reader.Read())
        {
            messages.Add(await this.NpgSqlDataReaderToMessage(reader));
        }

        return messages;
    }

    public async Task<Message> FindById(long Id)
    {
        NpgsqlParameter[]? parameters = new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p0", Id)
        };
        var reader = await base.ExecuteWithResult(MessageDataQuery.SelectByIdQuery, parameters);
        return await this.NpgSqlDataReaderToMessage(reader);
    }

    public async Task<List<Message>> GetMessagesByBoardId(long BoardId)
    {
        NpgsqlParameter[]? parameters = new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p5", BoardId)
        };
        List<Message> messages = new List<Message>();
        var reader = await base.ExecuteWithResult(MessageDataQuery.SelectByBoardIdQuery, parameters);
        while (reader.Read())
        {
            messages.Add(await this.NpgSqlDataReaderToMessage(reader));
        }

        return messages;
    }

    public async Task<List<Message>> GetMessagesByAnonymChatId(long AnonymChatId)
    {
        NpgsqlParameter[]? parameters = new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p3", AnonymChatId)
        };
        List<Message> messages = new List<Message>();
        var reader = await base.ExecuteWithResult(MessageDataQuery.SelectByAnonymChatIdQuery, parameters);
        while (reader.Read())
        {
            messages.Add(await this.NpgSqlDataReaderToMessage(reader));
        }
        return messages;
    }

    public async Task<List<Message>> GetMessagesByBoardIdState(long BoardId)
    {
        NpgsqlParameter[]? parameters = new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p5", BoardId)
        };
        List<Message> messages = new List<Message>();
        var reader = await base.ExecuteWithResult(MessageDataQuery.SelectByBoardIdQueryState, parameters);
        while (reader.Read())
        {
            messages.Add(await this.NpgSqlDataReaderToMessage(reader));
        }

        return messages;
    }

    public async Task<List<Message>> GetMessagesByAnonymChatIdState(long AnonymChatId)
    {
        NpgsqlParameter[]? parameters = new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p3", AnonymChatId)
        };
        List<Message> messages = new List<Message>();
        var reader = await base.ExecuteWithResult(MessageDataQuery.SelectByAnonymChatIdQueryState, parameters);
        while (reader.Read())
        {
            messages.Add(await this.NpgSqlDataReaderToMessage(reader));
        }
        return messages;
    }

    private async Task<Message> NpgSqlDataReaderToMessage(NpgsqlDataReader reader) => new Message
    {
        Id = reader.GetInt32(0),
        FromId = reader.GetInt32(1),
        _Message = reader.GetString(2),
        ChatId = reader.GetInt32(3),
        Type = (MessageType)reader.GetInt32(4),
        BoardId = reader.GetInt32(5),
        State = (MessageState)reader.GetInt32(6)
    };
}