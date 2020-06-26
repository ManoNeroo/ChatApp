using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ChatApp.Views
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = new Button();
            btn.Size = new Size(200, 300);
            btn.Text = "Button";
            scrollPanel1.flowLayoutPanel.Controls.Add(btn);
            scrollPanel1.UpdateUi();
        }
        private void vScrollBar_ValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}
