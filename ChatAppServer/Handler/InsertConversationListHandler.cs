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
            if (cvst.memberList.Count == 2)
            {
                int a = -2;
                int b = -2;
                int i = 0;
                foreach (var onl in worker.Server.OnlineList)
                {
                    if(cvst.memberList[0].id == onl.Acc.id )
                    {
                        a = i;
                    } else if(cvst.memberList[1].id == onl.Acc.id) 
                    {
                        b = i;
                    }
                    i++;
                }
                if(a >= 0 && b >= 0)
                {
                    worker.Server.OnlineList.ToList()[a].Worker.send(new SocketData("ONLINE", cvst.memberList[1]));
                    worker.Server.OnlineList.ToList()[b].Worker.send(new SocketData("ONLINE", cvst.memberList[0]));
                }
            }
        }
    }
}
