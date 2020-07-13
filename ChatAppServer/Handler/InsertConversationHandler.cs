using ChatAppServer.DAO.Implements;
using ChatAppServer.SocketServer;
using ReferenceData;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatAppServer.Handler
{
    public class InsertConversationHandler
    {
        private ServerWorker worker;

        public InsertConversationHandler(ServerWorker worker)
        {
            this.worker = worker;
        }
        public void Handle(SocketData data)
        {
            ReferenceData.Entity.Conversation cvst = (ReferenceData.Entity.Conversation)data.Data;
            if (cvst.avatar2 != null && cvst.avatar != null)
            {
                string imagesFolder = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\Files\Images\";
                string[] info = getFileInfo(cvst.avatar2);
                cvst.avatar2 = info[0] + DateTime.Now.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds + "." + info[1];
                File.WriteAllBytes(imagesFolder + cvst.avatar2, cvst.avatar);
            }
            new ConversationDAO().InsertConversation(cvst);

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
    }
}
