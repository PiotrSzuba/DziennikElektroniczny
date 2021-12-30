using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System;
using System.Collections.Generic;


namespace DziennikElektroniczny.Models
{
    public class StudentsGroup
    {
        [Key]
        [Range(1, 1000000000)]
        public int StudentsGroupId { get; set; }

        [Range(1, 1000000000)]
        public int? TeacherPersonId { get; set; }
        public Person TeacherPerson { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Title { get; set; }

        [Column(TypeName = "varchar(2000)")]
        public string? Description { get; set; }

        [Required]
        [Range(1, 1000000000)]
        public int YearOfStudy { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<StudentsGroupMember> StudentsGroupMembers { get; set; }
    }
}
