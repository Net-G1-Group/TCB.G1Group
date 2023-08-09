namespace TCB.G1Group.DBQuerys;

public static class BoardModelQuery
{
    public static string tableName = "boards";

    public static string selectQuery = $"SELECT * FROM {tableName}";
    
    public static string selectByIdQuery = $"SELECT * FROM {tableName} WHERE id = @p0";
    public static string selectByNickNameQuery = $"SELECT * FROM {tableName} WHERE nickname = @p1";
    
    public static string updateQuery = $"UPDATE {tableName} SET " +
                                       $"nick_name = @p1,owner_id = @p2,board_status = @p3 WHERE id = @p0 ;";
    
    
    public static string insertQuery =
        $"INSERT INTO {tableName} (nickname,board_status) VALUES " +
        $"(@p1,@p2);";
    
    public static string deleteQuery = $"DELETE FROM {tableName} WHERE id = @p0 ;";
}
