using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImoveisPrecoDesktopApp.db
{
    internal static class DB
    {
        private static string connectionStringImoveisDB = "Data Source=C:\\Vitor\\TI\\ImoveisPrecoDesktopApp\\db\\imoveisDB.db;";

        public static string ConnectionStringImoveisDB { get => connectionStringImoveisDB; }
    }
}
