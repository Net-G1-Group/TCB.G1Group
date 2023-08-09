namespace TCB.G1Group.DataService.Interface;

public interface IDataService<T>
{
    public Task<T> Create(T data);

    public Task<T> UpDate(T data);

    public Task<T> Delete(T data);

    public Task<List<T>> GetAll();

    public Task<T> FindById(long Id);
}