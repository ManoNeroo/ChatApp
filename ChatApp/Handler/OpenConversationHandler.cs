using ChatApp.Views;
using ChatApp.Views.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Handler
{
    public class OpenConversationHandler
    {
        private delegate void SelectConversationDelegate(Conversation cvst);
        private Frame form;
        private Conversation conversation;

        public OpenConversationHandler(Frame form, Conversation cvst)
        {
            this.form = form;
            this.conversation = cvst;
        }
        public void Handle(object sender, EventArgs e)
        {
            form.Invoke(new SelectConversationDelegate(form.SelectConversation), new object[] { conversation });
        }
    }
}
