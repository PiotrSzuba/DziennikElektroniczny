using DziennikElektroniczny.Models;
using System;

namespace DziennikElektroniczny.ViewModels
{
    public class LessonView
    {
        public int Id { get; set; }
        public int? TeacherPersonId { get; set; }
        public int SubjectId { get; set; }
        public string Topic { get; set; }
        public DateTime Date { get; set; }

        public LessonView(Lesson lesson)
        {
            Id = lesson.LessonId;
            TeacherPersonId = lesson.TeacherPersonId;
            SubjectId = lesson.SubjectId;
            Topic = lesson.Topic;
            Date = lesson.Date;
        }
    }
}
