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
    public class SearchAccountHandle
    {
        private ServerWorker worker;

        public SearchAccountHandle(ServerWorker worker)
        {
            this.worker = worker;
        }
        public void Handle(SocketData data)
        {
            string keyword = (string)data.Data;
            List<Account> list = new AccountDAO().SearchAccount(keyword);
            worker.send(new SocketData("SEARCHRESULT", list));

        }
    }
}
