using ChatAppServer.SocketServer;
using ReferenceData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatAppServer.Handler
{
    public class SignOutHandler
    {
        private ServerWorker worker;

        public SignOutHandler(ServerWorker worker)
        {
            this.worker = worker;
        }
        public void Handle(SocketData data)
        {
            ReferenceData.Entity.Account acc = (ReferenceData.Entity.Account)data.Data;
            foreach (var onl in worker.Server.OnlineList)
            {
                if(onl.Acc.id != acc.id)
                {
                    onl.Worker.send(new SocketData("OFFLINE", acc));
                }
            }
            worker.Server.OnlineList.Remove(new OnlineAccount(worker, acc));
            worker.Server.RemoveWorker(worker);
        }
    }
}
