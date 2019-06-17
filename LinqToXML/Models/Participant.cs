using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToXML.Models
{
    internal sealed class Participant
    {
        public string FirstName;
        public string LastName;
        public ParticipantTypes ParticipantType;

        public Participant(string firstName, string lastName, ParticipantTypes participantType)
        {
            FirstName = firstName;
            LastName = lastName;
            ParticipantType = participantType;
        }
    }
}
