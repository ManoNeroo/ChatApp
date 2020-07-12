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
    public class UpdateAccountHandler
    {
        private ServerWorker worker;

        public UpdateAccountHandler(ServerWorker worker)
        {
            this.worker = worker;
        }
        public void Handle(SocketData data)
        {
            ReferenceData.Entity.Account acc = (ReferenceData.Entity.Account)data.Data;
            ReferenceData.Entity.Account account = new AccountDAO().UpdateAccount(acc);
            worker.send(new SocketData("RESULTUPDATE", account));
        }
    }
}
