using ChatApp.Views;
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
    public class SignInHandler
    {
        private Login form;

        public SignInHandler(Login form)
        {
            this.form = form;
        }

        public void Handle(object sender, EventArgs e)
        {
            if (form.LoginBox.CheckSignIn())
            {
                if (form.Client.IsConnected)
                {
                    Account acc = new Account();
                    acc.email = form.LoginBox.txtEmail.Text;
                    acc.password = form.LoginBox.txtPassword.Text;
                    Account user = form.Client.SignIn(new SocketData("SIGNIN", acc));
                    if (user != null)
                    {
                        form.Hide();
                        new Frame(form.Client, user).Show();
                    }
                    else
                    {
                        form.LoginBox.pnlError.Visible = true;
                        form.LoginBox.lbError.Text = "Không đúng email hoặc mật khẩu.";
                    }
                }
                else
                {
                    CustomMessageBox msb = new CustomMessageBox();
                    msb.show("Lỗi kết nối!", "Lỗi", CustomMessageBox.MessageBoxButtons.Ok, CustomMessageBox.MessageBoxIcon.Error);
                }
            }
        }
        public void Handle2(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (form.LoginBox.CheckSignIn())
                {
                    if (form.Client.IsConnected)
                    {
                        Account acc = new Account();
                        acc.email = form.LoginBox.txtEmail.Text;
                        acc.password = form.LoginBox.txtPassword.Text;
                        Account user = form.Client.SignIn(new SocketData("SIGNIN", acc));
                        if (user != null)
                        {
                            form.Hide();
                            new Frame(form.Client, user).Show();
                        }
                        else
                        {
                            form.LoginBox.pnlError.Visible = true;
                            form.LoginBox.lbError.Text = "Không đúng email hoặc mật khẩu.";
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
}
