using ChatAppServer.DAO.Implements;
using ChatAppServer.Models;
using ChatAppServer.SocketServer;
using ReferenceData;
using ReferenceData.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatAppServer.Handler
{
    public class SignInHandler
    {
        private ServerWorker worker;
        private AccountDAO accountDAO;
        private ConversationDAO conversationDAO;

        public SignInHandler(ServerWorker worker)
        {
            this.worker = worker;
            this.accountDAO = new AccountDAO();
            this.conversationDAO = new ConversationDAO(worker.Server.OnlineList);
        }
        public void Handle(SocketData data)
        {
            ReferenceData.Entity.Account acc = (ReferenceData.Entity.Account)data.Data;
            ReferenceData.Entity.Account user = accountDAO.GetAccountBySignInInfo(acc.email, acc.password);
            SocketData response = new SocketData("ACCOUNT", user);
            worker.send(response);
            if (user != null)
            {
                worker.Server.OnlineList.Add(new OnlineAccount(worker, user));
                sendConversationList(worker, user);
            }
        }

        private void sendConversationList(ServerWorker worker, ReferenceData.Entity.Account user)
        {
            List<ReferenceData.Entity.Conversation> list = conversationDAO.GetConversationListOfAccount(user.id);
            SocketData response = new SocketData("CONVERSATIONLIST", list);
            worker.send(response);
            foreach(var onl in worker.Server.OnlineList)
            {
               if(onl.Acc.id != user.id)
                {
                    foreach (var c in list)
                    {
                        if (c.memberList.Count == 2)
                        {
                            onl.Worker.send(new SocketData("ONLINE", user));
                        }
                    }
                }
            }
        }
        
    }
}
