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
    public partial class RegisterWin : UserControl
    {
        public RegisterWin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            
        }
        private void reset() 
        {
            this.label5.Hide();
            this.label6.Hide();
            this.label7.Hide();
            this.label8.Hide();
        }

        private void RegisterWin_Load(object sender, EventArgs e)
        {
            this.reset();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.reset();
            String username = this.textBox1.Text;
            String nickname = this.textBox2.Text;
            String pwd = this.textBox3.Text;
            String rePwd = this.textBox4.Text;
            bool[] judge = new bool[4];
            for (int i = 0; i < 4; i++)
            {
                judge[i] = true;
            }

            if (pwd.Length < 6 || pwd.Length > 12)
            {//校验密码
                judge[2] = false;
                this.label6.Show();
            }

            if (!pwd.Equals(rePwd))
            {//确认密码
                judge[3] = false;
                this.label5.Show();
            }

            if (nickname.Length < 2 || nickname.Length > 12)
            {//昵称
                judge[1] = false;
                this.label7.Show();
            }
            if (judge[1] && judge[2] && judge[3])
            {
                DbClass dbClass = new DbClass();
                judge[0] = dbClass.register(username, nickname, pwd);
                if (judge[0])
                {//注册成功
                    Form2 form2 = (Form2)this.Parent.Parent;
                    Form1 form1 = form2.form1;
                    form1.Label1.Hide();
                    form1.Label2.Hide();
                    form1.Label3.Text = "欢迎  " + nickname;
                    form1.UserId = dbClass.getUserId(username);
                    form1.Label3.Show();
                    form2.Dispose();
                    MessageBox.Show("注册成功");
                }
                else
                {
                    this.label8.Show();
                }
            }
        }
    }
}
