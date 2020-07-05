using ChatApp.Handler;
using ChatApp.Utils;
using ChatApp.Views.Components;
using Microsoft.VisualBasic.ApplicationServices;
using ReferenceData.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ChatApp.Views
{
    public partial class Frame : Form
    {
        public ChatBox ChatBox { get; set; }
        private Components.Conversation currentConversation = null;
        public ChatClient Client { get; set; }
        public Account User { get; set; }
        public List<Components.Conversation> ConversationList = new List<Components.Conversation>();
        public Frame(ChatClient client, Account user)
        {
            InitializeComponent();
            Client = client;
            User = user;
            initUi();
        }
        private void initUi()
        {
            this.lbUserName.Text = User.firstName + " " + User.lastName;
            this.pbUserAvatar.Image = ClientUtils.ByteToImage(User.avatar);
            this.pnlPages.Controls.Clear();
            WelcomeBox welcomeBox = new WelcomeBox(User);
            this.pnlPages.Controls.Add(welcomeBox);
            welcomeBox.Location = new Point(0, 0);
            Client.startReadResponse(new ReadResponseHandler(this));
        }

        private void Frame_FormClosing(object sender, FormClosingEventArgs e)
        {
            Client.SignOut(User);
        }

        private void Frame_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public void AddConversationList(List<ReferenceData.Entity.Conversation> list)
        {
            pnlConversations.flowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            foreach (var c in list)
            {
                Components.Conversation cvst = new Components.Conversation(c, User);
                pnlConversations.flowLayoutPanel.Controls.Add(cvst);
                cvst.ConversationClick(new OpenConversationHandler(this, cvst).Handle);
                ConversationList.Add(cvst);
            }
            pnlConversations.UpdateUi();
        }
        public void SelectConversation(Components.Conversation cvst)
        {
            if (!cvst.Equals(this.currentConversation))
            {
                if (this.currentConversation == null)
                {
                    this.currentConversation = cvst;
                }
                else
                {
                    this.currentConversation.bg.FillColor = Color.FromArgb(16, 22, 37);
                    this.currentConversation.bg.FillColor2 = Color.FromArgb(16, 22, 37);
                    this.currentConversation = cvst;
                }
                this.currentConversation.bg.FillColor = Color.FromArgb(250, 48, 90);
                this.currentConversation.bg.FillColor2 = Color.FromArgb(128, 36, 206);
                this.pnlPages.Controls.Clear();
                ChatBox = new ChatBox(Client, cvst);
                this.pnlPages.Controls.Add(ChatBox);
                ChatBox.Location = new Point(0, 0);
            }
        }
        public void Online(Account acc)
        {
            foreach (var c in ConversationList)
            {
                if (c.Cvst.memberList.Count == 2)
                {
                    foreach (var mb in c.Cvst.memberList)
                    {
                        if (mb.id == acc.id)
                        {
                            c.btnState.FillColor = Color.Lime;
                        }
                    }
                }
            }
        }
        public void Offline(Account acc)
        {
            foreach (var c in ConversationList)
            {
                if (c.Cvst.memberList.Count == 2)
                {
                    foreach (var mb in c.Cvst.memberList)
                    {
                        if (mb.id == acc.id)
                        {
                            c.btnState.FillColor = Color.LightSteelBlue;
                        }
                    }
                }
            }
        }
    }
}
