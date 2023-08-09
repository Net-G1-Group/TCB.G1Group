using TCB.G1Group.Domain.ViewModels;
using TCB.G1Group.TelegramBot.Controllers;

namespace TCB.G1Group.TelegramBot.Managers;

public class ControllerManager
{
    private LoginControler _loginControler;
    private RegisterController _registerController;
    private BoardController _boardController;
    private HomeController _homeController;

    public ControllerManager()
    {
        _loginControler = new LoginControler(this);
        _registerController = new RegisterController(this);
        _boardController = new BoardController(this);
        _homeController = new HomeController(this);
    }
    
    public async Task<ControllerBase> GetControllerBySessionData(Session session)
    {
        switch (session.Controller)
        {
            case nameof(_loginControler):
                return _loginControler;
            case nameof(_registerController):
                return this._registerController;
            case nameof(_boardController):
                return _boardController;
            
        }
        
        return this.DefaultController;
    }

    public ControllerBase DefaultController => this._homeController;

}