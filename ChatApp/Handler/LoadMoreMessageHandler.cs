using ChatApp.Utils;
using Guna.UI2.WinForms;
using ReferenceData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatApp.Handler
{
    public class LoadMoreMessageHandler
    {
        private ChatClient client;

        public LoadMoreMessageHandler(ChatClient client)
        {
            this.client = client;
        }
        public void Handle(object sender, EventArgs e)
        {
            Guna2VScrollBar vs = (Guna2VScrollBar)sender;
            if(vs.Value == 0)
            {
                client.send(new SocketData("LOADMOREMESSAGE", null));
            }
        }
    }
}
