﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ChatApp.Utils;
using ReferenceData.Entity;

namespace ChatApp.Views.Components
{
    public partial class FileBubble : UserControl
    {
        public string FileName { get; set; }
        public byte[] File { get; set; }
        public FileBubble()
        {
            InitializeComponent();
        }
        public FileBubble(string fileName, byte[] file, msgType type)
        {
            InitializeComponent();
            string[] fileInfo = getFileInfo(fileName);
            FileName = fileInfo[0] + fileInfo[1].ToLower();
            File = file;
            if (type.ToString() == "Out")
            {
                this.pnlBubble.Location = new Point(457 - (pnlBubble.Width + 20), 0);
            }
            if (fileInfo[1].Equals(".JPG") || fileInfo[1].Equals(".JPEG") || fileInfo[1].Equals(".PNG") || fileInfo[1].Equals(".GIF"))
            {
                this.picture.Size = new Size(230, 130);
                this.picture.Location = new Point(10, 10);
                this.picture.Image = ClientUtils.ByteToImage(File);
                this.fileName.Visible = false;
                this.fileSize.Visible = false;
            }
            else
            {
                this.fileName.Text = FileName;
                this.fileSize.Text = getFileSize(File);
            }
        }

        private string[] getFileInfo(string fileName)
        {
            string[] info = new string[] { "", "" };
            string[] arrName = fileName.Split('_');
            if(arrName.Length >= 3)
            {
                info[1] = arrName[arrName.Length - 1].ToUpper();
                for (int i = 0; i < arrName.Length - 2; i++)
                {
                    if (i == arrName.Length - 3)
                    {
                        info[0] += arrName[i];
                    }
                    else
                    {
                        info[0] += arrName[i] + "_";
                    }
                }
            } else
            {
                info[0] = arrName[0];
            }
            return info;
        }
        private string getFileSize(byte[] file)
        {
            string size = "";
            if (file.Length < 1048576)
            {
                double a = file.Length / 1024;
                size = Math.Round(a) + " Kb";
            }
            else
            {
                double a = file.Length / 1048576;
                size = Math.Round(a) + " Mb";
            }
            return size;
        }
        public enum msgType
        {
            In,
            Out
        }
    }
}
