using ChatApp.Utils;
using ChatApp.Views;
using ChatApp.Views.Components;
using Microsoft.VisualBasic;
using ReferenceData;
using ReferenceData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatApp.Handler
{
    public class SignUpHandler
    {
        private Login form;

        public SignUpHandler(Login form)
        {
            this.form = form;
        }
        public void Handle(object sender, EventArgs e)
        {
            if(form.SignUpBox.CheckSignUp())
            {
                if (form.Client.IsConnected)
                {
                    Account acc = new Account();
                    acc.email = form.SignUpBox.txtEmail.Text;
                    acc.password = form.SignUpBox.txtPassword.Text;
                    acc.firstName = form.SignUpBox.txtFirstName.Text;
                    acc.lastName = form.SignUpBox.txtLastName.Text;
                    CustomMessageBox msb = new CustomMessageBox();
                    if (form.Client.SignUp(new SocketData("SIGNUP", acc)))
                    {
                        msb.show("Đăng ký thành công", "Thành công", CustomMessageBox.MessageBoxButtons.Ok, CustomMessageBox.MessageBoxIcon.Success);
                        form.pnlPages.Controls.Clear();
                        form.addLoginBox();
                    }
                    else
                    {
                        form.SignUpBox.pnlError.Visible = true;
                        form.SignUpBox.lbError.Text = "Email đã tồn tại.";
                    }
                }
                else
                {
                    CustomMessageBox msb = new CustomMessageBox();
                    msb.show("Lỗi kết nối!", "Lỗi", CustomMessageBox.MessageBoxButtons.Ok, CustomMessageBox.MessageBoxIcon.Error);
                }
            }
        }
    }
}
