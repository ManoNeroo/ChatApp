namespace ChatApp.Views
{
    partial class TestForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.conversation1 = new ChatApp.Views.Components.Conversation();
            this.scrollPanel1 = new ChatApp.Views.Components.ScrollPanel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(58, 46);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // guna2Button1
            // 
            this.guna2Button1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button1.CheckedState.Parent = this.guna2Button1;
            this.guna2Button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2Button1.CustomImages.Parent = this.guna2Button1;
            this.guna2Button1.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.guna2Button1.HoverState.Parent = this.guna2Button1;
            this.guna2Button1.Image = global::ChatApp.Properties.Resources.newchat;
            this.guna2Button1.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button1.ImageOffset = new System.Drawing.Point(6, -8);
            this.guna2Button1.Location = new System.Drawing.Point(92, 106);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
            this.guna2Button1.Size = new System.Drawing.Size(54, 35);
            this.guna2Button1.TabIndex = 2;
            this.guna2Button1.Text = "Chat mới";
            this.guna2Button1.TextOffset = new System.Drawing.Point(0, 8);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.guna2Button1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(193, 450);
            this.panel1.TabIndex = 3;
            // 
            // conversation1
            // 
            this.conversation1.Acc = null;
            this.conversation1.BackColor = System.Drawing.Color.Transparent;
            this.conversation1.Cvst = null;
            this.conversation1.Location = new System.Drawing.Point(315, 117);
            this.conversation1.Name = "conversation1";
            this.conversation1.Size = new System.Drawing.Size(242, 58);
            this.conversation1.TabIndex = 4;
            // 
            // scrollPanel1
            // 
            this.scrollPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(36)))), ((int)(((byte)(52)))));
            this.scrollPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scrollPanel1.Location = new System.Drawing.Point(193, 0);
            this.scrollPanel1.Name = "scrollPanel1";
            this.scrollPanel1.Size = new System.Drawing.Size(499, 450);
            this.scrollPanel1.TabIndex = 0;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 450);
            this.Controls.Add(this.conversation1);
            this.Controls.Add(this.scrollPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Components.ScrollPanel scrollPanel1;
        private System.Windows.Forms.Button button1;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private System.Windows.Forms.Panel panel1;
        private Components.Conversation conversation1;
    }
}