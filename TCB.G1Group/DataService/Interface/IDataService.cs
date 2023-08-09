namespace TCB.G1Group.DataService.Interface;

public interface IDataService<T>
{
    public Task<T> Create(T data);

    public Task<T> Update(long Id,T data);

    public Task<T> Delete(long Id);

    public Task<List<T>> GetAll();

    public Task<T> FindById(long Id);
}