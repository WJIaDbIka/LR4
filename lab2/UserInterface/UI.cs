using DB.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface.Base;

namespace UserInterface
{
	public class UI : IUserInterface
	{
		GameAccountService accountService;
		GameService gameService;
		List<IUserInterface> Commands = new List<IUserInterface>();
		public UI(GameAccountService accountService, GameService gameService)
		{
			this.accountService = accountService;
			this.gameService = gameService;
			Commands.Add(new Play(accountService, gameService));
			Commands.Add(new ShowAllUsersStatsUI(accountService));
			Commands.Add(new ShowIdUserStatsUI(accountService));
		}

		public void Action()
		{
			do
			{
				Console.WriteLine("Start Game (1),\n" +
				"Show statistic of all accounts (2),\n" +
				"Show statistic by account id (3),\n" +
				"Help (4)\n" +
				"Exit (5)");
				int temp = Convert.ToInt32(Console.ReadLine());
				if (temp == 1)
				{
					Commands[0].Action();
				}
				else if (temp == 2)
				{
					Commands[1].Action();
				}
				else if (temp == 3)
				{
					Commands[2].Action();
				}
				else if (temp == 4)
				{
					Console.WriteLine("(1):");
					Commands[0].GetInfo();
					Console.WriteLine("(2):");
					Commands[1].GetInfo();
					Console.WriteLine("(3):");
					Commands[2].GetInfo();
					Console.WriteLine("");
				}
				else if (temp == 5)
				{
					return;
				}
				else
				{
					Console.WriteLine("Incorrect input");
				}
			} while(true);
		}
		public void GetInfo()
		{
			Console.WriteLine("user Interface for game");
		}
	}
}
