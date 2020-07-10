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
    public class InsertParticipantHandler
    {
        private ChatClient client;

        public InsertParticipantHandler(ChatClient client)
        {
            this.client = client;
        }
        public void Handle(Participant p)
        {
            client.send(new SocketData("INSERTPARTICIPANT", p));
        }
    }
}
