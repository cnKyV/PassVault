using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassVault.Enums
{
    public enum FormType
    {
        [Description("frmLogin")]
        LoginForm = 0,
        [Description("frmMain")]
        MainForm = 1,
        [Description("frmNew")]
        CreateForm = 2
    }
}
