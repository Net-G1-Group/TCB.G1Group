
using System.Data;
using Npgsql;
using TCB.G1Group.DataService.Interface;
using TCB.G1Group.DBQuerys;
using TCB.G1Group.Domain.Enums;
using TCB.G1Group.Domain.Models;

namespace TCB.G1Group.DataService;

public class BoardDataService:DataProvider,IBoardDataService
{
    private readonly IMessageDataService _messageDataService;

    public BoardDataService(string connectionString,IMessageDataService messageDataService) : base(connectionString)
    {
        _messageDataService = messageDataService;
    }

    public async Task<BoardModel> Create(BoardModel data)
    {
        NpgsqlParameter[]? parameters = new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p1",data.NickName),
            new NpgsqlParameter("@p2",data.BoardStatus),
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
            new NpgsqlParameter("@p1",data.NickName),
            new NpgsqlParameter("@p0",Id),
            new NpgsqlParameter("@p2",data.BoardStatus)
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