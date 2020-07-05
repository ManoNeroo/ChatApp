using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceData.Entity
{
    public class Participant
    {
        public int id { get; set; }
        public string conversationId { get; set; }
        public int userId { get; set; }

        public virtual Account Account { get; set; }
        public virtual Conversation Conversation { get; set; }
    }
}
