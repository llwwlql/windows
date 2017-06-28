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
    public partial class LoginWin : UserControl
    {
        public GroupBox groupBox;

        public LoginWin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox = (GroupBox)this.Parent;
            RegisterWin registerWin = new RegisterWin();
            groupBox.Controls.Clear();
            groupBox.Controls.Add(registerWin);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String username = this.textBox1.Text;
            String pwd = this.textBox2.Text;
            DbClass dbClass = new DbClass();
            string[] result = dbClass.login(username,pwd);
            if (result[0]!=null)
            {
                Form2 form2 = (Form2)this.Parent.Parent;
                Form1 form1 = form2.form1;
                form1.Label1.Hide();
                form1.Label2.Hide();
                form1.UserId = Convert.ToInt32(result[0]);
                form1.Label3.Text = "欢迎  " + result[1];
                form1.Label3.Show();
                form1.Label4.Show();
                form1.w2.cleanNotePad();
                form1.w2.loadNotePad();
                form2.Dispose();
            }
            else
            {
                MessageBox.Show("用户名或密码有误，请重新输入！");
            }

        }
    }
}
