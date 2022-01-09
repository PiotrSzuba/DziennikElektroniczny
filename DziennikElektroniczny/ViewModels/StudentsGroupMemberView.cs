using System;
using DziennikElektroniczny.Models;

namespace DziennikElektroniczny.ViewModels
{
    public class StudentsGroupMemberView
    {
        public int Id { get; set; }
        public int? StudentsGroupId { get; set; }
        public int? StudentPersonId { get; set; }
        public StudentsGroupMemberView(StudentsGroupMember studentsGroupMember)
        {
            Id = studentsGroupMember.StudentsGroupMemberId;
            StudentsGroupId = studentsGroupMember.StudentsGroupId;
            StudentPersonId = studentsGroupMember.StudentPersonId;
        }
    }
}
