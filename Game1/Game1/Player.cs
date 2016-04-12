using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class Player
    {
        private string username;
        private DateTime activity;
        private bool isAdmin;
        private int coins;
        private DateTime created;
        private string hash;

        public string Username { get { return username; } set { username = value; } }
        public DateTime Activty { get { return activity; } set { activity = value; } }
        public bool IsAdmin { get { return isAdmin; } set { isAdmin = value; } }
        public int Coins { get { return coins; } set { coins = value; } }
        public DateTime Created { get { return created; } set { created = value; } }
        public string Hash { get { return hash; } set { hash = value; } }

        
    }
}
