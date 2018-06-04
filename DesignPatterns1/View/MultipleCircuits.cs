using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DesignPatterns1.FileManagement;
using DesignPatterns1.Repository;

namespace DesignPatterns1.View
{
    public partial class MultipleCircuits : Form
    {
        private FileParser _parser;
        private Dictionary<String, String> connections = new Dictionary<string, string>();
        public MultipleCircuits(FileParser parser)
        {
            _parser = parser;
            InitializeComponent();
            SetOutputNodes();
            SetInputNodes();
            SetConnectors();
        }
        

        public void SetOutputNodes()
        {
            foreach (String outputNode in CircuitDataRepository.Instance.GetOutputNodesData())
            {
                textBox2.AppendText(outputNode + "\n");
            } 
        }

        public void SetInputNodes()
        {
            foreach (KeyValuePair<String, Boolean> entry in _parser.InputNodes)
            {
                textBox3.AppendText(entry.Key + " (" + entry.Value.ToString() + ")" + "\n");
            }
        }

        public void SetConnectors()
        {
            int locationModifier = 0;
            foreach (KeyValuePair<String, Boolean> entry in _parser.InputNodes)
            {
                connections.Add(entry.Key, "Keep default input");
                Label label = new Label
                {
                    Text = "Connect input " + entry.Key + " to output: ",
                    Location = new Point(0, locationModifier * 50),
                    Width = 200
                };
                ComboBox comboBox = new ComboBox();
                comboBox.Location = new Point(200, locationModifier * 50);
                comboBox.Width = 120;
                comboBox.Items.Add("Keep default input");
                comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox.Name = entry.Key;
                foreach (String outputNode in CircuitDataRepository.Instance.GetOutputNodesData())
                {
                    comboBox.Items.Add(outputNode);
                }
                comboBox.SelectionChangeCommitted += new System.EventHandler(ChangeConnections);
                this.panel1.Controls.Add(label);
                this.panel1.Controls.Add(comboBox);
                locationModifier++;
            }
        }

        private void ChangeConnections(object sender, EventArgs e)
        {
            ComboBox senderComboBox = (ComboBox)sender;
            connections[senderComboBox.Name] = senderComboBox.SelectedItem.ToString();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            _parser.CreateEdges(connections);
            this.Close();
        }
    }
}
