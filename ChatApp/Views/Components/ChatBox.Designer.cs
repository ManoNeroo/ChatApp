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
            this.messageBox = new ChatApp.Views.Components.ScrollPanel();
            this.sendBox = new Guna.UI2.WinForms.Guna2Panel();
            this.SuspendLayout();
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
            // sendBox
            // 
            this.sendBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.sendBox.Location = new System.Drawing.Point(0, 478);
            this.sendBox.Name = "sendBox";
            this.sendBox.ShadowDecoration.Parent = this.sendBox;
            this.sendBox.Size = new System.Drawing.Size(560, 70);
            this.sendBox.TabIndex = 1;
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
            this.ResumeLayout(false);

        }

        #endregion

        private ScrollPanel messageBox;
        private Guna.UI2.WinForms.Guna2Panel sendBox;
    }
}
