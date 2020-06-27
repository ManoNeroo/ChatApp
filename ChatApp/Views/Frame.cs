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
            pnlConversations.flowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            for(int i = 0; i < 20; i++)
            {
                Conversation c = new Conversation();
                pnlConversations.flowLayoutPanel.Controls.Add(c);
            }
            pnlConversations.UpdateUi();
            pnlConversations.vScrollBar.Value = 0;
            
        }
    }
}
