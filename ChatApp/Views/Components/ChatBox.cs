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
        public FileItem FileItem = null;
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
            if(ConversationBox.Cvst.memberList.Count <= 2)
            {
                this.btnAddMember.Visible = false;
                this.lbNumMember.Visible = false;
            } else
            {
                this.lbNumMember.Text = ConversationBox.Cvst.memberList.Count + " Thành viên";
            }
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

        private void btnChoosePicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog choosePictureDialog = new OpenFileDialog()
            {
                Filter = "Image files (*.png;*.jpg;*.jpeg;*.gif) | *.png;*.jpg;*.jpeg;*.gif",
                Title = "Chọn một file ảnh"
            };
            choosePictureDialog.ShowDialog();
            if(!choosePictureDialog.FileName.Equals(""))
            {
                byte[] file = ClientUtils.ConvertFileToByte(choosePictureDialog.FileName);
                string[] arrFileName = choosePictureDialog.FileName.Split('\\');
                string fn = arrFileName[arrFileName.Length - 1];
                FileItem = new FileItem(fn, file);
                this.Controls.Add(FileItem);
                FileItem.Location = new Point(25, 386);
                FileItem.BringToFront();
                FileItem.ButtonCloseClick(closeFileItem);
            }
        }
        private void btnChooseAllFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog chooseFileDialog= new OpenFileDialog()
            {
                Filter = "Image files (*.*) | *.*",
                Title = "Chọn một file"
            };
            chooseFileDialog.ShowDialog();
            if (!chooseFileDialog.FileName.Equals(""))
            {
                byte[] file = ClientUtils.ConvertFileToByte(chooseFileDialog.FileName);
                string[] arrFileName = chooseFileDialog.FileName.Split('\\');
                string fn = arrFileName[arrFileName.Length - 1];
                FileItem = new FileItem(fn, file);
                this.Controls.Add(FileItem);
                FileItem.Location = new Point(25, 386);
                FileItem.BringToFront();
                FileItem.ButtonCloseClick(closeFileItem);
            }
        }
        private void closeFileItem(object sender, EventArgs e)
        {
            this.Controls.Remove(FileItem);
            FileItem = null;
        }

        public void AddOutMessage(ReferenceData.Entity.Message message)
        {
            if(FileItem != null)
            {
                this.Controls.Remove(FileItem);
                FileItem = null;
            }
            currentInMessage = null;
            this.messageBox.flowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            this.txtMessage.Text = "";
            UserControl bubble = null;
            if (message.messageType.ToUpper().Equals("TEXT"))
            {
                bubble = new TextBubble(message.content, TextBubble.msgType.Out);
            } else
            {
                bubble = new FileBubble(message.content, message.file, FileBubble.msgType.Out);
            }
            if (this.currentOutMessage == null)
            {
                currentOutMessage = new OutgoingMessage(ConversationBox.Acc.id, DateTime.Now);
            }
            else
            {
                if(compareTime(currentOutMessage.Time, DateTime.Now))
                {
                    this.messageBox.flowLayoutPanel.Controls.Remove(currentOutMessage);
                } else
                {
                    currentOutMessage = new OutgoingMessage(ConversationBox.Acc.id, DateTime.Now);
                }
            }
            currentOutMessage.AddBubble(bubble);
            this.messageBox.flowLayoutPanel.Controls.Add(currentOutMessage);
            this.messageBox.UpdateUi();
            this.messageBox.vScrollBar.Value = this.messageBox.vScrollBar.Maximum;
            InitLatestMessage(message);
        }
        public void AddInMessage(ReferenceData.Entity.Message message)
        {
            currentOutMessage = null;
            this.messageBox.flowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            UserControl bubble = null;
            if (message.messageType.ToUpper().Equals("TEXT"))
            {
                bubble = new TextBubble(message.content, TextBubble.msgType.In);
            } else
            {
                bubble = new FileBubble(message.content, message.file, FileBubble.msgType.In);
            }
            if (this.currentInMessage == null)
            {
                currentInMessage = new IncomingMessage(message.avatar, message.senderId, message.lastName, DateTime.Now);
            }
            else
            {
                if (currentInMessage.UserId != message.senderId)
                {
                    currentInMessage = new IncomingMessage(message.avatar, message.senderId, message.lastName, DateTime.Now);
                }
                else
                {
                    if (compareTime(currentInMessage.Time, DateTime.Now))
                    {
                        this.messageBox.flowLayoutPanel.Controls.Remove(currentInMessage);
                    }
                    else
                    {
                        currentInMessage = new IncomingMessage(message.avatar, message.senderId, message.lastName, DateTime.Now);
                    }
                }
            }
            currentInMessage.AddBubble(bubble);
            this.messageBox.flowLayoutPanel.Controls.Add(currentInMessage);
            this.messageBox.UpdateUi();
            this.messageBox.vScrollBar.Value = this.messageBox.vScrollBar.Maximum;
            InitLatestMessage(message);
        }
        private bool compareTime(DateTime t1, DateTime t2)
        {
            if (t1.Year == t2.Year && t1.Month == t2.Month && t1.Day == t2.Day && t1.Hour == t2.Hour && t1.Minute == t2.Minute)
            {
                return true;
            }
            return false;
        }
        private void InitLatestMessage(ReferenceData.Entity.Message message)
        {
            if (message.messageType.Equals("FILE"))
            {
                string[] arr = message.content.Split('_');
                string fex = arr[arr.Length - 1];
                if (fex.Equals(".jpg") || fex.Equals(".png") || fex.Equals(".jpeg") || fex.Equals(".gif"))
                {
                    ConversationBox.lbLatestMessage.Text = (message.senderId != ConversationBox.Acc.id ? message.lastName : "Bạn") + " đã gửi một ảnh.";
                }
                else
                {
                    ConversationBox.lbLatestMessage.Text = (message.senderId != ConversationBox.Acc.id ? message.lastName : "Bạn") + " đã gửi một file.";
                }
            }
            else
            {
                ConversationBox.lbLatestMessage.Text = (message.senderId != ConversationBox.Acc.id ? message.lastName : "Bạn") + ": " + message.content;
            }
            DateTime time = (DateTime)message.createdAt;
            ConversationBox.lbDate.Text = time.ToString("HH:mm dd/MM/yyyy");
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
            UserControl bubble;
            IncomingMessage cInMessage = new IncomingMessage();
            OutgoingMessage cOutMessage = new OutgoingMessage();
            if (list[0].senderId != ConversationBox.Acc.id)
            {
                cInMessage = new IncomingMessage(list[0].avatar, list[0].senderId, list[0].lastName, time);
                if(list[0].messageType.Equals("FILE"))
                {
                    bubble = new FileBubble(list[0].content, list[0].file, FileBubble.msgType.In);
                } else
                {
                    bubble = new TextBubble(list[0].content, TextBubble.msgType.In);
                }
                cInMessage.AddBubble(bubble);
                currentMessage = cInMessage;
            }
            else
            {
                cOutMessage = new OutgoingMessage(list[0].senderId, time);
                if (list[0].messageType.Equals("FILE"))
                {
                    bubble = new FileBubble(list[0].content, list[0].file, FileBubble.msgType.Out);
                }
                else
                {
                    bubble = new TextBubble(list[0].content, TextBubble.msgType.Out);
                }
                cOutMessage.AddBubble(bubble);
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
                            if (mes.messageType.Equals("FILE"))
                            {
                                bubble = new FileBubble(mes.content, mes.file, FileBubble.msgType.In);
                            }
                            else
                            {
                                bubble = new TextBubble(mes.content, TextBubble.msgType.In);
                            }
                            cInMessage.AddBubble(bubble);
                            currentMessage = cInMessage;
                        }
                        else
                        {
                            if (compareTime(time, (DateTime)mes.createdAt) && cInMessage.UserId == mes.senderId)
                            {
                                if (mes.messageType.Equals("FILE"))
                                {
                                    bubble = new FileBubble(mes.content, mes.file, FileBubble.msgType.In);
                                }
                                else
                                {
                                    bubble = new TextBubble(mes.content, TextBubble.msgType.In);
                                }
                                cInMessage.AddBubble(bubble);
                            }
                            else
                            {
                                this.messageBox.flowLayoutPanel.Controls.Add(currentMessage);
                                time = (DateTime)mes.createdAt;
                                cInMessage = new IncomingMessage(mes.avatar, mes.senderId, mes.lastName, time);
                                if (mes.messageType.Equals("FILE"))
                                {
                                    bubble = new FileBubble(mes.content, mes.file, FileBubble.msgType.In);
                                }
                                else
                                {
                                    bubble = new TextBubble(mes.content, TextBubble.msgType.In);
                                }
                                cInMessage.AddBubble(bubble);
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
                            if (mes.messageType.Equals("FILE"))
                            {
                                bubble = new FileBubble(mes.content, mes.file, FileBubble.msgType.Out);
                            }
                            else
                            {
                                bubble = new TextBubble(mes.content, TextBubble.msgType.Out);
                            }
                            cOutMessage.AddBubble(bubble);
                            currentMessage = cOutMessage;
                        }
                        else
                        {
                            if (compareTime(time, (DateTime)mes.createdAt) && cOutMessage.UserId == mes.senderId)
                            {
                                if (mes.messageType.Equals("FILE"))
                                {
                                    bubble = new FileBubble(mes.content, mes.file, FileBubble.msgType.Out);
                                }
                                else
                                {
                                    bubble = new TextBubble(mes.content, TextBubble.msgType.Out);
                                }
                                cOutMessage.AddBubble(bubble);
                            }
                            else
                            {
                                this.messageBox.flowLayoutPanel.Controls.Add(currentMessage);
                                time = (DateTime)mes.createdAt;
                                cOutMessage = new OutgoingMessage(mes.senderId, time);
                                if (mes.messageType.Equals("FILE"))
                                {
                                    bubble = new FileBubble(mes.content, mes.file, FileBubble.msgType.Out);
                                }
                                else
                                {
                                    bubble = new TextBubble(mes.content, TextBubble.msgType.Out);
                                }
                                cOutMessage.AddBubble(bubble);
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
