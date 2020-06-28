namespace ChatApp.Views.Components
{
    partial class TextBubble
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
            this.bubble = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.message = new System.Windows.Forms.Label();
            this.option = new System.Windows.Forms.Label();
            this.bubble.SuspendLayout();
            this.SuspendLayout();
            // 
            // bubble
            // 
            this.bubble.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bubble.BorderRadius = 15;
            this.bubble.Controls.Add(this.message);
            this.bubble.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(93)))));
            this.bubble.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(61)))), ((int)(((byte)(87)))));
            this.bubble.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bubble.Location = new System.Drawing.Point(0, 0);
            this.bubble.Name = "bubble";
            this.bubble.ShadowDecoration.Parent = this.bubble;
            this.bubble.Size = new System.Drawing.Size(303, 36);
            this.bubble.TabIndex = 4;
            // 
            // message
            // 
            this.message.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.message.BackColor = System.Drawing.Color.Transparent;
            this.message.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.message.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.message.Location = new System.Drawing.Point(14, 8);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(275, 19);
            this.message.TabIndex = 0;
            this.message.Text = "Nội dung tin nhắn";
            // 
            // option
            // 
            this.option.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.option.Cursor = System.Windows.Forms.Cursors.Hand;
            this.option.Image = global::ChatApp.Properties.Resources.option;
            this.option.Location = new System.Drawing.Point(442, -2);
            this.option.Name = "option";
            this.option.Size = new System.Drawing.Size(15, 16);
            this.option.TabIndex = 5;
            // 
            // TextBubble
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.option);
            this.Controls.Add(this.bubble);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "TextBubble";
            this.Size = new System.Drawing.Size(457, 39);
            this.bubble.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel bubble;
        private System.Windows.Forms.Label message;
        private System.Windows.Forms.Label option;
    }
}
