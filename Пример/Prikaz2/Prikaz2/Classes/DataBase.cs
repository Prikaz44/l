using Prikaz2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prikaz2.Classes
{
    internal class DataBase
    {
        public static MagazinObuviEntities context=new MagazinObuviEntities();
        public DataBase() { }
    }
}
