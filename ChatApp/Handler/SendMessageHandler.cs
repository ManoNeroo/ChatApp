using ChatApp.Views.Components;
using ReferenceData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Handler
{
    public class SendMessageHandler
    {
        private ChatBox chatBox;

        public SendMessageHandler(ChatBox chatBox)
        {
            this.chatBox = chatBox;
        }
        public void Handle()
        {
            string textMsg = chatBox.txtMessage.Text.Trim();
            if(!textMsg.Equals(""))
            {
                ReferenceData.Entity.Message textMessage = new ReferenceData.Entity.Message();
                textMessage.id = "" + DateTime.Now.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
                textMessage.conversationId = chatBox.ConversationBox.Cvst.id;
                textMessage.senderId = chatBox.ConversationBox.Acc.id;
                textMessage.content = textMsg;
                textMessage.messageType = "TEXT";
                textMessage.firstName = chatBox.ConversationBox.Acc.firstName;
                textMessage.lastName = chatBox.ConversationBox.Acc.lastName;
                textMessage.avatar = chatBox.ConversationBox.Acc.avatar;
                textMessage.createdAt = DateTime.Now;
                textMessage.Conversation = chatBox.ConversationBox.Cvst;
                chatBox.AddOutMessage(textMessage);
                chatBox.Client.send(new SocketData("MESSAGE", textMessage));
            }
        }
    }
}
