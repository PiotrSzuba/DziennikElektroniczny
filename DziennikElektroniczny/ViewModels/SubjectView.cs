using System;
using DziennikElektroniczny.Models;

namespace DziennikElektroniczny.ViewModels
{
    public class SubjectView
    {
        public int Id { get; set; }
        public int? SubjectInfoId { get; set; }
        public int? TeacherId { get; set; }
        public int StudentsGroupId { get; set; }
        public int ClassRoomId { get; set; }
        public SubjectView(Subject subject)
        {
            Id = subject.SubjectId;
            SubjectInfoId = subject.SubjectInfoId;
            TeacherId = subject.TeacherPersonId;
            StudentsGroupId = subject.StudentsGroupId;
            ClassRoomId = subject.ClassRoomId;
        }
    }
}
