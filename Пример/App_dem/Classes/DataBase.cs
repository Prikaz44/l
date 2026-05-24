using App_dem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_dem.Classes
{
    internal class DataBase
    {
        public static DEM2026Entities Сontext { get; } = new DEM2026Entities();
        public DataBase() { }

    }
}
