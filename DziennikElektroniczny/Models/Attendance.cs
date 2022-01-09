using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System;

namespace DziennikElektroniczny.Models
{
    public class Attendance
    {
        [Key]
        public int AttendanceId { get; set; }

        [Range(1, 1000000000)]
        public int? StudentPersonId { get; set; }
        public Person StudentPerson { get; set; }

        [Range(1, 1000000000)]
        public int? LessonId { get; set; }
        public Lesson Lesson { get; set; }

        [Required]
        [Range(1, 1000000000)]
        public int WasPresent { get; set; }

        [MaxLength(2000)]
        public string AbsenceNote { get; set;}

    }
}
