using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dictionary
{
    public partial class Form1 : Form
    {
        public windows1 w1;
        public windows2 w2;
        public windows3 w3;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            w1 = new windows1();
            w2 = new windows2();
            w3 = new windows3();
            this.button1_Click(sender,e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            w1.Show();
            groupBox1.Controls.Clear();
            groupBox1.Controls.Add(w1);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            w3.Show();
            groupBox1.Controls.Clear();
            groupBox1.Controls.Add(w3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            w2.Show();
            groupBox1.Controls.Clear();
            groupBox1.Controls.Add(w2);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
