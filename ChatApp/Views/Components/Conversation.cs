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
            InitLatestMessage();
            if (!Cvst.state)
            {
                this.btnState.FillColor = System.Drawing.Color.LightSteelBlue;
            }
        }
        public void InitLatestMessage()
        {
            if (this.Cvst.messageType.Equals("FILE"))
            {
                if (this.Cvst.senderId != this.Acc.id)
                {
                    foreach (var u in this.Cvst.memberList)
                    {
                        if (u.id == this.Cvst.senderId)
                        {
                            string[] arr = this.Cvst.content.Split('_');
                            string fex = arr[arr.Length - 1];
                            if (fex.Equals(".jpg") || fex.Equals(".png") || fex.Equals(".jpeg") || fex.Equals(".gif"))
                            {
                                this.lbLatestMessage.Text = u.lastName + " đã gửi một ảnh.";
                            }
                            else
                            {
                                this.lbLatestMessage.Text = u.lastName + " đã gửi một file.";
                            }
                        }
                    }
                }
                else
                {
                    string[] arr = this.Cvst.content.Split('_');
                    string fex = arr[arr.Length - 1];
                    if (fex.Equals(".jpg") || fex.Equals(".png") || fex.Equals(".jpeg") || fex.Equals(".gif"))
                    {
                        this.lbLatestMessage.Text = "Bạn đã gửi một ảnh.";
                    } else
                    {
                        this.lbLatestMessage.Text = "Bạn đã gửi một file.";
                    }
                }
            }
            else
            {
                if (this.Cvst.senderId != this.Acc.id)
                {
                    foreach (var u in this.Cvst.memberList)
                    {
                        if (u.id == this.Cvst.senderId)
                        {
                            this.lbLatestMessage.Text = u.lastName + ": " + this.Cvst.content;
                        }
                    }
                }
                else
                {
                    this.lbLatestMessage.Text = "Bạn: " + this.Cvst.content;
                }
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
