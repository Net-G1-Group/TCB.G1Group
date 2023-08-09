namespace TCB.G1Group.DBQuerys;

public static class MessageDataQuery
{
    private static string _tableName = "messages";
    
    public static string SelectQuery = $"SELECT * FROM {_tableName}";
    public static string SelectByBoardIdQuery = $"SELECT * FROM {_tableName} WHERE board_id = @p5";
    public static string SelectByAnonymChatIdQuery = $"SELECT * FROM {_tableName} WHERE chat_id = @p3";
    public static string SelectByIdQuery = $"SELECT * FROM {_tableName} WHERE id = @p0";
    public static string SelectByBoardIdQueryState = $"SELECT * FROM {_tableName} WHERE board_id = @p5 AND message_state = 0";
    public static string SelectByAnonymChatIdQueryState = $"SELECT * FROM {_tableName} WHERE chat_id = @p3 AND message_state = 0";
    
    public static string UpadeteQuery = $"UPDATE {_tableName} SET message_state = @p6,message = @p2 WHERE id = @p0;";
    
    public static string InsertQuery = $"INSERT INTO {_tableName} (from_id,message,chat_id,type,board_id,message_state) VALUES " +
                                       $"                           ( @p1, @p2,@p3,@p4,@p5,@p6)";
    public static string DeleteQuery = $"DELETE FROM {_tableName} WHERE id = @p0";
    
}