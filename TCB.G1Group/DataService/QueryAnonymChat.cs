namespace TCB.G1Group.DataService;

public static class QueryAnonymChat
{
    private static string tableName = "";
    private static string database = "";

    public static string SelectQuery = $"SELECT * FROM {database}.{tableName} ;";
    public static string SelectByIdQuery = $"SELECT * FROM {database}.{tableName} WHERE id = @p0";
    public static string SelectByClientChatIdQuery = $"SELECT * FROM {database}.{tableName} WHERE client_id = @p1 or client_id = @p1";
    public static string SelectByStatusQuery = $"SELECT * FROM {database}.{tableName} WHERE ";
}