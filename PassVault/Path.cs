using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassVault
{
    internal static class Path
    {

        public static string DocumentsRelative = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string DocumentsFullPath(string name) =>  string.Join(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),name);
    }
}
