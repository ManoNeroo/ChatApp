using ChatApp.Handler;
using ChatApp.Utils;
using ChatApp.Views.Components;
using Microsoft.VisualBasic.ApplicationServices;
using ReferenceData.Entity;
using ReferenceData.Utils;
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
        public ChatBox ChatBox { get; set; } = null;
        private Components.Conversation currentConversation = null;
        public ChatClient Client { get; set; }
        public Account User { get; set; }
        public List<Components.Conversation> ConversationList = new List<Components.Conversation>();
        public Frame(ChatClient client, Account user)
        {
            InitializeComponent();
            Client = client;
            User = user;
        }

        private void Frame_FormClosing(object sender, FormClosingEventArgs e)
        {
            Client.SignOut(User);
        }

        private void Frame_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        public void ResetCurrentConversation() { 
            if(currentConversation!= null)
            {
                currentConversation.bg.FillColor = Color.FromArgb(16, 22, 37);
                currentConversation.bg.FillColor2 = Color.FromArgb(16, 22, 37);
                currentConversation = null;
            }
        }
        public void DisplaySearchResult(List<Account> list)
        {
            pnlConversations.flowLayoutPanel.Controls.Clear();
            foreach(var acc in list)
            {
                if(acc.id != User.id)
                {
                    SearchResult searchResult = new SearchResult(acc);
                    pnlConversations.flowLayoutPanel.Controls.Add(searchResult);
                    searchResult.SearchResultClick(new SearchResultClickHandler(this,acc).Handle);
                }
            }
            pnlConversations.UpdateUi();
        }
        
        public void DisplayConversationList()
        {
            txtSearchAccount.Text = "";
            pnlConversations.flowLayoutPanel.Controls.Clear();
            foreach(var cvst in ConversationList)
            {
                pnlConversations.flowLayoutPanel.Controls.Add(cvst);
                cvst.ConversationClick(new OpenConversationHandler(this, cvst).Handle);
            }
            pnlConversations.UpdateUi();
        }
        public void AddConversationList(List<ReferenceData.Entity.Conversation> list)
        {
            foreach (var c in list)
            {
                Components.Conversation cvst = new Components.Conversation(c, User);
                pnlConversations.flowLayoutPanel.Controls.Add(cvst);
                cvst.ConversationClick(new OpenConversationHandler(this, cvst).Handle);
                ConversationList.Add(cvst);
            }
            pnlConversations.UpdateUi();
        }
        public void InsertConversationList(ReferenceData.Entity.Conversation cv)
        {
            Components.Conversation cvst = new Components.Conversation(cv, User);
            cvst.ConversationClick(new OpenConversationHandler(this, cvst).Handle);
            ConversationList.Add(cvst);
        }
        public void AddChatBox(ReferenceData.Entity.Conversation cvst)
        {
            this.pnlPages.Controls.Clear();
            ChatBox = new ChatBox(this, cvst);
            this.pnlPages.Controls.Add(ChatBox);
            ChatBox.Location = new Point(0, 0);
        }
        public void SelectConversation(ReferenceData.Entity.Conversation cv)
        {
            foreach(var cvst in ConversationList)
            {
                if (cvst.Cvst.Equals(cv))
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
                        ChatBox = new ChatBox(this, cvst.Cvst);
                        this.pnlPages.Controls.Add(ChatBox);
                        ChatBox.Location = new Point(0, 0);
                    }
                    break;
                }
            }
            
        }
        public void InitLatestMessage(Components.Conversation cvst, ReferenceData.Entity.Message message)
        {
            if (message.messageType.Equals("FILE"))
            {
                string[] arr = message.content.Split('_');
                string fex = arr[arr.Length - 1];
                if (fex.Equals(".jpg") || fex.Equals(".png") || fex.Equals(".jpeg") || fex.Equals(".gif"))
                {
                    cvst.lbLatestMessage.Text = (message.senderId != cvst.Acc.id ? message.lastName : "Bạn") + " đã gửi một ảnh.";
                }
                else
                {
                    cvst.lbLatestMessage.Text = (message.senderId != cvst.Acc.id ? message.lastName : "Bạn") + " đã gửi một file.";
                }
            }
            else
            {
                cvst.lbLatestMessage.Text = (message.senderId != cvst.Acc.id ? message.lastName : "Bạn") + ": " + message.content;
            }
            DateTime time = (DateTime)message.createdAt;
            cvst.lbDate.Text = time.ToString("HH:mm dd/MM/yyyy");
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

        private void txtSearchAccount_KeyUp(object sender, KeyEventArgs e)
        {
            string keyword = this.txtSearchAccount.Text.Trim();
            if(e.KeyCode == Keys.Enter)
            {
                new SearchAccountHandler(this).Handle(keyword);
            }
            if(keyword.Length == 0)
            {
                DisplayConversationList();
            }
        }

        private void Frame_Load(object sender, EventArgs e)
        {
            pnlConversations.flowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            this.lbUserName.Text = User.firstName + " " + User.lastName;
            this.pbUserAvatar.Image = ChatAppUtils.ByteToImage(User.avatar);
            this.pnlPages.Controls.Clear();
            WelcomeBox welcomeBox = new WelcomeBox(User);
            this.pnlPages.Controls.Add(welcomeBox);
            welcomeBox.Location = new Point(0, 0);
            Client.startReadResponse(new ReadResponseHandler(this));
        }

        private void btnAddNewChat_Click(object sender, EventArgs e)
        {
            
        }
    }
}
