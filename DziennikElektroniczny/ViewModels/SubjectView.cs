using System;
using DziennikElektroniczny.Models;

namespace DziennikElektroniczny.ViewModels
{
    public class SubjectView
    {
        public int Id { get; set; }
        public int? SubjectInfoId { get; set; }
        public string SubjectName { get; set; }
        public int? TeacherPersonId { get; set; }
        public string TeacherName { get; set; } 
        public int StudentsGroupId { get; set; }
        public string StudentsGroupName { get; set; }
        public int ClassRoomId { get; set; }
        public string ClassRoomName { get; set; }
        public string ClassRoomFloor { get; set; }
        public string ClassRoomBuilding { get; set; }
        public string SubjectDescription { get; set; }

        public SubjectView(Subject subject,SubjectInfo subjectInfo,ClassRoom classRoom,StudentsGroup studentsGroup,PersonalInfo teacherInfo)
        {
            Id = subject.SubjectId;
            SubjectInfoId = subject.SubjectInfoId;
            SubjectName = subjectInfo.Title;
            TeacherPersonId = subject.TeacherPersonId;
            TeacherName = teacherInfo.Name + " " + teacherInfo.Surname;
            StudentsGroupId = subject.StudentsGroupId;
            StudentsGroupName = studentsGroup.Title;
            ClassRoomId = subject.ClassRoomId;
            ClassRoomName = classRoom.Destination;
            ClassRoomFloor = classRoom.Floor;
            ClassRoomBuilding = classRoom.Building;
            SubjectDescription = subjectInfo.Description;


        }
    }
}
