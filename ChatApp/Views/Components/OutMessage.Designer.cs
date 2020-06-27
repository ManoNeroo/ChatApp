namespace ChatApp.Views.Components
{
    partial class OutMessage
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
            this.time = new System.Windows.Forms.Label();
            this.bubble = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.message = new System.Windows.Forms.Label();
            this.userName = new System.Windows.Forms.Label();
            this.option = new System.Windows.Forms.Label();
            this.userAvatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.bubble.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // time
            // 
            this.time.AutoSize = true;
            this.time.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.time.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.time.Location = new System.Drawing.Point(135, 3);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(56, 14);
            this.time.TabIndex = 4;
            this.time.Text = "hh:mm AM";
            // 
            // bubble
            // 
            this.bubble.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bubble.BorderRadius = 15;
            this.bubble.Controls.Add(this.message);
            this.bubble.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(93)))));
            this.bubble.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(61)))), ((int)(((byte)(87)))));
            this.bubble.Location = new System.Drawing.Point(46, 20);
            this.bubble.Name = "bubble";
            this.bubble.ShadowDecoration.Parent = this.bubble;
            this.bubble.Size = new System.Drawing.Size(340, 36);
            this.bubble.TabIndex = 3;
            // 
            // message
            // 
            this.message.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.message.BackColor = System.Drawing.Color.Transparent;
            this.message.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.message.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.message.Location = new System.Drawing.Point(15, 9);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(312, 18);
            this.message.TabIndex = 0;
            this.message.Text = "Matching developers with great companies.\r\n";
            // 
            // userName
            // 
            this.userName.AutoSize = true;
            this.userName.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.userName.Location = new System.Drawing.Point(46, 3);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(83, 14);
            this.userName.TabIndex = 4;
            this.userName.Text = "Tên người dùng";
            // 
            // option
            // 
            this.option.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.option.Cursor = System.Windows.Forms.Cursors.Hand;
            this.option.Image = global::ChatApp.Properties.Resources.option;
            this.option.Location = new System.Drawing.Point(483, 3);
            this.option.Name = "option";
            this.option.Size = new System.Drawing.Size(15, 15);
            this.option.TabIndex = 6;
            // 
            // userAvatar
            // 
            this.userAvatar.Image = global::ChatApp.Properties.Resources.avatar;
            this.userAvatar.Location = new System.Drawing.Point(0, 0);
            this.userAvatar.Name = "userAvatar";
            this.userAvatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.userAvatar.ShadowDecoration.Parent = this.userAvatar;
            this.userAvatar.Size = new System.Drawing.Size(40, 40);
            this.userAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.userAvatar.TabIndex = 5;
            this.userAvatar.TabStop = false;
            // 
            // OutMessage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(36)))), ((int)(((byte)(52)))));
            this.Controls.Add(this.option);
            this.Controls.Add(this.userAvatar);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.time);
            this.Controls.Add(this.bubble);
            this.Name = "OutMessage";
            this.Size = new System.Drawing.Size(500, 58);
            this.bubble.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.userAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label time;
        private Guna.UI2.WinForms.Guna2GradientPanel bubble;
        private System.Windows.Forms.Label message;
        private System.Windows.Forms.Label userName;
        private Guna.UI2.WinForms.Guna2CirclePictureBox userAvatar;
        private System.Windows.Forms.Label option;
    }
}
