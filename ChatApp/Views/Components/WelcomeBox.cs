using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReferenceData.Entity;

namespace ChatApp.Views.Components
{
    public partial class WelcomeBox : UserControl
    {
        private Account user;

        public WelcomeBox(Account user)
        {
            InitializeComponent();
            this.user = user;
            genarate();
        }

        private void genarate()
        {
            this.lbWelcome.Text = "Xin chào " + user.lastName;
        }
        public void BtnSonversationClick(EventHandler e)
        {
            this.btnConversation.Click += new System.EventHandler(e);
        }
    }
}
