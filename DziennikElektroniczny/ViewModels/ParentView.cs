using DziennikElektroniczny.Models;
using System;

namespace DziennikElektroniczny.ViewModels
{
    public class ParentView
    {
        public int Id { get; set; }
        public int? ParentPersonId { get; set; }
        public string ParentDisplayName { get; set; }
        public int? StudentPersonId { get; set; }
        public string StudentDisplayName { get; set; }
        public ParentView(Parent parent, PersonalInfo parentInfo, PersonalInfo studentInfo)
        {
            Id = parent.ParentId;
            ParentPersonId = parent.ParentPersonId;
            ParentDisplayName = parentInfo.Name + " " + parentInfo.Surname;
            StudentPersonId = parent.StudentPersonId;
            StudentDisplayName = studentInfo.Name + " " + studentInfo.Surname;
        }
    }
}
