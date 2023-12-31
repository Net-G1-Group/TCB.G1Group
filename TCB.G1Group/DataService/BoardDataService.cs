
using System.Data;
using Npgsql;
using TCB.G1Group.DataService.Interface;
using TCB.G1Group.DBQuerys;
using TCB.G1Group.Domain.Enums;
using TCB.G1Group.Domain.Models;

namespace TCB.G1Group.DataService;

public class BoardDataService:DataProvider,IBoardDataService
{
    public readonly IMessageDataService _messageDataService;

    public BoardDataService(string connectionString,IMessageDataService messageDataService) : base(connectionString)
    {
        _messageDataService = messageDataService;
    }
    // public async Task<BoardModel?> GetById(long id)
    // {
    //     var reader = await this.ExecuteWithResult(this.selectByIdQuery, new NpgsqlParameter[]
    //     {
    //         new NpgsqlParameter("@p0", id)
    //     });
    //     List<BoardModel> result = new List<BoardModel>();
    //     while (reader.Read())
    //         result.Add(this.ReaderDataToModel(reader).Result);
    //
    //     return result.ElementAtOrDefault(0);
    // }

    public async Task<BoardModel> Create(BoardModel data)
    {
        NpgsqlParameter[]? parameters = new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p1",data.NickName),
            new NpgsqlParameter("@p2",data.OwnerId),
            new NpgsqlParameter("@p3",data.BoardStatus)
        };
        var reader = await base.ExecuteWithResult(BoardModelQuery.insertQuery, parameters);
        return await this.NpgSqlDataReaderToBoardModel(reader);

    }

    public async Task<BoardModel> Update(long Id, BoardModel data)
    {
        var boardModelDB = await this.FindById(Id);
        boardModelDB = new BoardModel
        {
            Id = Id,
            NickName = data.NickName,
            OwnerId = data.OwnerId,
            BoardStatus = data.BoardStatus
        };
        NpgsqlParameter[]? parameters = new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p0",Id),
            new NpgsqlParameter("@p1",data.NickName),
            new NpgsqlParameter("@p2",data.OwnerId),
            new NpgsqlParameter("@p3",data.BoardStatus)
        };
        var reader = await base.ExecuteWithResult(BoardModelQuery.updateQuery, parameters);
        return await this.NpgSqlDataReaderToBoardModel(reader);
    }

    public async Task<BoardModel> Delete(long Id)
    {
        NpgsqlParameter[]? parameters = new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p0",Id)
        };
        var reader = await base.ExecuteWithResult(BoardModelQuery.deleteQuery, parameters);
        return await this.NpgSqlDataReaderToBoardModel(reader);
    }
    public async Task<BoardModel> Stop(long Id)
    {
        NpgsqlParameter[]? parameters = new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p0",Id),
            new NpgsqlParameter("@p3",BoardStatus.Stopped),
        };
        var reader = await base.ExecuteWithResult(BoardModelQuery.stopQuery, parameters);
        return await this.NpgSqlDataReaderToBoardModel(reader);
    }

    public async Task<List<BoardModel>> GetAll()
    {
        List<BoardModel> boardModels = new List<BoardModel>();
        var reader = await base.ExecuteWithResult(BoardModelQuery.selectQuery, null);
        while (reader.Read())
        {
            boardModels.Add(await this.NpgSqlDataReaderToBoardModel(reader));
        }

        return boardModels;
    }

    public async Task<BoardModel> FindById(long Id)
    {
        NpgsqlParameter[]? parameters = new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p0",Id)
        };
        var reader = await base.ExecuteWithResult(BoardModelQuery.selectByIdQuery, parameters);
        return await this.NpgSqlDataReaderToBoardModel(reader);
    }

    public async Task<BoardModel> FindByNickName(string nickName)
    {
        NpgsqlParameter[]? parameters = new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p1",nickName)
        };
        var reader = await base.ExecuteWithResult(BoardModelQuery.selectByNickNameQuery, parameters);
        return await this.NpgSqlDataReaderToBoardModel(reader);
    }

    public async Task<BoardModel> BoardMessages(long boardId)
    {
        var board = await this.FindById(boardId);
        var messages = await _messageDataService.GetMessagesByBoardId(boardId);
        board.MessageList = messages;
        return board;
    }

    public async Task<BoardModel> BoardMessageState(long boardId)
    {
        var board = await this.FindById(boardId);
        var messages = await _messageDataService.GetMessagesByBoardIdState(boardId);
        board.MessageList = messages;
        return board;
    }

    private async Task<BoardModel> NpgSqlDataReaderToBoardModel(NpgsqlDataReader reader)
    {
        return new BoardModel
        {
            Id = reader.GetInt32(0),
            NickName = reader.GetString(1),
            OwnerId = reader.GetInt64(2),
            BoardStatus = (BoardStatus)reader.GetInt32(3)
        };
    }
}