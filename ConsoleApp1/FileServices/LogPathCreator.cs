using ConsoleApp1.FileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.FileServices
{
    internal static class LogPathCreator
    {
        public static readonly string PathToTheLogs;
        public static readonly string PathToTheBackups;

        static LogPathCreator()
        {
            PathToTheLogs = Directory.GetCurrentDirectory() + "\\" + "Logs";
            PathToTheBackups = Directory.GetCurrentDirectory() + "\\" + "Backups";
        }
        public static string GetPathToTheLogWithTheName(string name)
        {
            return PathToTheLogs + "\\" + name + ".txt";
        }
    }
}
