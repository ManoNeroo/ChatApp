using ChatApp.Utils;
using ChatApp.Views.Components;
using ReferenceData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Handler
{
    public class InsertConversationHandler
    {
        private ChatClient client;

        public InsertConversationHandler(ChatClient client)
        {
            this.client = client;
        }
        public void Handle(ReferenceData.Entity.Conversation cvst)
        {
            client.send(new SocketData("INSERTCONVERSATION", cvst));
        }
    }
}
