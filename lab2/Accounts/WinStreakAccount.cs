using DB.Service;

namespace Accounts
{
	class WinStreakAccount : GameAccount
	{
		private static int streakCount = 0;
		public WinStreakAccount(string userName, int currentRaiting, int id) : base(userName, currentRaiting, id) { }

		protected override int CalcRate(bool isWin, int rating)
		{
			if (isWin)
			{
				streakCount++;
				return rating + streakCount - 1;
			} else
			{
				streakCount = 0;
				return -rating;
			}
		}
	}
}
