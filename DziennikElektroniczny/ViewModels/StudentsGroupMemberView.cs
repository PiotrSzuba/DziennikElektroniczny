using System;
using DziennikElektroniczny.Models;

namespace DziennikElektroniczny.ViewModels
{
    public class StudentsGroupMemberView
    {
        public int Id { get; set; }
        public int? StudentGroupId { get; set; }
        public int? StudentId { get; set; }
        public StudentsGroupMemberView(StudentsGroupMember studentsGroupMember)
        {
            Id = studentsGroupMember.StudentsGroupMemberId;
            StudentGroupId = studentsGroupMember.StudentsGroupId;
            StudentId = studentsGroupMember.StudentPersonId;
        }
    }
}
