using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using ChatApp.Utils;
using ReferenceData.Entity;
using ChatApp.Handler;
using Microsoft.VisualBasic.ApplicationServices;
using ReferenceData;

namespace ChatApp.Views.Components
{
    public partial class ChatBox : UserControl
    {
        public List<ReferenceData.Entity.Message> MessageList { get; set; } = new List<ReferenceData.Entity.Message>();
        public ChatClient Client { get; set; }
        public Components.Conversation ConversationBox { get; set; }
        private OutgoingMessage currentOutMessage = null;
        private IncomingMessage currentInMessage = null;
        public ChatBox()
        {
            InitializeComponent();
        }
        public ChatBox(ChatClient client, Components.Conversation cvst)
        {
            Client = client;
            ConversationBox = cvst;
            InitializeComponent();
            this.messageBox.flowLayoutPanel.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            initUi();
        }
        private void initUi()
        {
            this.lbTitle.Text = ConversationBox.Cvst.title;
            new LoadMessageHandler(Client).Handle(ConversationBox.Cvst.id, 0, 15);
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            new SendMessageHandler(this).Handle();
        }
        private void txtMessage_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                new SendMessageHandler(this).Handle();
            }
        }

        public void AddOutMessage(ReferenceData.Entity.Message message)
        {
            currentInMessage = null;
            this.messageBox.flowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            this.txtMessage.Text = "";
            TextBubble textBubble = new TextBubble();
            if (message.messageType.ToUpper().Equals("TEXT"))
            {
                textBubble = new TextBubble(message.content, TextBubble.msgType.Out);
            }
            if (this.currentOutMessage == null)
            {
                currentOutMessage = new OutgoingMessage(ConversationBox.Acc.id, DateTime.Now);
                currentOutMessage.AddBubble(textBubble);
                this.messageBox.flowLayoutPanel.Controls.Add(currentOutMessage);
            }
            else
            {
                if(compareTime(currentOutMessage.Time, DateTime.Now))
                {
                    this.messageBox.flowLayoutPanel.Controls.Remove(currentOutMessage);
                    currentOutMessage.AddBubble(textBubble);
                    this.messageBox.flowLayoutPanel.Controls.Add(currentOutMessage);
                } else
                {
                    currentOutMessage = new OutgoingMessage(ConversationBox.Acc.id, DateTime.Now);
                    currentOutMessage.AddBubble(textBubble);
                    this.messageBox.flowLayoutPanel.Controls.Add(currentOutMessage);
                }
            }
            this.messageBox.UpdateUi();
            this.messageBox.vScrollBar.Value = this.messageBox.vScrollBar.Maximum;
        }
        public void AddInMessage(ReferenceData.Entity.Message message)
        {
            currentOutMessage = null;
            this.messageBox.flowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            TextBubble textBubble = new TextBubble();
            if (message.messageType.ToUpper().Equals("TEXT"))
            {
                textBubble = new TextBubble(message.content, TextBubble.msgType.In);
            }
            if (this.currentInMessage == null)
            {
                currentInMessage = new IncomingMessage(message.avatar, message.senderId, message.lastName, DateTime.Now);
                currentInMessage.AddBubble(textBubble);
                this.messageBox.flowLayoutPanel.Controls.Add(currentInMessage);
            }
            else
            {
                if (compareTime(currentInMessage.Time, DateTime.Now))
                {
                    this.messageBox.flowLayoutPanel.Controls.Remove(currentInMessage);
                    currentInMessage.AddBubble(textBubble);
                    this.messageBox.flowLayoutPanel.Controls.Add(currentInMessage);
                }
                else
                {
                    currentInMessage = new IncomingMessage(message.avatar, message.senderId, message.lastName, DateTime.Now);
                    currentInMessage.AddBubble(textBubble);
                    this.messageBox.flowLayoutPanel.Controls.Add(currentInMessage);
                }
            }
            this.messageBox.UpdateUi();
            this.messageBox.vScrollBar.Value = this.messageBox.vScrollBar.Maximum;
        }
        private long convertDateTimeToSeconds(DateTime time)
        {
            return (long)time.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
        }
        private bool compareTime(DateTime t1, DateTime t2)
        {
            if (t1.Year == t2.Year && t1.Month == t2.Month && t1.Day == t2.Day && t1.Hour == t2.Hour && t1.Minute == t2.Minute)
            {
                return true;
            }
            return false;
        }
        public void GenarateMessage(List<ReferenceData.Entity.Message> list, FlowDirection direction)
        {
            if (direction == FlowDirection.TopDown)
            {
                list.Reverse();
            }
            this.messageBox.flowLayoutPanel.FlowDirection = direction;

            DateTime time = (DateTime)list[0].createdAt;
            UserControl currentMessage;
            IncomingMessage cInMessage = new IncomingMessage();
            OutgoingMessage cOutMessage = new OutgoingMessage();
            if (list[0].senderId != ConversationBox.Acc.id)
            {
                cInMessage = new IncomingMessage(list[0].avatar, list[0].senderId, list[0].lastName, time);
                TextBubble text = new TextBubble(list[0].content, TextBubble.msgType.In);
                cInMessage.AddBubble(text);
                currentMessage = cInMessage;
            }
            else
            {
                cOutMessage = new OutgoingMessage(list[0].senderId, time);
                TextBubble text = new TextBubble(list[0].content, TextBubble.msgType.Out);
                cOutMessage.AddBubble(text);
                currentMessage = cOutMessage;
            }
            foreach (var mes in list)
            {
                if (!mes.Equals(list[0]))
                {
                    if (mes.senderId != ConversationBox.Acc.id)
                    {
                        if (currentMessage.GetType() != typeof(IncomingMessage))
                        {
                            this.messageBox.flowLayoutPanel.Controls.Add(currentMessage);
                            time = (DateTime)mes.createdAt;
                            cInMessage = new IncomingMessage(mes.avatar, mes.senderId, mes.lastName, time);
                            TextBubble text = new TextBubble(mes.content, TextBubble.msgType.In);
                            cInMessage.AddBubble(text);
                            currentMessage = cInMessage;
                        }
                        else
                        {
                            if (compareTime(time, (DateTime)mes.createdAt) && cInMessage.UserId == mes.senderId)
                            {
                                TextBubble text = new TextBubble(mes.content, TextBubble.msgType.In);
                                cInMessage.AddBubble(text);
                            }
                            else
                            {
                                this.messageBox.flowLayoutPanel.Controls.Add(currentMessage);
                                time = (DateTime)mes.createdAt;
                                cInMessage = new IncomingMessage(mes.avatar, mes.senderId, mes.lastName, time);
                                TextBubble text = new TextBubble(mes.content, TextBubble.msgType.In);
                                cInMessage.AddBubble(text);
                                currentMessage = cInMessage;
                            }
                        }
                    }
                    else
                    {
                        if (currentMessage.GetType() != typeof(OutgoingMessage))
                        {
                            this.messageBox.flowLayoutPanel.Controls.Add(currentMessage);
                            time = (DateTime)mes.createdAt;
                            cOutMessage = new OutgoingMessage(mes.senderId, time);
                            TextBubble text = new TextBubble(mes.content, TextBubble.msgType.Out);
                            cOutMessage.AddBubble(text);
                            currentMessage = cOutMessage;
                        }
                        else
                        {
                            if (compareTime(time, (DateTime)mes.createdAt) && cOutMessage.UserId == mes.senderId)
                            {
                                TextBubble text = new TextBubble(mes.content, TextBubble.msgType.Out);
                                cOutMessage.AddBubble(text);
                            }
                            else
                            {
                                this.messageBox.flowLayoutPanel.Controls.Add(currentMessage);
                                time = (DateTime)mes.createdAt;
                                cOutMessage = new OutgoingMessage(mes.senderId, time);
                                TextBubble text = new TextBubble(mes.content, TextBubble.msgType.Out);
                                cOutMessage.AddBubble(text);
                                currentMessage = cOutMessage;
                            }
                        }
                    }
                }
            }
            this.messageBox.flowLayoutPanel.Controls.Add(currentMessage);
            this.messageBox.UpdateUi();
        }

        
    }
}
