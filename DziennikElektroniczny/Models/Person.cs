using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System;
using System.Collections.Generic;

namespace DziennikElektroniczny.Models
{
    public class Person
    {
        [Key]
        [Range(1, 1000000000)]
        public int PersonId { get; set; }
           
        [Required]
        [Range(1, 1000000000)]
        public int Role { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Login { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string HashedPassword { get; set; }

        public int PersonalInfoId { get; set; } 
        public PersonalInfo PersonalInfo { get; set; }

        public virtual StudentsGroup GroupTeacher { get; set; }
        public virtual ICollection<EventParticipator> EventParticipators { get; set; }
        public virtual ICollection<Parent> ParentPersons { get; set; }
        public virtual ICollection<Parent> StudentPersons { get; set; }
        public virtual ICollection<Note> NoteTeacherPersons { get; set; }
        public virtual ICollection<Note> NoteStudentPersons { get; set; }
        public virtual ICollection<Message> FromPersons { get; set; }
        public virtual ICollection<Message> ToPersons { get; set; }
        public virtual ICollection<Grade> GradeStudentPersons { get; set; }
        public virtual ICollection<Grade> GradeTeacherPersons { get; set; }
        public virtual ICollection<Subject> SubjectTeacherPersons { get; set; }
        public virtual ICollection<Attendance> AttendanceStudentPersons { get; set; }
        public virtual ICollection<StudentsGroupMember> StudentsGroupMembers { get; set; }
    }
}
