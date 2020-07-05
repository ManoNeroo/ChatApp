using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ChatApp.Utils;

namespace ChatApp.Views.Components
{
    public partial class Conversation : UserControl
    {
        public ReferenceData.Entity.Conversation Cvst { get; set; }
        public ReferenceData.Entity.Account Acc { get; set; }

        public Conversation()
        {
            InitializeComponent();
        }

        public Conversation(ReferenceData.Entity.Conversation conversation, ReferenceData.Entity.Account acc)
        {
            InitializeComponent();
            Cvst = conversation;
            Acc = acc;
            initUi();
        }

        private void initUi()
        {
            unReadMessage.Visible = false;
            this.lbTitle.Text = Cvst.title;
            this.pbAvatar.Image = ClientUtils.ByteToImage(Cvst.avatar);
            DateTime time = (DateTime)Cvst.createdAt;
            this.lbDate.Text = time.ToString("HH:mm dd/MM/yyyy");
            if (Cvst.messageType.Equals("FILE"))
            {
                if (Cvst.senderId != Acc.id)
                {
                    foreach (var u in Cvst.memberList)
                    {
                        if (u.id == Cvst.senderId)
                        {
                            this.lbLatestMessage.Text = u.lastName + "đã gửi một file.";
                        }
                    }
                }
                else
                {
                    this.lbLatestMessage.Text = "Bạn đã gửi một file.";
                }
            }
            else
            {
                if (Cvst.senderId != Acc.id)
                {
                    foreach (var u in Cvst.memberList)
                    {
                        if (u.id == Cvst.senderId)
                        {
                            this.lbLatestMessage.Text = u.lastName + ": " + Cvst.content;
                        }
                    }
                }
                else
                {
                    this.lbLatestMessage.Text = "Bạn: " + Cvst.content;
                }
            }
            if (!Cvst.state)
            {
                this.btnState.FillColor = System.Drawing.Color.LightSteelBlue;
            }
        }
        public void ConversationClick(EventHandler e)
        {
            this.btnState.Click += new System.EventHandler(e);
            this.lbDate.Click += new System.EventHandler(e);
            this.bg.Click += new System.EventHandler(e);
            this.unReadMessage.Click += new System.EventHandler(e);
            this.pbAvatar.Click += new System.EventHandler(e);
            this.lbTitle.Click += new System.EventHandler(e);
            this.lbLatestMessage.Click += new System.EventHandler(e);
        }

        public override bool Equals(object obj)
        {
            if(obj==null)
            {
                return false;
            }
            if (obj.GetType() != typeof(Conversation))
            {
                return false;
            }
            Conversation other = (Conversation)obj;
            if ((this.Cvst.id == null && other.Cvst.id != null) || (this.Cvst.id != null && !this.Cvst.id.Equals(other.Cvst.id)))
            {
                return false;
            }
            return true;
        }
        public override int GetHashCode()
        {
            int hash = 0;
            hash += (Cvst.id != null ? Cvst.id.GetHashCode() : 0);
            return hash;
        }
    }
}
