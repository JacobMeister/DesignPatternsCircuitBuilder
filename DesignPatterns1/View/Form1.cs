using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DesignPatterns1.Interfaces;

namespace DesignPatterns1
{
    public partial class Form1 : Form, IOutputHandler
    {
        private IInputHandler input;
        public Form1(IInputHandler input)
        {
            InitializeComponent();
            this.input = input;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            string path = "";
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                path = file.FileName;
                input.SetCircuit(path);
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button8_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void Button6_Click(object sender, EventArgs e)
        {

        }

        private void Button7_Click(object sender, EventArgs e)
        {

        }

        public void DoOutput(string name, bool value)
        {
            throw new NotImplementedException();
        }

        public void SendNodeValues(string name, string type, List<bool> inputs, bool output, long time)
        {
            throw new NotImplementedException();
        }

        public void Write(string s)
        {
            throw new NotImplementedException();
        }
    }
}
