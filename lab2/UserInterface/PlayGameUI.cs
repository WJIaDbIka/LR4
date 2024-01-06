using Accounts;
using DB.Service;
using GameFactory;
using Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using UserInterface.Base;

namespace UserInterface
{
	public class PlayGameUI : IUserInterface
	{
		GameAccountService accountService;
		GameService gameService;
		private int GameCount;
		public PlayGameUI(GameAccountService accountService, GameService gameService)
		{
			this.accountService = accountService;
			this.gameService = gameService;
			GameCount = 0;
		}
		public void Action()
		{
			var Player1 = accountService.Get(accountService.GetAll().Count - 2);
			var Player2 = accountService.Get(accountService.GetAll().Count - 1);

			var player1Game = gameService.Get(gameService.GetAll().Count - 2);
			var player2Game = gameService.Get(gameService.GetAll().Count - 1);

			bool playAgain = true;
			do
			{
				GameCount++;
				var rand = new Random();
				if (rand.Next(0, 2) == 0)
				{
					player1Game.UserName = Player1.UserName;
					player1Game.IsWin = true;
					player1Game.GameCount = GameCount;

					player2Game.UserName = Player2.UserName;
					player2Game.IsWin = false;
					player2Game.GameCount = GameCount;

					Player1.WinGame(player1Game);
					Player2.LoseGame(player2Game);

					player1Game.CurrentRaiting = Player1.CurrentRating;
					player2Game.CurrentRaiting = Player2.CurrentRating;
				}
				else
				{
					player1Game.UserName = Player1.UserName;
					player1Game.IsWin = false;
					player1Game.GameCount = GameCount;

					player2Game.UserName = Player2.UserName;
					player2Game.IsWin = true;
					player2Game.GameCount = GameCount;

					Player1.LoseGame(player1Game);
					Player2.WinGame(player2Game);

					player1Game.CurrentRaiting = Player1.CurrentRating;
					player2Game.CurrentRaiting = Player2.CurrentRating;
				}

				gameService.Update(player1Game);
				gameService.Update(player2Game);

				accountService.Update(Player1);
				accountService.Update(Player2);
				Game._gameId += 10;

				Console.Write("Want play another game? (Yes/No): ");
				string playAgainResponse = Console.ReadLine().Trim();

				if (!playAgainResponse.Equals("Yes", StringComparison.OrdinalIgnoreCase))
				{
					playAgain = false;
				}
			} while (playAgain);
		}
		public void GetInfo()
		{
			Console.WriteLine("\tStart game and you can restart it");
		}
	}
}
