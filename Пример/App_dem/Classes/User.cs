using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using App_dem.Classes;
using App_dem.Model;

namespace App_dem.Classes
{
    internal class User
    {
        /*
         * логика кода:
        Запрашивает всех пользователей из базы данных.
        Фильтрует список, оставляя только тех, чей логин и пароль совпадают с переданными параметрами.
        Возвращает первого найденного пользователя или null, если подходящего пользователя не найдено.
        */
        public static Пользователи lastUser; //последний авторизовавшийся пользователь

        public static Пользователи getUser(string login, string password) {
            lastUser = DataBase.Сontext.Пользователи.Where(u => u.Логин == login && u.Пароль == password).FirstOrDefault(); 
            return lastUser;
        }
    }
}
