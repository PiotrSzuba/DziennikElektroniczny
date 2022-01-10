using DziennikElektroniczny.Models;
using System;

namespace DziennikElektroniczny.ViewModels
{
    public class NoteView
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int? TeacherPersonId { get; set; }
        public string TeacherDisplayName { get; set; }
        public int? StudentPersonId { get; set; }
        public string StudentDisplayName { get; set; }

        public NoteView(Note note,PersonalInfo student,PersonalInfo teacher)
        {
            Id = note.NoteId;
            Description = note.Description;
            Date = note.Date;
            TeacherPersonId = note.TeacherPersonId;
            TeacherDisplayName = teacher.Name + " " + teacher.Surname;
            StudentPersonId = note.StudentPersonId;
            StudentDisplayName = student.Name + " " + student.Surname;
        }
    }
}
