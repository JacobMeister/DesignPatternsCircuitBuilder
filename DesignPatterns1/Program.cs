using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DesignPatterns1.Controller;
using DesignPatterns1.Interfaces;

namespace DesignPatterns1
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            CircuitDirector C = new CircuitDirector();
            IOutputHandler mainWindow = new Form1(C);
            C.SetOutputHandler(mainWindow);
            Form window = (Form)mainWindow;
            Application.Run(window);
        }
    }
}
