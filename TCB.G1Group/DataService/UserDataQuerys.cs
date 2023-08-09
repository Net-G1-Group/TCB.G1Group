using TCB.G1Group.DataService.Interface;
using TCB.G1Group.Domain.Modles;

namespace TCB.G1Group.DataService;

public static class UserDataQuerys
{
    private static string tableName = "users";

    private static string selectQuery = $"SELECT * FROM {tableName}";
    private static string selectByIdQuery = $"SELECT * FROM {tableName} WHERE id = @p0";
    private static string selectByChatIdQuery = $"SELECT * FROM {tableName} WHERE telegram_client_id= @p0";
    private static string selectByLoginAndPassword = $"SELECT * FROM {tableName} WHERE phone_number = @p0 and password = @p1;";
     
}