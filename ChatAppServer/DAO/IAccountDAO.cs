using ChatAppServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatAppServer.DAO
{
    public interface IAccountDAO
    {
        ReferenceData.Entity.Account GetAccountBySignInInfo(string email, string password);
        List<ReferenceData.Entity.Account> GetAccountByConversationId(string conversationId);
        ReferenceData.Entity.Account UpdateAccount(ReferenceData.Entity.Account acc);

        List<ReferenceData.Entity.Account> SearchAccount(string keyword);
    }
}
