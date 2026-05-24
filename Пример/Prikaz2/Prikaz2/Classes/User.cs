using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prikaz2.Model;
namespace Prikaz2.Classes
{
    internal class User
    {

        public static Пользователи lastUser;

        public static Пользователи getUser(string login, string password)
        { 
            lastUser=DataBase.context.Пользователи.Where(u=>u.Логин== login && u.Пароль==password).FirstOrDefault();    
            return lastUser;
        }
    }
}
