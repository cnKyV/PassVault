using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassVault
{
    internal class PreloadValue
    {
        public CryptoConfig CryptoConfig { get; set; }
        public FileConfig FileConfig { get; set; }
    }

    internal class CryptoConfig
    {
        public string NON_SECRET_PAYLOAD { get; set; }
        public string SECRET_MESSAGE { get; set; }
    }
    internal class FileConfig
    {

    }
}
