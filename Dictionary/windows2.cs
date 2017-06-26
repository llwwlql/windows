using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dictionary
{
    public partial class windows2 : UserControl
    {
        public windows2()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Panel panel = new Panel();
            panel.Width = 471;
            panel.Height = 119;
            panel.Margin = new Padding(3,0,0,10);
            panel.BackColor = Color.FromArgb(255, 228, 228, 228);

            //英文的label
            Label english = new Label();
            english.Text = "abandon";
            english.Font = new System.Drawing.Font("宋体", 26);
            english.Height = 35;
            english.Width = 300;
            english.Location = new Point(38, 21);
            panel.Controls.Add(english);

            //中文翻译的label
            Label chinese = new Label();
            chinese.Text = "v.抛弃，放弃";
            chinese.Font = new System.Drawing.Font("宋体", 15);
            chinese.Location = new Point(40, 70);
            chinese.Height = 21;
            chinese.Width = 137;
            panel.Controls.Add(chinese);

            //添加删除按钮
            Button button = new Button();
            button.Text = "";
            button.Location = new Point(405,35);
            button.Height = 21;
            button.Width = 24;
            button.Image = Properties.Resources.del;
            button.Click += new EventHandler(but_Click);
            panel.Controls.Add(button);
            flowLayoutPanel1.Controls.Add(panel);
            //flowLayoutPanel1.SetFlowBreak(picBox,true);
        }

        private void but_Click(object sender, EventArgs e)
        {
            ((Button)sender).Parent.Dispose();
        }

    }
}
