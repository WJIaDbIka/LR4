using Accounts;
using DB;
using DB.Service;
using Games;
using UserInterface;

class Program
{
    static void Main()
    {
        Game._gameId = 1000;

        DBContext context = new DBContext();
        GameAccountService accService = new GameAccountService(context);
        GameService gameService = new GameService(context);

        UI ui = new UI(accService, gameService);
        ui.Action();
    }
}
