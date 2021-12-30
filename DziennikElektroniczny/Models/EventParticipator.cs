using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System;

namespace DziennikElektroniczny.Models
{
    public class EventParticipator
    {
        [Key]
        [Required]
        [Range(1, 1000000000)]
        public int EventParticipatorId { get; set; }

        [ForeignKey("Event")]
        [Range(1, 1000000000)]
        public int? EventId { get; set; }
        public Event Event { get; set; } 

        [ForeignKey("Person")]
        [Range(1, 1000000000)]
        public int? PersonId { get; set; }
        public Person Person { get; set; }
    }
}
