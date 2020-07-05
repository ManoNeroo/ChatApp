using ChatAppServer.DAO.Implements;
using ChatAppServer.SocketServer;
using ReferenceData;
using ReferenceData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatAppServer.Handler
{
    public class LoadMessageHandler
    {
        private ServerWorker worker;

        public LoadMessageHandler(ServerWorker worker)
        {
            this.worker = worker;
        }
        public void Handle(SocketData data)
        {
            LoadMessage d = (LoadMessage)data.Data;
            string conversationId = d.ConversationId;
            int offset = d.Offset;
            int limit = d.Limit;
            List<ReferenceData.Entity.Message> list = new MessageDAO().GetMessagesByConversationId(conversationId, offset, limit);
            worker.send(new SocketData("MESSAGELIST", list));
        }
    }
}
