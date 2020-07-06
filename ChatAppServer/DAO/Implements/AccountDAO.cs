using ChatAppServer.Models;
using ReferenceData.Entity;
using ReferenceData.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatAppServer.DAO.Implements
{
    public class AccountDAO : IAccountDAO
    {
        private ChatAppModels db;

        public AccountDAO()
        {
            this.db = new ChatAppModels();
        }

        public List<ReferenceData.Entity.Account> GetAccountByConversationId(string conversationId)
        {
            List<ReferenceData.Entity.Account> list = null;
            var resultSet = db.Usp_GetMembersOfConversation(conversationId).ToList();
            if(resultSet.Count > 0)
            {
                string imagesFolder = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\Files\Images\";
                list = new List<ReferenceData.Entity.Account>();
                foreach (var a in resultSet)
                {
                    ReferenceData.Entity.Account acc = new ReferenceData.Entity.Account();
                    acc.id = (int)a.id;
                    acc.email = acc.email;
                    acc.password = acc.password;
                    acc.firstName = a.firstName;
                    acc.lastName = a.lastName;
                    acc.birthday = a.birthday;
                    acc.createdAt = a.createdAt;
                    acc.avatar = ChatAppUtils.ConvertFileToByte(imagesFolder + a.avatar);
                    list.Add(acc);
                }
            }
            return list;
        }

        public ReferenceData.Entity.Account GetAccountBySignInInfo(string email, string password)
        {
            var list = db.Usp_GetAccountBySignInInfo(email, password).ToList();
            ReferenceData.Entity.Account acc = null;
            if (list.Count > 0)
            {
                string imagesFolder = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\Files\Images\";
                acc = new ReferenceData.Entity.Account();
                foreach (var u in list)
                {
                    acc.id = u.id;
                    acc.email = u.email;
                    acc.password = u.password;
                    acc.firstName = u.firstName;
                    acc.lastName = u.lastName;
                    acc.avatar = ChatAppUtils.ConvertFileToByte(imagesFolder + u.avatar);
                    acc.birthday = u.birthday;
                    acc.createdAt = u.createdAt;
                }
            }
            return acc;
        }
    }
}
