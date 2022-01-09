using DziennikElektroniczny.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DziennikElektroniczny.ViewModels
{
    public class GradeView
    {
        public int Id { get; set; }
        public int? StudentPersonId { get; set; }
        public int? TeacherPersonId { get; set; }
        public int? SubjectId { get; set; }
        public string Value { get; set; }
        public DateTime Date { get; set; }

        public GradeView(Grade grade)
        {
            Id = grade.GradeId;
            StudentPersonId = grade.StudentPersonId;
            TeacherPersonId = grade.TeacherPersonId;
            SubjectId = grade.SubjectId;
            Value = grade.Value;
            Date = grade.Date;
        }
    }
}
