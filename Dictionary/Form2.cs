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
    public partial class Form2 : Form
    {
        public LoginWin loginWin;
        public RegisterWin registerWin;
        public GroupBox groupBox;
        public Form1 form1;

        public Form2(Form1 form1)
        {
            this.form1 = form1;
            InitializeComponent();
            loginWin = new LoginWin();
            registerWin = new RegisterWin();
            groupBox = this.groupBox1;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }
    }
}
