using DB.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface.Base;

namespace UserInterface
{
	public class ShowIdUserStatsUI : IUserInterface
	{
		GameAccountService accountService;
		public ShowIdUserStatsUI(GameAccountService accountService)
		{
			this.accountService = accountService;
		}
		public void Action()
		{
			Console.Write("Type user id: ");
			int id = Convert.ToInt32(Console.ReadLine());
			accountService.Get(id).GetStats();
		}
		public void GetInfo()
		{
			Console.WriteLine("\tShow account statistic by his Id");
		}
	}
}
