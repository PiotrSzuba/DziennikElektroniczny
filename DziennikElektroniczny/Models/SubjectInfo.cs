using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System;
using System.Collections.Generic;

namespace DziennikElektroniczny.Models
{
    public class SubjectInfo
    {
        [Key]
        [Range(1, 1000000000)]
        public int SubjectInfoId { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Description { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
