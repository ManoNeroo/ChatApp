using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceData.Entity
{
    [Serializable]
    public class LoadMessage
    {
        public string ConversationId { get; set; }
        public int Offset { get; set; }
        public int Limit { get; set; }
        public LoadMessage(string conversationId, int offset, int limit)
        {
            ConversationId = conversationId;
            Offset = offset;
            Limit = limit;
        }
    }
}
