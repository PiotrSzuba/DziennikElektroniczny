using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System;
using System.Collections.Generic;

namespace DziennikElektroniczny.Models
{
    public class ClassRoom
    {
        [Key]
        [Range(1, 1000000000)]
        public int ClassRoomId { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Building { get; set;}

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Floor { get; set;}

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Destination { get; set; }

        public virtual ICollection<Subject> Subjects{ get; set; }
    }
}
