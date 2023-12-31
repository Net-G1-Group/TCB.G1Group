using TCB.G1Group.DataService.Interface;
using TCB.G1Group.Domain.Modles;

namespace TCB.G1Group.DataService;

public static class UserDataQuerys
{
    private static string tableName = "users";

    public static string selectQuery = $"SELECT * FROM {tableName}";
    public static string selectByIdQuery = $"SELECT * FROM {tableName} WHERE id = @p0";
    public static string selectByChatIdQuery = $"SELECT * FROM {tableName} WHERE telegram_client_id= @p0";
    public static string selectByLoginAndPassword = $"SELECT * FROM {tableName} WHERE phone_number = @p0 and password = @p1;";
    public static string insertQuery =
        $"INSERT INTO {tableName} (telegram_client_id,phone_number,password) VALUES ( @p1, @p2, @p3) RETURNING * ;";
    public  static string updateQuery = $"UPDATE {tableName} SET (phone_number,password) VALUES (@p1,@p2) WHERE id=@p0;";
}