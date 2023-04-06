using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutorizationDemo
{
    internal class Autorization
    {
        public static Users User { get; set; } = null;
        public static Role GetRole() => User.Role1;

        public static void Login(string login, string password)
        {
            var db = new AutorizationTestEntities();
            User = db.Users.FirstOrDefault(x => x.Login.Equals(login.Trim()) && x.Password.Equals(password.Trim()));
        }

        public static void Logout() => User = null;
    }
}
