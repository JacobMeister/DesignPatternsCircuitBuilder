using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DesignPatterns1.FileManagement;
using DesignPatterns1.Interfaces;
using DesignPatterns1.Repository;
using DesignPatterns1.View;

namespace DesignPatterns1
{
    public partial class Form1 : Form, IOutputHandler
    {
        private IInputHandler _input;
        private Dictionary<String, Boolean> _entryNodes = new Dictionary<string, Boolean>();

        public Form1(IInputHandler input)
        {
            InitializeComponent();
            this._input = input;
           
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            CircuitDataRepository.Instance.ClearData();
            textBox1.Clear();
            string path = "";
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                path = file.FileName;
                _input.InitiateCircuit(path);
            }
            SetCheckList();
        }

        public void SetCheckList()
        {
            this._entryNodes = CircuitDataRepository.Instance.GetInputNodesData();
            checkedListBox1.Items.Clear();
            foreach (KeyValuePair<String, Boolean> entry in _entryNodes)
            {
                Boolean b = false;
                if (entry.Value)
                {
                    b = true;
                }
                this.checkedListBox1.Items.Add(entry.Key, b);
            }
        }

        public void EnableButtons()
        {
            this.button5.Enabled = true;
            this.button6.Enabled = true;
            this.button7.Enabled = true;
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
            _input.Start();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            _input.ShowCircuit();
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
            String nodeName = checkedListBox1.SelectedItem.ToString();
            Boolean value = this._entryNodes[nodeName];
            this._entryNodes[nodeName] = !value;
            _input.ChangeInputNode(nodeName, !value);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            string path = "";
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                path = file.FileName;
                _input.InitiateCircuit(path);
            }
            
        }

        public void OpenMultipleCircuits(FileParser parser)
        {
            MultipleCircuits multipleCircuits = new MultipleCircuits();
            multipleCircuits.ShowDialog();
        }
    }
}
