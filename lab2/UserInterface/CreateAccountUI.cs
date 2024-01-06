using DB.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface.Base;

namespace UserInterface
{
	public class CreateAccountUI : IUserInterface
	{
		GameAccountService accountService;
		public CreateAccountUI(GameAccountService gameAccountService)
		{
			this.accountService = gameAccountService;
		}
		public void Action()
		{
			bool flag;
			do
			{
				Console.WriteLine("Type user name for new account: ");
				string username = Console.ReadLine().Trim();
				Console.WriteLine("Choose account type:\n\t" +
					"Cummon Account (1),\n\t" +
					"Low Loose Rate Account (2),\n\t" +
					"Win Streak Account (3)");
				int temp = Convert.ToInt32(Console.ReadLine());
				flag = false;
				if (temp == 1)
				{
					accountService.Create(username, 0, DB.Entity.Accounts.AccountType.GAME_ACCOUNT);
				}
				else if (temp == 2)
				{
					accountService.Create(username, 0, DB.Entity.Accounts.AccountType.LOW_LOOSE_RATE_ACCOUNT);
				}
				else if (temp == 3)
				{
					accountService.Create(username, 0, DB.Entity.Accounts.AccountType.WIN_STREAK_ACCOUNT);
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
			Console.WriteLine("\tCreate new account for game");
		}
	}
}
