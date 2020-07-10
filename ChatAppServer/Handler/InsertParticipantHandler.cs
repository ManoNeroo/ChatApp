using ChatAppServer.DAO.Implements;
using ChatAppServer.Models;
using ChatAppServer.SocketServer;
using ReferenceData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatAppServer.Handler
{
    public class InsertParticipantHandler
    {
        private ServerWorker worker;

        public InsertParticipantHandler(ServerWorker worker)
        {
            this.worker = worker;
        }
        public void Handle(SocketData data)
        {
            ReferenceData.Entity.Participant p = (ReferenceData.Entity.Participant)data.Data;
            new ParticipantDAO().InsertParticipant(p);
        }
    }
}
