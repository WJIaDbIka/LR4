using DB.Service;
using Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface.Base;

namespace UserInterface
{
	public class CreateGameUI : IUserInterface
	{
		GameService gameService;
		public CreateGameUI(GameService gameService) 
		{
			this.gameService = gameService;
		}
		public void Action()
		{
			bool flag;
			do
			{
				Console.WriteLine("Choose game type:\n\t" +
				"Cummon Game (1),\n\t" +
				"Train Game (2),\n\t" +
				"Double Rate Game (3)");
				int temp = Convert.ToInt32(Console.ReadLine());
				flag = false;
				if (temp == 1)
				{
					Console.WriteLine("Type rating for game: ");
					int rate = Convert.ToInt32(Console.ReadLine());
					gameService.Create("", true, rate, 0, GameType.CUMMON_GAME);
					gameService.Create("", true, rate, 0, GameType.CUMMON_GAME);
				}
				else if (temp == 2)
				{
					gameService.Create("", true, 0, 0, GameType.TRAIN_GAME);
					gameService.Create("", true, 0, 0, GameType.TRAIN_GAME);
				}
				else if (temp == 3)
				{
					Console.WriteLine("Type rating for game: ");
					int rate = Convert.ToInt32(Console.ReadLine());
					gameService.Create("", true, rate, 0, GameType.DOUBLE_RATE_GAME);
					gameService.Create("", true, rate, 0, GameType.DOUBLE_RATE_GAME);
				}
				else
				{
					Console.WriteLine("Incorrect input");
					flag = true;
				}
			} while (flag);
		}
		public void GetInfo()
		{
			Console.WriteLine("\tCreate two game instances for game accounts");
		}
	}
}
