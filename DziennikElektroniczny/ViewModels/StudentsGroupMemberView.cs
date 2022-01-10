using System;
using DziennikElektroniczny.Models;

namespace DziennikElektroniczny.ViewModels
{
    public class StudentsGroupMemberView
    {
        public int Id { get; set; }
        public int? StudentsGroupId { get; set; }
        public string StudentsGroupName { get; set; }
        public int? StudentPersonId { get; set; }
        public string StudentDisplayName { get; set; }
        public StudentsGroupMemberView(StudentsGroupMember studentsGroupMember, StudentsGroup studentsGroup, PersonalInfo studentInfo)
        {
            Id = studentsGroupMember.StudentsGroupMemberId;
            StudentsGroupId = studentsGroupMember.StudentsGroupId;
            StudentsGroupName = studentsGroup.Title;
            StudentPersonId = studentsGroupMember.StudentPersonId;
            StudentDisplayName = studentInfo.Name + " " + studentInfo.Surname;
        }
    }
}
