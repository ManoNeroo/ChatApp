using ChatApp.Views;
using ReferenceData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Handler
{
    public class SearchAccountHandler
    {
        private Frame form;

        public SearchAccountHandler(Frame form)
        {
            this.form = form;
        }
        public void Handle(string keyword)
        {
            form.Client.send(new SocketData("SEARCHACCOUNT", keyword));
        }
    }
}
