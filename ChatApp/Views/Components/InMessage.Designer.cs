namespace ChatApp.Views.Components
{
    partial class InMessage
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
            this.option = new System.Windows.Forms.Label();
            this.bubble = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.message = new System.Windows.Forms.Label();
            this.time = new System.Windows.Forms.Label();
            this.bubble.SuspendLayout();
            this.SuspendLayout();
            // 
            // option
            // 
            this.option.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.option.Cursor = System.Windows.Forms.Cursors.Hand;
            this.option.Image = global::ChatApp.Properties.Resources.option;
            this.option.Location = new System.Drawing.Point(483, 3);
            this.option.Name = "option";
            this.option.Size = new System.Drawing.Size(15, 15);
            this.option.TabIndex = 0;
            // 
            // bubble
            // 
            this.bubble.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bubble.BorderRadius = 15;
            this.bubble.Controls.Add(this.message);
            this.bubble.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(48)))), ((int)(((byte)(90)))));
            this.bubble.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(36)))), ((int)(((byte)(206)))));
            this.bubble.Location = new System.Drawing.Point(137, 20);
            this.bubble.Name = "bubble";
            this.bubble.ShadowDecoration.Parent = this.bubble;
            this.bubble.Size = new System.Drawing.Size(340, 49);
            this.bubble.TabIndex = 1;
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
            this.message.Size = new System.Drawing.Size(312, 33);
            this.message.TabIndex = 0;
            this.message.Text = "The market-leading technical skills assessment platform to identify and hire deve" +
    "lopers with the right skills.";
            // 
            // time
            // 
            this.time.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.time.AutoSize = true;
            this.time.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.time.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.time.Location = new System.Drawing.Point(420, 3);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(56, 14);
            this.time.TabIndex = 2;
            this.time.Text = "hh:mm AM";
            // 
            // InMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(36)))), ((int)(((byte)(52)))));
            this.Controls.Add(this.time);
            this.Controls.Add(this.bubble);
            this.Controls.Add(this.option);
            this.Name = "InMessage";
            this.Size = new System.Drawing.Size(500, 72);
            this.bubble.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label option;
        private Guna.UI2.WinForms.Guna2GradientPanel bubble;
        private System.Windows.Forms.Label message;
        private System.Windows.Forms.Label time;
    }
}
