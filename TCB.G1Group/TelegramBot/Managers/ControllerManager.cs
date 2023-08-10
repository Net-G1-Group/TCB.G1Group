using TCB.G1Group.Confugration;
using TCB.G1Group.DataService;
using TCB.G1Group.Domain.ViewModels;
using TCB.G1Group.TelegramBot.Controllers;

namespace TCB.G1Group.TelegramBot.Managers;

public class ControllerManager
{
   
    private BoardController _boardController;
    private readonly HomeController _homeController;
    private readonly UserDataService _userDataService;
    private readonly ClientDataService _clientDataService;
    private readonly AuthService _authService;

    public ControllerManager()
    {
        _userDataService = new UserDataService(Settings.dbConnectionString);
         _clientDataService = new ClientDataService(Settings.dbConnectionString);
         _authService = new AuthService(_userDataService, _clientDataService);
        
        _boardController = new BoardController(this);
        _homeController = new HomeController(this);
    }
    
    public async Task<ControllerBase> GetControllerBySessionData(Session session)
    {
        switch (session.Controller)
        {
           
            case nameof(_boardController):
                return _boardController;
            
        }
        
        return this.DefaultController;
    }

    public ControllerBase DefaultController => this._homeController;

}