using DziennikElektroniczny.Models;
using System;

namespace DziennikElektroniczny.ViewModels
{
    public class ParentView
    {
        public int Id { get; set; }
        public int? ParentPersonId { get; set; }
        public int? StudentPersonId { get; set; }
        public ParentView(Parent parent)
        {
            Id = parent.ParentId;
            ParentPersonId = parent.ParentPersonId;
            StudentPersonId = parent.StudentPersonId;
        }
    }
}
