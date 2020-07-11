using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatAppServer.DAO
{
    public interface IMessageDAO
    {
        List<ReferenceData.Entity.Message> GetMessagesByConversationId(string conversationId, int offset, int limit);
        List<ReferenceData.Entity.Message> GetAllMessagesByConversationId(string conversationId);
        void InsertMessage(ReferenceData.Entity.Message message);
    }
}
