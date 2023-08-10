namespace TCB.G1Group.DataService;

public static class ClientQuery
{
    public static string SelectQuyer = $"SELECT * FROM clients";
    
    public static string SelectByIdQuyer = $"SELECT * FROM clients  WHERE id = @p0";
    
    public static string SelectByUserIdQuery = $"SELECT * FROM clients WHERE user_id= @p1";
    
    public static string SelectByNickNameQuery = $"SELECT * FROM clients WHERE nickname = @p2";
    
    
    public static string InsertQuery = $"INSERT INTO clients ( user_id , nickname, status , is_premium )" +
                                       $" VALUES( @p1 , @p2 , @p3 , @p4 )";
    
    public static string UpdateQuery = $"UPDATE clients SET user_id = @p1  ,nickname = @p2 , status = @p3 , is_premium = @p4  WHERE id = @p0";

    
    public static string DeleteQuery = $"DELETE FROM clients WHERE id = @p0";
}