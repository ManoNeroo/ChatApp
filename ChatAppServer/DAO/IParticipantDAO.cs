using ReferenceData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatAppServer.DAO
{
    public interface IParticipantDAO
    {
        void InsertParticipant(Participant p);
    }
}
