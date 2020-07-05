using ChatAppServer.Models;
using ChatAppServer.Utils;
using ReferenceData.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatAppServer.DAO.Implements
{
    public class MessageDAO : IMessageDAO
    {
        private ChatAppModels db;

        public MessageDAO()
        {
            this.db = new ChatAppModels();
        }
        public List<ReferenceData.Entity.Message> GetMessagesByConversationId(string conversationId, int offset, int limit)
        {
            string imagesFolder = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\Files\Images\";
            var resultSet = db.Usp_GetMessagesByConversationId(conversationId, offset, limit).ToList();
            List<ReferenceData.Entity.Message> list = null;
            if (resultSet.Count > 0)
            {
                list = new List<ReferenceData.Entity.Message>();
                foreach(var m in resultSet)
                {
                    ReferenceData.Entity.Message message = new ReferenceData.Entity.Message();
                    message.id = m.id;
                    message.conversationId = m.conversationId;
                    message.senderId = m.senderId;
                    message.content = m.content;
                    message.messageType = m.messageType;
                    message.createdAt = m.createdAt;
                    message.firstName = m.firstName;
                    message.lastName = m.lastName;
                    message.avatar = ServerUtils.ConvertFileToByte(imagesFolder + m.avatar);
                    list.Add(message);
                }
            }
            return list;
        }

        public void InsertMessage(ReferenceData.Entity.Message message)
        {
            db.Usp_InsertMessage(message.id, message.conversationId, message.senderId, message.content, message.messageType, message.createdAt);
        }
    }
}
