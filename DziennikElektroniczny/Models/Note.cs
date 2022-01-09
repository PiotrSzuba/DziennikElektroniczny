using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System;
using System.Collections.Generic;

namespace DziennikElektroniczny.Models
{
    public class Note
    {
        [Key]
        public int NoteId { get; set; }
        
        [Required]
        [Column(TypeName = "varchar(2000)")]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Range(1, 1000000000)]
        public int? TeacherPersonId { get; set; }

        [Range(1, 1000000000)]
        public int? StudentPersonId { get; set; }

        public virtual Person TeacherPerson { get; set; }
        public virtual Person StudentPerson { get; set; }
    }
}
