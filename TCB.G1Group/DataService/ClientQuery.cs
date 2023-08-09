namespace TCB.G1Group.DataService;

public static class ClientQuery
{
    public static string SelectQuyer = $"SELECT * FROM public.Client";
    
    public static string SelectByIdQuyer = $"SELECT * FROM public.Client  WHERE id = @p0";
    
    public static string SelectByUserIdQuery = $"SELECT * FROM public.Client WHERE user_id= @p1";
    
    public static string SelectByNickNameQuery = $"SELECT * FROM public.Client WHERE nick_name = @p2";
    
    
    public static string InsertQuery = $"INSERT INTO public.Client (id  , user_id , nick_name, status , isPremium )" +
                                       $" VALUES(@p0 , @p1 , @p2 , @p3 , @p4 )";
    
    public static string UpdateQuery = $"UPDATE public.Client c  SET  c.user_id = @p1  , c.nick_name = @p2 , c.status = @p3 , c.isPremium = @p4  WHERE id = @p0";

    
    public static string DeleteQuery = $"DELETE FROM public.Client WHERE id = @p0";
}