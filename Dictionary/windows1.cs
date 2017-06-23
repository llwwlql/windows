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
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            pictureBox3.Hide();
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
    }
}
