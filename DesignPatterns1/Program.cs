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
            CircuitController C = new CircuitController();
            IOutputHandler mainWindow = new Form1(C);
            C.SetOutputHandler(mainWindow);
            Form window2 = (Form)mainWindow;
            Application.Run(window2);
        }
    }
}
