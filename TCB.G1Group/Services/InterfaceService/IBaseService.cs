namespace TCB.G1Group.InterfaceService;

public interface IBaseService<T>
{
    public Task<T> Create(T data);

    public Task<T> Update(long Id,T data);

    public Task<T> Delete(long Id);

    public Task<List<T>> GetAll();

    public Task<T> FindById(long Id);
}