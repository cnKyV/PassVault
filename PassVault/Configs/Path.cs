using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassVault.Configs
{
    internal static class Path
    {

        public static string DocumentsRelative = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string DocumentsFullPath(string name) => Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + name + "_vault.json";
        public static string DemoValues
        {
            get
            {
                var relativePath = Environment.CurrentDirectory.ToString();
                var fullPath = relativePath + "\\valueLoader.json";
                return fullPath;
            }
        }
    }
}
