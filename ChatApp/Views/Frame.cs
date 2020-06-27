using ChatApp.Views.Components;
using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class Frame : Form
    {
        public Frame()
        {
            InitializeComponent();
            scrollPanel1.flowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            for(int i = 0; i < 20; i++)
            {
                Conversation c = new Conversation();
                scrollPanel1.flowLayoutPanel.Controls.Add(c);
            }
            scrollPanel1.UpdateUi();
            scrollPanel1.vScrollBar.Value = 0;
            
        }
    }
}
