using ChatAppServer.SocketServer;
using ReferenceData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatAppServer.Handler
{
    public class InsertConversationListHandler
    {
        private ServerWorker worker;

        public InsertConversationListHandler(ServerWorker worker)
        {
            this.worker = worker;
        }
        public void Handle(SocketData data)
        {
            ReferenceData.Entity.Conversation cvst = (ReferenceData.Entity.Conversation)data.Data;
            foreach (var onl in worker.Server.OnlineList)
            {
                foreach (var mb in cvst.memberList)
                {
                    if (onl.Acc.id == mb.id && mb.id != cvst.creatorId)
                    {
                        onl.Worker.send(new SocketData("INSERTCONVERSATION", cvst));
                    }
                }
            }
        }
    }
}
