using System;
using System.Collections.Generic;
using DziennikElektroniczny.Models;

namespace DziennikElektroniczny.ViewModels
{
    public class StudentsGroupView
    {
        public int Id { get; set; }
        public int? TeacherPersonId { get; set; }
        public string TeacherDisplayName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int YearOfStudy { get; set; }
        public List<string> StudentsDisplayNames { get; set; } = new();
        public StudentsGroupView(StudentsGroup studentsGroup,PersonalInfo teacherInfo,List<PersonalInfo> studentsInfos)
        {
            Id = studentsGroup.StudentsGroupId;
            TeacherPersonId = studentsGroup.TeacherPersonId;
            TeacherDisplayName = teacherInfo.Name + " " + teacherInfo.Surname;
            Title = studentsGroup.Title;
            Description = studentsGroup.Description;
            YearOfStudy = studentsGroup.YearOfStudy;
            foreach (var student in studentsInfos)
            {
                StudentsDisplayNames.Add(student.Name + " " + student.Surname);
            }
        }
    }
}
