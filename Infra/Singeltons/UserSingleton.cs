using Infra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Singeltons
{
    public class UserSingleton
    {
        private static UserSingleton instance;
        private static  object _lock = new object();
        public string Token { get; set; }
        public User User { get; set; }  = new User();
        public bool IsLoggedIn { get; set; }
        public UserSingleton()
        {
        }

        public static UserSingleton Instance
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new UserSingleton();
                    }
                    return instance;
                }
            }
        }
    }
}
