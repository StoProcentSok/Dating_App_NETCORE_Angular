using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class CreateEventDto
    {
        [Required]
        public string EventName { get; set; }

        [Required]
        public string EventDescription { get; set; }
    }
}