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
            IOutputHandler window = new Form1();
            CircuitController C = new CircuitController(window);
            Form window2 = (Form)window;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(window2);
        }
    }
}
