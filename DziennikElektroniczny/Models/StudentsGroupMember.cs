using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System;
using System.Collections.Generic;

namespace DziennikElektroniczny.Models
{
    public class StudentsGroupMember
    {
        [Key]
        [Required]
        [Range(1, 1000000000)]
        public int StudentsGroupMemberId { get; set; }

        [Range(1, 1000000000)]
        public int? StudentsGroupId { get; set; }
        public StudentsGroup StudentsGroup { get; set; }

        [Range(1, 1000000000)]
        public int? StudentPersonId { get; set; }
        public Person StudentPerson { get; set; }
    }
}
