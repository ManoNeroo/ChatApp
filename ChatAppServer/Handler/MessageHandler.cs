using ChatAppServer.DAO.Implements;
using ChatAppServer.SocketServer;
using ReferenceData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatAppServer.Handler
{
    public class MessageHandler
    {
        private ServerWorker worker;
        private MessageDAO messageDAO;

        public MessageHandler(ServerWorker worker)
        {
            this.worker = worker;
            this.messageDAO = new MessageDAO();
        }
        public void Handle(SocketData data)
        {
            ReferenceData.Entity.Message message = (ReferenceData.Entity.Message)data.Data;
            messageDAO.InsertMessage(message);
            foreach(var onl in worker.Server.OnlineList)
            {
                foreach(var u in message.Conversation.memberList)
                {
                    if(u.id == onl.Acc.id && u.id != message.senderId)
                    {
                        onl.Worker.send(new SocketData("MESSAGE", message));
                    }
                }
            }
        }
    }
}
