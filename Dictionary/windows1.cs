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
                e.ItemHeight = 35;
        }

        private void richTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.richTextBox1.Text.Equals(""))
            {
                this.listBox1.Hide();
                this.pictureBox3.Show();
                this.pictureBox4.Hide();
            }
            else
            {
                DbClass dbClass = new DbClass();
                string english = this.richTextBox1.Text;
                String[] result = dbClass.getLikeResultSet(english);
                for (int i = 0; i < 5; i++)
                {
                    this.listBox1.Items[i] = result[i+1];
                }
                listBox1.SelectedItems.Clear();
            }
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int selectCount = listBox1.SelectedItems.Count;

            if (selectCount > 0)
            {
                string english = this.listBox1.SelectedItem.ToString();
                this.richTextBox1.Text = english;
                this.pictureBox2_Click(sender, e);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {//添加到单词本
            DbClass dbClass = new DbClass();
            string english = this.label1.Text;
            string chinese = this.label2.Text;
            bool judge = dbClass.getInsert(english,chinese);
            if (judge)
            {
                MessageBox.Show("单词保存成功！");
            }
            else
            {
                MessageBox.Show("单词本中已存在！");
            }
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DbClass dbClass = new DbClass();
            string english = this.richTextBox1.Text;
            String[] result = dbClass.getResultSet(english);
            this.label2.Show();
            this.listBox1.Hide();
            if (result[0].Equals(""))
            {
                this.label2.Text = "输入单词错误，没有查询结果！";
            }else
            {
                this.label1.Show();
                this.button1.Show();
                this.label1.Text = result[0];
                this.label2.Text = result[1];
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
