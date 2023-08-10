namespace TCB.G1Group.DataService;

public static class AnonymChatQuery
{
    private static string tableName = "anonym_chats";
    
    public static string Select = $"SELECT * FROM public.{tableName}";

    public static string SelectById = $"SELECT *FROM public.{tableName} WHERE id = @p0";

    public static string SelectByFromId = $"SELECT * FROM public.{tableName} WHERE from_id = @p2";

    public static string SelectByToId = $"SELECT *FROM public.{tableName} WHERE to_id = @p3";

    public static string UpdateById = $"UPDATE public.{tableName} tn SET tn.create_date = @p1, tn.from_id = @p2, tn.to_id = @p3, tn.state = @p4 WHERE tn.id = @p0";

    public static string Insert = $"INSERT INTO public.{tableName} (id , create_date , from_id , to_id , state )" +
                                  $"VALUES (@p0, @p1, @p2, @p3, @p4)";

    public static string Delete = $"DELETE FROM public.{tableName} WHERE id = @p0";
    
}