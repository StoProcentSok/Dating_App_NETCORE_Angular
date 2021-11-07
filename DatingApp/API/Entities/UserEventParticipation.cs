namespace API.Entities
{
    public class UserEventParticipation
    {
        public AppUser SourceUser { get; set; }
        public int SourceUserId { get; set; }
        public Event EventToParticipateIn { get; set; }
        public int EventToParticipateIniId { get; set; }
    }
}