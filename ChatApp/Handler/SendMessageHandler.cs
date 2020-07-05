using ChatApp.Views.Components;
using ReferenceData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            if (chatBox.FileItem != null)
            {
                string[] fileInfo = getFileInfo(chatBox.FileItem.FileName);
                ReferenceData.Entity.Message fileMessage = new ReferenceData.Entity.Message();
                fileMessage.id = "" + DateTime.Now.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
                fileMessage.conversationId = chatBox.ConversationBox.Cvst.id;
                fileMessage.senderId = chatBox.ConversationBox.Acc.id;
                if(fileInfo[0].Length == chatBox.FileItem.FileName.Length)
                {
                    fileMessage.content = fileInfo[0] + "_" + fileMessage.id;
                } else
                {
                    fileMessage.content = fileInfo[0] + "_" + fileMessage.id + "_." + fileInfo[1];
                }
                fileMessage.file = chatBox.FileItem.File;
                fileMessage.messageType = "FILE";
                fileMessage.firstName = chatBox.ConversationBox.Acc.firstName;
                fileMessage.lastName = chatBox.ConversationBox.Acc.lastName;
                fileMessage.avatar = chatBox.ConversationBox.Acc.avatar;
                fileMessage.createdAt = DateTime.Now;
                fileMessage.Conversation = chatBox.ConversationBox.Cvst;
                chatBox.AddOutMessage(fileMessage);
                chatBox.Client.send(new SocketData("MESSAGE", fileMessage));
            }
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

        private string[] getFileInfo(string fileName)
        {
            string[] info = new string[] { "", "" };
            string[] arrName = fileName.Split('.');
            if(arrName.Length >= 2)
            {
                info[1] = arrName[arrName.Length - 1];
                for (int i = 0; i < arrName.Length - 1; i++)
                {
                    if (i == arrName.Length - 2)
                    {
                        info[0] += arrName[i];
                    }
                    else
                    {
                        info[0] += arrName[i] + ".";
                    }
                }
            } else
            {
                info[0] = arrName[0];
            }
            return info;
        }
    }
}
