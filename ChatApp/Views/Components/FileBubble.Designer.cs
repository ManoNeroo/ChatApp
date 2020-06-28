namespace ChatApp.Views.Components
{
    partial class FileBubble
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
            this.fileName = new System.Windows.Forms.Label();
            this.fileSize = new System.Windows.Forms.Label();
            this.picture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            this.SuspendLayout();
            // 
            // fileName
            // 
            this.fileName.AutoSize = true;
            this.fileName.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileName.ForeColor = System.Drawing.Color.White;
            this.fileName.Location = new System.Drawing.Point(3, 3);
            this.fileName.Name = "fileName";
            this.fileName.Size = new System.Drawing.Size(121, 27);
            this.fileName.TabIndex = 1;
            this.fileName.Text = "File Name";
            // 
            // fileSize
            // 
            this.fileSize.AutoSize = true;
            this.fileSize.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileSize.ForeColor = System.Drawing.Color.White;
            this.fileSize.Location = new System.Drawing.Point(5, 35);
            this.fileSize.Name = "fileSize";
            this.fileSize.Size = new System.Drawing.Size(59, 16);
            this.fileSize.TabIndex = 2;
            this.fileSize.Text = "File Size";
            // 
            // picture
            // 
            this.picture.Image = global::ChatApp.Properties.Resources.file;
            this.picture.Location = new System.Drawing.Point(0, 54);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(250, 96);
            this.picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture.TabIndex = 0;
            this.picture.TabStop = false;
            // 
            // FileBubble
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(22)))), ((int)(((byte)(37)))));
            this.Controls.Add(this.fileSize);
            this.Controls.Add(this.fileName);
            this.Controls.Add(this.picture);
            this.Name = "FileBubble";
            this.Size = new System.Drawing.Size(250, 150);
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.Label fileName;
        private System.Windows.Forms.Label fileSize;
    }
}
