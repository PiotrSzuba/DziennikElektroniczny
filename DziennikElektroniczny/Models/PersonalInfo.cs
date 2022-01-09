using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System;
using System.Collections.Generic;

namespace DziennikElektroniczny.Models
{
    public class PersonalInfo
    {
#nullable enable annotations
        [Key]
        public int PersonalInfoId { get; set; }

        [Required]
        [Column(TypeName = "varchar(40)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(40)")]
        public string? SecondName { get; set; }

        [Required]
        [Column(TypeName = "varchar(40)")]
        public string Surname { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Column(TypeName = "varchar(12)")]
        public string? PhoneNumber { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Address { get; set; }

        [Required]
        [Column(TypeName = "varchar(15)")]
        public string Pesel { get; set; }

        public virtual ICollection<Person> Persons { get; set; }

    }
}
