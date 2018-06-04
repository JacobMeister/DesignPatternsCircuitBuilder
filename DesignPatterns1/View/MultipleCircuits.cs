using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DesignPatterns1.Repository;

namespace DesignPatterns1.View
{
    public partial class MultipleCircuits : Form
    {
        public MultipleCircuits()
        {
            InitializeComponent();
            SetOutputNodes();
        }

        public void SetOutputNodes()
        {
            foreach (String item in CircuitDataRepository.Instance.GetOutputNodesData())
            {
                textBox2.AppendText(item + "\n");
            } 
        }

        public void SetInputNodes()
        {
            ComboBox c = new ComboBox();
            listBox1.Controls.Add(c);
        }
        

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
