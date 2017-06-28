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
        public Form2 form2;
        private int userId;

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }


        public Form1()
        {
            InitializeComponent();
        }

        public long ToUnixTime(DateTime date)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return Convert.ToInt64((date.ToUniversalTime() - epoch).TotalMilliseconds);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            w1 = new windows1(this);
            w2 = new windows2(this);
            w3 = new windows3(this);
            this.label3.Width = 150;
            this.userId = (int)(ToUnixTime(DateTime.Now) % 1000000000);
            this.label3.Hide();
            this.label4.Hide();
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
        {//注册
            form2 = new Form2(this);
            RegisterWin registerWin = form2.registerWin;
            form2.Show();
            registerWin.Show();
            form2.groupBox.Controls.Clear();
            form2.groupBox.Controls.Add(registerWin);
        }

        private void label2_Click(object sender, EventArgs e)
        {//登录
            form2 = new Form2(this);
            LoginWin loginWin = form2.loginWin;
            form2.Show();
            loginWin.Show();
            form2.groupBox.Controls.Clear();
            form2.groupBox.Controls.Add(loginWin);
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            this.label2.Cursor = Cursors.Hand;
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            this.label1.Cursor = Cursors.Hand;
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            this.label2.Cursor = Cursors.Hand;
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            this.label1.Cursor = Cursors.Hand;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.userId = (int)(ToUnixTime(DateTime.Now) % 1000000000);
            this.w2.cleanNotePad();
            this.label1.Show();
            this.label2.Show();
            this.label3.Hide();
            this.label4.Hide();
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            this.label4.Cursor = Cursors.Hand;
        }

        private void label4_MouseHover(object sender, EventArgs e)
        {
            this.label4.Cursor = Cursors.Hand;
        }
    }
}
