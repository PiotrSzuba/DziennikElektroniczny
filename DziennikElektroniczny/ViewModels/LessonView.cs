using DziennikElektroniczny.Models;
using System;

namespace DziennikElektroniczny.ViewModels
{
    public class LessonView
    {
        public int Id { get; set; }
        public int? TeacherPersonId { get; set; }
        public string TeacherName { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string Topic { get; set; }
        public DateTime Date { get; set; }

        public LessonView(Lesson lesson,SubjectInfo subjectInfo, PersonalInfo teacherInfo)
        {
            Id = lesson.LessonId;
            TeacherPersonId = lesson.TeacherPersonId;
            TeacherName = teacherInfo.Name + " " + teacherInfo.Surname;
            SubjectId = lesson.SubjectId;
            SubjectName = subjectInfo.Title;
            Topic = lesson.Topic;
            Date = lesson.Date;
        }
    }
}
