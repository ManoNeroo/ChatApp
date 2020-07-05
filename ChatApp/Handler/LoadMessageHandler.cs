using ChatApp.Utils;
using ReferenceData;
using ReferenceData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Handler
{
    public class LoadMessageHandler
    {
        private ChatClient client;

        public LoadMessageHandler(ChatClient client)
        {
            this.client = client;
        }
        public void Handle(string conversationId, int offset, int limit)
        {
            client.send(new SocketData("LOADMESSAGE", new ReferenceData.Entity.LoadMessage(conversationId, offset, limit)));
            
        }
    }
}
