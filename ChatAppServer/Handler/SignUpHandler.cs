using ChatAppServer.Models;
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
    public class SignUpHandler
    {
        private ServerWorker worker;
        private ChatAppModels db;

        public SignUpHandler(ServerWorker worker)
        {
            this.worker = worker;
            this.db = new ChatAppModels();
        }
        public void Handle(SocketData data)
        {
            ReferenceData.Entity.Account account = (ReferenceData.Entity.Account)data.Data;
            int result = 1;
            try
            {
                db.Usp_InsertAccount(account.email, account.password, account.firstName, account.lastName);
            } catch(Exception e)
            {
                Console.WriteLine(e);
                result = 0;
            }
            SocketData dataRes;
            if (result == 1)
            {
                dataRes = new SocketData("OK", true);
            } else
            {
                dataRes = new SocketData("FAIL", false);
            }
            worker.send(dataRes);
        }
    }
}
