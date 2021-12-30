using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System;
using System.Collections.Generic;

namespace DziennikElektroniczny.Models
{
    public class Subject
    {
        [Key]
        [Range(1, 1000000000)]
        public int SubjectId { get; set; }

        [Range(1, 1000000000)]
        public int? SubjectInfoId { get; set; }
        public SubjectInfo SubjectInfo { get; set; }

        [Range(1, 1000000000)]
        public int? TeacherPersonId { get; set; }
        public virtual Person TeacherPerson { get; set; }

        [Range(1, 1000000000)]
        public int StudentsGroupId { get; set; }
        public StudentsGroup StudentsGroup { get; set; }

        [Range(1, 1000000000)]
        public int ClassRoomId { get; set; }
        public ClassRoom ClassRoom { get; set; }

        public virtual ICollection<Grade> Grades { get; set; }
    }
}
