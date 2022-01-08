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
        public int? StudentId { get; set; }
        public int? LessonId { get; set; }
        public int WasPresent { get; set; }
        public string AbsenceNote { get; set; }
        public AttendanceView(Attendance attendance)
        {
            Id = attendance.AttendanceId;
            StudentId = attendance.StudentPersonId;
            LessonId = attendance.LessonId;
            WasPresent = attendance.WasPresent;
            AbsenceNote = attendance.AbsenceNote;
        }
    }
}
