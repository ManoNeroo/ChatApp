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
            scrollPanel1.flowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            for(int i = 0; i < 3; i++)
            {
                IncomingMessage u = new IncomingMessage();
                OutgoingMessage u2 = new OutgoingMessage();
                UserControl t = new TextBubble();
                UserControl t2 = new TextBubble();
                UserControl t3 = new TextBubble("Ok Ok Ok ok ok ok ok ok ok", TextBubble.msgType.Out);
                UserControl t4 = new TextBubble("Yes yes yes", TextBubble.msgType.Out);
                u.AddBubble(t);
                u.AddBubble(t2);
                u2.AddBubble(t3);
                u2.AddBubble(t4);
                scrollPanel1.flowLayoutPanel.Controls.Add(u);
                scrollPanel1.flowLayoutPanel.Controls.Add(u2);
            }
            scrollPanel1.UpdateUi();
        }
    }
}
