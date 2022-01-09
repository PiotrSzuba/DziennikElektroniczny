using System;
using DziennikElektroniczny.Models;

namespace DziennikElektroniczny.ViewModels
{
    public class SubjectView
    {
        public int Id { get; set; }
        public int? SubjectInfoId { get; set; }
        public int? TeacherPersonId { get; set; }
        public int StudentsGroupId { get; set; }
        public int ClassRoomId { get; set; }
        public SubjectView(Subject subject)
        {
            Id = subject.SubjectId;
            SubjectInfoId = subject.SubjectInfoId;
            TeacherPersonId = subject.TeacherPersonId;
            StudentsGroupId = subject.StudentsGroupId;
            ClassRoomId = subject.ClassRoomId;
        }
    }
}
