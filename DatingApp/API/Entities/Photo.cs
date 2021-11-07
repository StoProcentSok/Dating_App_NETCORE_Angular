using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Photos")]
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }
        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }
    }

    public class EventPhoto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public Event Event { get; set; }
        public int EventId { get; set; }
    }
}