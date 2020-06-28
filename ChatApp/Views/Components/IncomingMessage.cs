using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;

namespace ChatApp.Views.Components
{
    public partial class IncomingMessage : UserControl
    {
        public List<UserControl> UList { get; set; }
        public String Time { get; set; }
        public IncomingMessage()
        {
            InitializeComponent();
            UList = new List<UserControl>();
        }
        private void setHeight()
        {
            bubbleArea.Height = bubbleArea.PreferredSize.Height;
            this.Height = time.Height + bubbleArea.Height + 12;
        }
        public void AddBubble(UserControl userControl) 
        {
            UList.Add(userControl);
            this.bubbleArea.Controls.Add(userControl);
            setHeight();
        }
        public void RemoveBubble(UserControl userControl)
        {
            UList.Remove(userControl);
            this.bubbleArea.Controls.Remove(userControl);
            setHeight();
            if (UList.Count == 0)
            {
                this.Dispose();
            }
        }
    }
}
