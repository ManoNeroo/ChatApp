using ChatAppServer.DAO.Implements;
using ChatAppServer.SocketServer;
using ReferenceData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatAppServer.Handler
{
    public class InsertConversationHandler
    {
        private ServerWorker worker;

        public InsertConversationHandler(ServerWorker worker)
        {
            this.worker = worker;
        }
        public void Handle(SocketData data)
        {
            ReferenceData.Entity.Conversation cvst = (ReferenceData.Entity.Conversation)data.Data;
            new ConversationDAO().InsertConversation(cvst);
            
        }
    }
}
