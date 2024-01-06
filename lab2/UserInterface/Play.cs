using DB.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface.Base;

namespace UserInterface
{
	public class Play : IUserInterface
	{
		GameAccountService accountService;
		GameService gameService;
		List<IUserInterface> Commands = new List<IUserInterface>();
		public Play(GameAccountService accountService, GameService gameService)
		{
			this.accountService = accountService;
			this.gameService = gameService;
			Commands.Add(new CreateAccountUI(accountService));
			Commands.Add(new CreateGameUI(gameService));
			Commands.Add(new PlayGameUI(accountService, gameService));
		}

		public void Action()
		{
			Commands[0].Action();
			Commands[0].Action();
			Commands[1].Action();
			Commands[2].Action();
		}
		public void GetInfo()
		{
			Commands[0].GetInfo();
			Commands[1].GetInfo();
			Commands[2].GetInfo();
		}
	}
	
}
