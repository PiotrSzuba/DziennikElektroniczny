using DziennikElektroniczny.Models;
using System;

namespace DziennikElektroniczny.ViewModels
{
    public class NoteView
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int? TeacherId { get; set; }
        public int? StudentId { get; set; }
        public NoteView(Note note)
        {
            Id = note.NoteId;
            Description = note.Description;
            TeacherId = note.TeacherPersonId;
            StudentId = note.StudentPersonId;
            Description = note.Description;
            Date = note.Date;
        }
    }
}
