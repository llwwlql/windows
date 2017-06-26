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
    public partial class windows1 : UserControl
    {
        public windows1()
        {
            InitializeComponent();
        }

        private void windows1_Load(object sender, EventArgs e)
        {
            this.richTextBox1.BackColor = Color.FromArgb(255, 232, 232, 232);
            this.richTextBox1.SelectionCharOffset = -11;
            this.listBox1.Hide();
            this.button1.Hide();
            this.label1.Hide();
            this.label2.Hide();
            pictureBox4.Hide();
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            this.listBox1.Show();
            pictureBox3.Hide();
            pictureBox4.Show();
            label1.Hide();
            label2.Hide();
            button1.Hide();
            listBox1.SelectedItems.Clear();
        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();
            e.Graphics.DrawString(listBox1.Items[e.Index].ToString(), e.Font, new SolidBrush(Color.Black), e.Bounds);
        }
        private void listBox1_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            if (e.Index == 0)
                e.ItemHeight = 10;
        }

        private void richTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.richTextBox1.Text.Equals(""))
            {
                this.listBox1.Hide();
                this.pictureBox3.Show();
                this.pictureBox4.Hide();
            }
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int selectCount = listBox1.SelectedItems.Count;

            if (selectCount > 0)
            {
                listBox1.Hide();
                label1.Show();
                label1.Text = this.listBox1.SelectedItem.ToString();
                label2.Show();
                label2.Text = "翻译结果";
                button1.Show();
                this.pictureBox4.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {//添加到单词本
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox2.Cursor = Cursors.Hand;
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {//查询操作

        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {//更改图片模拟按钮按下效果
            pictureBox2.Image = Properties.Resources.search2;
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {//还原图片
            pictureBox2.Image = Properties.Resources.search;
        }
    }
}
