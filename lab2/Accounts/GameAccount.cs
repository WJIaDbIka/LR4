using DB.Service;
using Games;
using GHistory;

namespace Accounts
{
    public class GameAccount
    {
        public int ID {  get; set; }
        public string UserName { get; set; }
        private int currentRating;
        public int CurrentRating
        {
            get { return currentRating; }
            set
            {
                if (value < 1)
                {
                    currentRating = 1;
                }
                else
                {
                    currentRating = value;
                }
            }
        }
        public List<GameHistory> gameHistory {  get; set; }

        public GameAccount(string userName, int currentRaiting, int id)
        {
            UserName = userName;
            CurrentRating = currentRaiting;
            ID = id;
            gameHistory = new List<GameHistory>();
        }

        virtual protected int CalcRate(bool isWin, int rating)
        {
            if (isWin)
            {
                return rating;
            } else
            {
                return -rating;
            }
        }

        public void WinGame(Game game)
        {
            CurrentRating += CalcRate(true, game.CountRaiting());
            gameHistory.Add(new GameHistory
            {
                UserName = this.UserName,
                IsWin = true,
                CurrentRating = this.CurrentRating,
                GameId = game.GameId,
                GameCount = game.GameCount,
                GameType = game._gameType
            });
        }

        public void LoseGame(Game game)
        {
            CurrentRating += CalcRate(false, game.CountRaiting());
			gameHistory.Add(new GameHistory
			{
				UserName = this.UserName,
				IsWin = false,
				CurrentRating = this.CurrentRating,
				GameId = game.GameId,
				GameCount = game.GameCount,
				GameType = game._gameType
			});
		}

        public void GetStats()
        {
            Console.WriteLine($"Game History for {UserName}:");
            Console.WriteLine("{0,-15} {1,-10} {2,-15} {3,-10} {4, -10} {5, -10}", "UserName", "Result", "CurrentRate", "GameId", "GameCount", "GameType");
            for (int i = 0; i < gameHistory.Count; i++)
            {
                Console.WriteLine("{0,-15} {1,-10} {2,-15} {3,-10} {4, -10} {5, -10}", gameHistory[i].UserName,
                                  gameHistory[i].IsWin ? "Win" : "Loss",
                                  gameHistory[i].CurrentRating,
                                  gameHistory[i].GameId,
                                  gameHistory[i].GameCount,
                                  gameHistory[i].GameType);
            }
        }
    }
}
