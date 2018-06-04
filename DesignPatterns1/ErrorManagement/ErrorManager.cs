using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesignPatterns1.ErrorManagement
{
    public static class ErrorManager
    {
        public static void NotifyUser(string errorCode, string message) {
            DialogResult res = MessageBox.Show(message, errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);  
            if (res == DialogResult.OK) {  
                Application.Restart();
            }  
        }
    }
}
