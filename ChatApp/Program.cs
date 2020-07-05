using ChatApp.Utils;
using ChatApp.Views;
using ChatApp.Views.Components;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ChatApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ChatClient client = new ChatClient("127.0.0.1", 6868);
            Application.Run(new Login(client));
           // MessageBox.Show("TIme: " + DateTime.Now.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds + "\n Local folder: " + Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName));
        }
    }
}
