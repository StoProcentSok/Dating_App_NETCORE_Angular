using System;
using System.Collections.Generic;

namespace API.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public ICollection<EventPhoto> Photos { get; set; }
        public ICollection<UserEventParticipation> ParticipatingUsers { get; set; }

    }
}