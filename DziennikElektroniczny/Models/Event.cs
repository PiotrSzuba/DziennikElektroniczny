using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System;
using System.Collections.Generic;

namespace DziennikElektroniczny.Models
{
    public class Event
    {
        [Key]
        [Required]
        [Range(1,1000000000)]
        public int EventId { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "varchar(2000)")]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DndDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        public virtual ICollection<EventParticipator> EventParticipators { get; set; }
        //public virtual ICollection<Person> Persons { get; set; }

    }
}
