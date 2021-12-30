using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System;


namespace DziennikElektroniczny.Models
{
    public class Parent
    {
        [Key]
        [Required]
        [Range(1, 1000000000)]
        public int ParentId { get; set; }

        [Range(1, 1000000000)]
        public int? ParentPersonId { get; set; }

        [Range(1, 1000000000)]
        public int? StudentPersonId { get; set; }

        public virtual Person ParentPerson { get; set; }
        public virtual Person StudentPerson { get; set; }
    }
}
