using PassVault.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PassVault
{
    public static class UtilityService
    {
        public static void OpenNewForm(this Form form, FormType formToOpen)
        {
            if (formToOpen is FormType.MainForm)
            {
                var frm = new frmMain();
                form.Visible = false;
                frm.ShowDialog(form);
                form.Visible = true;
            }

            if (formToOpen is FormType.CreateForm)
            {
                var frm = new frmNew();
                form.Visible = false;
                frm.ShowDialog(form);
                form.Visible = true;
            }

            if (formToOpen is FormType.LoginForm)
            {
                var frm = new frmLogin();
                form.Visible = false;
                frm.ShowDialog(form);
                form.Visible = true;
            }
        }
    }
}
