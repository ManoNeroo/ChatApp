using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ChatApp.Views.Components
{
    public partial class OutMessage : UserControl
    {
        public OutMessage()
        {
            InitializeComponent();
        }

        public OutMessage(string msg, string t)
        {
            InitializeComponent();
            message.Text = msg;
            time.Text = t;
            setHeight();
        }
        void setHeight()
        {
            Graphics g = CreateGraphics();
            SizeF size = g.MeasureString(message.Text, message.Font, message.Width);
            message.Height = int.Parse(Math.Round(size.Height + 6, 0).ToString());
            bubble.Width = int.Parse(Math.Round(size.Width + 32, 0).ToString());
            bubble.Height = message.Height + 12;
            this.Height = time.Height + bubble.Height + 12;

        }
    }
}
