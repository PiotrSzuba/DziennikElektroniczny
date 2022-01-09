using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System;
using System.Collections.Generic;

namespace DziennikElektroniczny.Models
{
    public class Lesson
    {
        [Key]
        public int LessonId { get; set; }

        [Range(1, 1000000000)]
        public int? TeacherPersonId { get; set; }
        public Person TeacherPerson { get; set; }

        [Range(1, 1000000000)]
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Topic { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}
