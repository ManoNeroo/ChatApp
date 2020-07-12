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
    public class UpdateAccountHandler
    {
        private ChatClient client;

        public UpdateAccountHandler(ChatClient client)
        {
            this.client = client;
        }
        public void Handle(Account acc)
        {
            client.send(new SocketData("UPDATEACCOUNT", acc));
        }
    }
}
