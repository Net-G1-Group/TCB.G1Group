using TCB.G1Group.DataService;
using TCB.G1Group.Domain.Enums;
using TCB.G1Group.Domain.Models;
using TCB.G1Group.Domain.Modles;
using TCB.G1Group.Domain.ViewModels;

namespace TCB.G1Group;

public class AuthService
{
    private UserDataService _userDataService;
    private ClientDataService _clientDataService;
    public AuthService(UserDataService userDataService,ClientDataService clientDataService)
    {
        _userDataService = userDataService;
        _clientDataService = clientDataService;
    }
    public async Task RegisterUser(AuthView userRegistration)
    {
        var User = await _userDataService.Create(new User()
        {
            Password = userRegistration.Password,
            PhoneNumber = userRegistration.PhoneNumber,
            TelegramClientId = userRegistration.ChatId
          
        });
        await _clientDataService.Create(new Client()
        {
            UserId = User.Id,
            Status = ClientStatus.Enabled,
            NickName = string.Empty,
          
            IsPremium = false,
        });
        if (User is null)
            throw new Exception("Unable to insert user");
    }


    public async Task<Client> Login(AuthView user)
    {
        var userInfo = await _userDataService.FindPhoneAndPassword(user.PhoneNumber, user.Password);

        if (userInfo is not null)
        {
            return await _clientDataService.FindByUserId(userInfo.Id);
        }
        return null;
    }
}