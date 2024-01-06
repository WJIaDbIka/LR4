using DB.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface.Base;

namespace UserInterface
{
	public class ShowAllUsersStatsUI : IUserInterface
	{
		GameAccountService accountService;
		public ShowAllUsersStatsUI(GameAccountService accountService)
		{
			this.accountService = accountService;
		}
		public void Action()
		{
			var accountList = accountService.GetAll();
			foreach (var account in accountList)
			{
				if (account != null)
				{
					account.GetStats();
				}
			}
		}
		public void GetInfo()
		{
			Console.WriteLine("\tShow statistic of all existing game accounts");
		}
	}
}
