using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System;
using System.Collections.Generic;

namespace DziennikElektroniczny.Models
{
    public class Grade
    {
        [Key]
        public int GradeId { get; set; }

        [Range(1, 1000000000)]
        public int? StudentPersonId { get; set; }

        [Range(1, 1000000000)]
        public int? TeacherPersonId { get; set; }

        public virtual Person StudentPerson { get; set; }
        public virtual Person TeacherPerson { get; set; }

        [Range(1, 1000000000)]
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        [Required]
        [Column(TypeName = "varchar(4)")]
        public string Value { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

    }
}
