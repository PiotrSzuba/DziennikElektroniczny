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
        public string StudentDisplayName { get; set; }
        public int? TeacherPersonId { get; set; }
        public string TeacherDisplayName { get; set; }
        public int? SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string Value { get; set; }
        public DateTime Date { get; set; }

        public GradeView(Grade grade,PersonalInfo studentInfo,PersonalInfo teacherInfo,SubjectInfo subjectInfo)
        {
            Id = grade.GradeId;
            StudentPersonId = grade.StudentPersonId;
            StudentDisplayName = studentInfo.Name + " " + studentInfo.Surname;
            TeacherPersonId = grade.TeacherPersonId;
            TeacherDisplayName = teacherInfo.Name + " " + teacherInfo.Surname;
            SubjectId = grade.SubjectId;
            SubjectName = subjectInfo.Title;
            Value = grade.Value;
            Date = grade.Date;
        }
    }
}
