using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatAppServer.DAO
{
    interface IConversationDAO
    {
        List<ReferenceData.Entity.Conversation> GetConversationListOfAccount(int accId);
        void InsertConversation(ReferenceData.Entity.Conversation c);
    }
}
