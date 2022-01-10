using DziennikElektroniczny.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DziennikElektroniczny.ViewModels
{
    public class AttendanceView
    {
        public int Id { get; set; }
        public int? StudentPersonId { get; set; }
        public string StudentDisplayName { get; set; }
        public int? LessonId { get; set; }
        public string SubjectName { get; set; }
        public DateTime LessonDate { get; set;}
        public int WasPresent { get; set; }
        public string AbsenceNote { get; set; }
        public AttendanceView(Attendance attendance,PersonalInfo studentInfo,Lesson lesson,SubjectInfo subjectInfo)
        {
            Id = attendance.AttendanceId;
            StudentPersonId = attendance.StudentPersonId;
            StudentDisplayName = studentInfo.Name + " " + studentInfo.Surname;
            LessonId = attendance.LessonId;
            SubjectName = subjectInfo.Title;
            LessonDate = lesson.Date;
            WasPresent = attendance.WasPresent;
            AbsenceNote = attendance.AbsenceNote;
        }
    }
}
