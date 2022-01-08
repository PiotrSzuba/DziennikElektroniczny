using System;
using DziennikElektroniczny.Models;

namespace DziennikElektroniczny.ViewModels
{
    public class SubjectInfoView
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public SubjectInfoView(SubjectInfo subjectInfo)
        {
            Id = subjectInfo.SubjectInfoId;
            Title = subjectInfo.Title;
            Description = subjectInfo.Description;
        }
    }
}
