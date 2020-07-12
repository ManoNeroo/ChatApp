using ChatApp.Views.Components;
using ReferenceData;
using ReferenceData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatApp.Handler
{
    public class SendMessageHandler
    {
        private ChatBox chatBox;
        private delegate void VoidDelegate();
        public SendMessageHandler(ChatBox chatBox)
        {
            this.chatBox = chatBox;
        }
        public void Handle()
        {
            int a = 0;
            string textMsg = chatBox.txtMessage.Text.Trim();
            if (chatBox.Conversation.id == null)
            {
                insertConversation();
                a = 1;
            }
            int b = sendFile();
            if (!textMsg.Equals("") && b != 2)
            {
                if (b == 1)
                {
                    Thread.Sleep(100);
                }
                ReferenceData.Entity.Message textMessage = new ReferenceData.Entity.Message();
                textMessage.id = "" + DateTime.Now.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
                textMessage.conversationId = chatBox.Conversation.id;
                textMessage.senderId = chatBox.Form.User.id;
                textMessage.content = textMsg;
                textMessage.messageType = "TEXT";
                textMessage.firstName = chatBox.Form.User.firstName;
                textMessage.lastName = chatBox.Form.User.lastName;
                textMessage.avatar = chatBox.Form.User.avatar;
                textMessage.createdAt = DateTime.Now;
                textMessage.Conversation = chatBox.Conversation;
                chatBox.Conversation.createdAt = DateTime.Now;
                chatBox.Conversation.messageType = "TEXT";
                chatBox.Conversation.content = textMsg;
                chatBox.AddOutMessage(textMessage);
                chatBox.Form.Client.send(new SocketData("MESSAGE", textMessage));

            }
            if (a == 1)
            {
                chatBox.Form.InsertConversationList(chatBox.Conversation);
                chatBox.Form.DisplayNewConversation();
                chatBox.Form.SelectConversation(chatBox.Conversation);
                chatBox.Form.Client.send(new SocketData("INSERTCONVERSATIONLIST", chatBox.Conversation));
            }
        }
        private int sendFile()
        {
            if (chatBox.FileItem != null)
            {
                if (chatBox.FileItem.File.Length <= 5242880)
                {
                    string[] fileInfo = getFileInfo(chatBox.FileItem.FileName);
                    ReferenceData.Entity.Message fileMessage = new ReferenceData.Entity.Message();
                    fileMessage.id = "" + DateTime.Now.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
                    fileMessage.conversationId = chatBox.Conversation.id;
                    fileMessage.senderId = chatBox.Form.User.id;
                    if (fileInfo[0].Length == chatBox.FileItem.FileName.Length)
                    {
                        fileMessage.content = fileInfo[0] + "_" + fileMessage.id;
                    }
                    else
                    {
                        fileMessage.content = fileInfo[0] + "_" + fileMessage.id + "_." + fileInfo[1];
                    }
                    fileMessage.file = chatBox.FileItem.File;
                    fileMessage.messageType = "FILE";
                    fileMessage.firstName = chatBox.Form.User.firstName;
                    fileMessage.lastName = chatBox.Form.User.lastName;
                    fileMessage.avatar = chatBox.Form.User.avatar;
                    fileMessage.createdAt = DateTime.Now;
                    fileMessage.Conversation = chatBox.Conversation;
                    chatBox.Conversation.createdAt = DateTime.Now;
                    chatBox.Conversation.messageType = "FILE";
                    chatBox.Conversation.content = fileMessage.content;
                    chatBox.AddOutMessage(fileMessage);
                    chatBox.Form.Client.send(new SocketData("MESSAGE", fileMessage));
                    return 1;
                }
                else
                {
                    chatBox.Invoke(new VoidDelegate(chatBox.ShowErrorSendFile), new object[] { });
                    return 2;
                }
            }
            return 0;
        }

        private string[] getFileInfo(string fileName)
        {
            string[] info = new string[] { "", "" };
            string[] arrName = fileName.Split('.');
            if (arrName.Length >= 2)
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
            }
            else
            {
                info[0] = arrName[0];
            }
            return info;
        }
        private void insertConversation()
        {
            chatBox.Conversation.id = "conversation" + DateTime.Now.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
            new InsertConversationHandler(chatBox.Form.Client).Handle(chatBox.Conversation);
            insertParticipant(chatBox.Conversation.memberList, chatBox.Conversation.id);
        }
        private void insertParticipant(List<ReferenceData.Entity.Account> list, string conversationId)
        {
            foreach (var acc in list)
            {
                Participant p = new Participant();
                p.userId = acc.id;
                p.conversationId = conversationId;
                new InsertParticipantHandler(chatBox.Form.Client).Handle(p);
                Thread.Sleep(150);
            }
        }
    }
}
