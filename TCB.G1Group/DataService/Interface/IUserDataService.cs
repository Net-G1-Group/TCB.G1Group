using TCB.G1Group.Domain.Modles;

namespace TCB.G1Group.DataService.Interface;

public interface IUserDataService:IDataService<User>
{
 public Task<User> FindPhoneAndPassword(string phoneNumber,string password);
 
}