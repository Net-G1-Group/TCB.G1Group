using TCB.G1Group.Confugration;
using TCB.G1Group.DataService;
using TCB.G1Group.Domain.ViewModels;
using TCB.G1Group.TelegramBot.Controllers;

namespace TCB.G1Group.TelegramBot.Managers;

public class ControllerManager
{
   
    private BoardController _boardController;
    private readonly HomeController _homeController;
    public readonly UserDataService _userDataService;
    private readonly ClientDataService _clientDataService;
    private readonly AuthService _authService;
    private readonly AuthController _authController;

    public ControllerManager()
    {
        _userDataService = new UserDataService(Settings.dbConnectionString);
         _clientDataService = new ClientDataService(Settings.dbConnectionString);
         _authService = new AuthService(_userDataService, _clientDataService);
        _authController = new AuthController(_authService,this);
        
        _boardController = new BoardController(this);
        _homeController = new HomeController(this);
    }
    
    public async Task<ControllerBase> GetControllerBySessionData(Session session)
    {
        switch (session.Controller)
        {
           
            case nameof(BoardController):
                return _boardController;
            case nameof(AuthController):
                return _authController;
            
            
        }
        
        return this.DefaultController;
    }

    public ControllerBase DefaultController => this._homeController;

}