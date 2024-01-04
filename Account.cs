using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alien_Invaders
{
    public class Account
    {
        private static int Id = 1;
        private int rating;
        private int id;
        private string userName;
        private string password;
        private int startRating = 0;
        private List<GameResult> history;

        public int Rating
        {
            get { return rating; }
            private set { rating = value; }
        }

        public int ID
        {
            get { return id; }
            set => id = value;
        }

        public string UserName
        {
            get { return userName; }
            set => userName = value;
        }

        public string Password
        {
            get { return password; }
            set => password = value;
        }

        public List<GameResult> History
        {
            get { return history; }
            private set { history = value; }
        }

        public Account(string username, string password)
        {
            History = new List<GameResult>();
            Rating = startRating;
            UserName = username;
            Password = password;
            ID = Id++;
        }

        public void WinGame(Account account)
        {
            account.Rating++;
        }

        public void LoseGame(Account account)
        {
            if (account.Rating > 0)
            {
                account.Rating--;
            }
        }
    }
}