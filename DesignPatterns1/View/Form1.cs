using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DesignPatterns1.Interfaces;
using DesignPatterns1.View;

namespace DesignPatterns1
{
    public partial class Form1 : Form, IOutputHandler
    {
        private IInputHandler input;
        //private Dictionary<String, IInputNode> inputNodes = new Dictionary<string, IInputNode>();

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
            //this.inputNodes = input.GetInputNodes();
            //checkedListBox1.Items.Clear();
            //foreach (KeyValuePair<String, IInputNode> entry in inputNodes)
            //{
            //    Boolean b = false;
            //    if (entry.Value.GetName().Equals("INPUT_HIGH"))
            //    {
            //        b = true;
            //    }
            //    this.checkedListBox1.Items.Add(entry.Value.GetLiteralName(),  b);
            //}
           
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
            input.Start();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            input.ShowCircuit();
        }

        public void DoOutput(string name, bool value)
        {
            textBox1.AppendText("The output from " + name + " is " + value + "." + "\n");
        }

        public void SendNodeValues(string name, string type, List<bool> inputs, bool output, long time)
        {
            textBox1.AppendText("Node " + name + "(" + type + ") received inputs ");

            foreach(Boolean B in inputs)
            {
                textBox1.AppendText(B + " ");
            }
            textBox1.AppendText("and sent ouput " + output + " in " + time + " nanoseconds.\n");
        }

        public void Write(string s)
        {
            textBox1.AppendText(s + "\n");
        }

        private void CheckedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> temp = new List<string>
            {
                checkedListBox1.SelectedItem.ToString()
            };
            input.ChangeInputNodes(temp);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            MultipleCircuits multipleCircuits = new MultipleCircuits();
            multipleCircuits.ShowDialog();
        }
    }
}
