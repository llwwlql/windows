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
    public partial class windows3 : UserControl
    {
        public Form1 form1;
        public windows3(Form1 from1)
        {
            this.form1 = from1;
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void windows3_Load(object sender, EventArgs e)
        {
            DbClass dbClass = new DbClass();
            News news = dbClass.getNews();
            this.label1.Text = news.Title;
            this.label2.Text = news.Time;
            //设置文本内容
            string content = "";
            content += news.Content;
            this.textBox1.Text = content;
            int length = this.textBox1.Lines.Length;
            this.textBox1.Height = (int)(length * 23 * 1.5);
            this.pictureBox1.Image = Properties.Resources.每日一文3;
            //设置标题居中
            this.label1.Left = (panel1.Width - label1.Width) / 2 - 5;
            this.label2.Left = (panel1.Width - label2.Width) / 2 - 5;

            //设置图片
            string url = news.Image;
            System.Net.WebRequest webreq = System.Net.WebRequest.Create(url);
            System.Net.WebResponse webres = webreq.GetResponse();
            using (System.IO.Stream stream = webres.GetResponseStream())
            {
                pictureBox1.Image = Image.FromStream(stream);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}