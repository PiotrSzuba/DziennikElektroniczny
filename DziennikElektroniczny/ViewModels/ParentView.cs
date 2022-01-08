using DziennikElektroniczny.Models;
using System;

namespace DziennikElektroniczny.ViewModels
{
    public class ParentView
    {
        public int Id { get; set; }
        public int? PersonId { get; set; }
        public int? StudentId { get; set; }
        public ParentView(Parent parent)
        {
            Id = parent.ParentId;
            PersonId = parent.ParentPersonId;
            StudentId = parent.StudentPersonId;
        }
    }
}
