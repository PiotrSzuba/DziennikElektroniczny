using System;
using DziennikElektroniczny.Models;

namespace DziennikElektroniczny.ViewModels
{
    public class StudentsGroupView
    {
        public int Id { get; set; }
        public int? TeacherId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int YearOfStudy { get; set; }
        public StudentsGroupView(StudentsGroup studentsGroup)
        {
            Id = studentsGroup.StudentsGroupId;
            TeacherId = studentsGroup.TeacherPersonId;
            Title = studentsGroup.Title;
            Description = studentsGroup.Description;
            YearOfStudy = studentsGroup.YearOfStudy;
        }
    }
}
