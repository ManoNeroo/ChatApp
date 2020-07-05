namespace ChatApp.Views.Components
{
    partial class ChatBox
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sendBox = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.txtMessage = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnlTop = new Guna.UI2.WinForms.Guna2Panel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.guna2CircleButton2 = new Guna.UI2.WinForms.Guna2CircleButton();
            this.guna2CircleButton1 = new Guna.UI2.WinForms.Guna2CircleButton();
            this.btnSend = new Guna.UI2.WinForms.Guna2CircleButton();
            this.messageBox = new ChatApp.Views.Components.ScrollPanel();
            this.sendBox.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // sendBox
            // 
            this.sendBox.Controls.Add(this.guna2Panel1);
            this.sendBox.Controls.Add(this.guna2CircleButton2);
            this.sendBox.Controls.Add(this.guna2CircleButton1);
            this.sendBox.Controls.Add(this.btnSend);
            this.sendBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.sendBox.Location = new System.Drawing.Point(0, 478);
            this.sendBox.Name = "sendBox";
            this.sendBox.ShadowDecoration.Parent = this.sendBox;
            this.sendBox.Size = new System.Drawing.Size(560, 70);
            this.sendBox.TabIndex = 1;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(36)))), ((int)(((byte)(52)))));
            this.guna2Panel1.BorderRadius = 20;
            this.guna2Panel1.Controls.Add(this.txtMessage);
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(22)))), ((int)(((byte)(37)))));
            this.guna2Panel1.Location = new System.Drawing.Point(24, 14);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(357, 45);
            this.guna2Panel1.TabIndex = 0;
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(22)))), ((int)(((byte)(37)))));
            this.txtMessage.BorderThickness = 0;
            this.txtMessage.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMessage.DefaultText = "";
            this.txtMessage.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMessage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMessage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMessage.DisabledState.Parent = this.txtMessage;
            this.txtMessage.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMessage.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(22)))), ((int)(((byte)(37)))));
            this.txtMessage.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMessage.FocusedState.Parent = this.txtMessage;
            this.txtMessage.ForeColor = System.Drawing.Color.White;
            this.txtMessage.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMessage.HoverState.Parent = this.txtMessage;
            this.txtMessage.Location = new System.Drawing.Point(22, 10);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.PasswordChar = '\0';
            this.txtMessage.PlaceholderText = "Nhập một tin nhắn";
            this.txtMessage.SelectedText = "";
            this.txtMessage.ShadowDecoration.Parent = this.txtMessage;
            this.txtMessage.Size = new System.Drawing.Size(315, 26);
            this.txtMessage.TabIndex = 0;
            this.txtMessage.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtMessage_KeyUp);
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(22)))), ((int)(((byte)(37)))));
            this.pnlTop.Controls.Add(this.lbTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.ShadowDecoration.Parent = this.pnlTop;
            this.pnlTop.Size = new System.Drawing.Size(560, 55);
            this.pnlTop.TabIndex = 2;
            // 
            // lbTitle
            // 
            this.lbTitle.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbTitle.Location = new System.Drawing.Point(20, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(300, 55);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "Tiêu đề";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // guna2CircleButton2
            // 
            this.guna2CircleButton2.CheckedState.Parent = this.guna2CircleButton2;
            this.guna2CircleButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2CircleButton2.CustomImages.Parent = this.guna2CircleButton2;
            this.guna2CircleButton2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(22)))), ((int)(((byte)(37)))));
            this.guna2CircleButton2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2CircleButton2.ForeColor = System.Drawing.Color.White;
            this.guna2CircleButton2.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.guna2CircleButton2.HoverState.Image = global::ChatApp.Properties.Resources.attachhover;
            this.guna2CircleButton2.HoverState.Parent = this.guna2CircleButton2;
            this.guna2CircleButton2.Image = global::ChatApp.Properties.Resources.attach;
            this.guna2CircleButton2.ImageSize = new System.Drawing.Size(25, 25);
            this.guna2CircleButton2.Location = new System.Drawing.Point(494, 17);
            this.guna2CircleButton2.Name = "guna2CircleButton2";
            this.guna2CircleButton2.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleButton2.ShadowDecoration.Parent = this.guna2CircleButton2;
            this.guna2CircleButton2.Size = new System.Drawing.Size(40, 40);
            this.guna2CircleButton2.TabIndex = 0;
            this.guna2CircleButton2.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // guna2CircleButton1
            // 
            this.guna2CircleButton1.CheckedState.Parent = this.guna2CircleButton1;
            this.guna2CircleButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2CircleButton1.CustomImages.Parent = this.guna2CircleButton1;
            this.guna2CircleButton1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(22)))), ((int)(((byte)(37)))));
            this.guna2CircleButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2CircleButton1.ForeColor = System.Drawing.Color.White;
            this.guna2CircleButton1.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.guna2CircleButton1.HoverState.Image = global::ChatApp.Properties.Resources.picturehover;
            this.guna2CircleButton1.HoverState.Parent = this.guna2CircleButton1;
            this.guna2CircleButton1.Image = global::ChatApp.Properties.Resources.picture;
            this.guna2CircleButton1.ImageSize = new System.Drawing.Size(25, 25);
            this.guna2CircleButton1.Location = new System.Drawing.Point(446, 17);
            this.guna2CircleButton1.Name = "guna2CircleButton1";
            this.guna2CircleButton1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleButton1.ShadowDecoration.Parent = this.guna2CircleButton1;
            this.guna2CircleButton1.Size = new System.Drawing.Size(40, 40);
            this.guna2CircleButton1.TabIndex = 0;
            this.guna2CircleButton1.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnSend
            // 
            this.btnSend.CheckedState.Parent = this.btnSend;
            this.btnSend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSend.CustomImages.Parent = this.btnSend;
            this.btnSend.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(22)))), ((int)(((byte)(37)))));
            this.btnSend.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.btnSend.HoverState.Image = global::ChatApp.Properties.Resources.sendhover;
            this.btnSend.HoverState.Parent = this.btnSend;
            this.btnSend.Image = global::ChatApp.Properties.Resources.send;
            this.btnSend.ImageSize = new System.Drawing.Size(25, 25);
            this.btnSend.Location = new System.Drawing.Point(398, 17);
            this.btnSend.Name = "btnSend";
            this.btnSend.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnSend.ShadowDecoration.Parent = this.btnSend;
            this.btnSend.Size = new System.Drawing.Size(40, 40);
            this.btnSend.TabIndex = 0;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // messageBox
            // 
            this.messageBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(36)))), ((int)(((byte)(52)))));
            this.messageBox.Location = new System.Drawing.Point(0, 64);
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(560, 408);
            this.messageBox.TabIndex = 0;
            // 
            // ChatBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(36)))), ((int)(((byte)(52)))));
            this.Controls.Add(this.messageBox);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.sendBox);
            this.Name = "ChatBox";
            this.Size = new System.Drawing.Size(560, 548);
            this.sendBox.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ScrollPanel messageBox;
        private Guna.UI2.WinForms.Guna2Panel sendBox;
        private Guna.UI2.WinForms.Guna2CircleButton btnSend;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel pnlTop;
        private System.Windows.Forms.Label lbTitle;
        public Guna.UI2.WinForms.Guna2TextBox txtMessage;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButton1;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButton2;
    }
}
