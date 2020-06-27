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
            this.btnSend = new Guna.UI2.WinForms.Guna2CircleButton();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            this.messageBox = new ChatApp.Views.Components.ScrollPanel();
            this.sendBox.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sendBox
            // 
            this.sendBox.Controls.Add(this.guna2Panel1);
            this.sendBox.Controls.Add(this.btnSend);
            this.sendBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.sendBox.Location = new System.Drawing.Point(0, 478);
            this.sendBox.Name = "sendBox";
            this.sendBox.ShadowDecoration.Parent = this.sendBox;
            this.sendBox.Size = new System.Drawing.Size(560, 70);
            this.sendBox.TabIndex = 1;
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
            this.btnSend.Location = new System.Drawing.Point(502, 17);
            this.btnSend.Name = "btnSend";
            this.btnSend.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnSend.ShadowDecoration.Parent = this.btnSend;
            this.btnSend.Size = new System.Drawing.Size(40, 40);
            this.btnSend.TabIndex = 0;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(36)))), ((int)(((byte)(52)))));
            this.guna2Panel1.BorderRadius = 20;
            this.guna2Panel1.Controls.Add(this.guna2TextBox1);
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(22)))), ((int)(((byte)(37)))));
            this.guna2Panel1.Location = new System.Drawing.Point(24, 14);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(357, 45);
            this.guna2Panel1.TabIndex = 0;
            // 
            // guna2TextBox1
            // 
            this.guna2TextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(22)))), ((int)(((byte)(37)))));
            this.guna2TextBox1.BorderThickness = 0;
            this.guna2TextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox1.DefaultText = "";
            this.guna2TextBox1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox1.DisabledState.Parent = this.guna2TextBox1;
            this.guna2TextBox1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(22)))), ((int)(((byte)(37)))));
            this.guna2TextBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox1.FocusedState.Parent = this.guna2TextBox1;
            this.guna2TextBox1.ForeColor = System.Drawing.Color.White;
            this.guna2TextBox1.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox1.HoverState.Parent = this.guna2TextBox1;
            this.guna2TextBox1.Location = new System.Drawing.Point(22, 10);
            this.guna2TextBox1.Name = "guna2TextBox1";
            this.guna2TextBox1.PasswordChar = '\0';
            this.guna2TextBox1.PlaceholderText = "Nhập một tin nhắn";
            this.guna2TextBox1.SelectedText = "";
            this.guna2TextBox1.ShadowDecoration.Parent = this.guna2TextBox1;
            this.guna2TextBox1.Size = new System.Drawing.Size(315, 26);
            this.guna2TextBox1.TabIndex = 0;
            // 
            // messageBox
            // 
            this.messageBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(36)))), ((int)(((byte)(52)))));
            this.messageBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.messageBox.Location = new System.Drawing.Point(0, 0);
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(560, 472);
            this.messageBox.TabIndex = 0;
            // 
            // ChatBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(36)))), ((int)(((byte)(52)))));
            this.Controls.Add(this.sendBox);
            this.Controls.Add(this.messageBox);
            this.Name = "ChatBox";
            this.Size = new System.Drawing.Size(560, 548);
            this.sendBox.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ScrollPanel messageBox;
        private Guna.UI2.WinForms.Guna2Panel sendBox;
        private Guna.UI2.WinForms.Guna2CircleButton btnSend;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;
    }
}
