using DziennikElektroniczny.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DziennikElektroniczny.ViewModels
{
    public class Profile
    {   
        //public int Id { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Pesel { get; set; }
        public List<String> ParentsNames { get; set; } = new List<string>();

        public Profile(PersonalInfo personalInfo, List<PersonalInfo> parents)
        {
            Name = personalInfo.Name;
            SecondName = personalInfo.SecondName;
            Surname = personalInfo.Surname;
            DateOfBirth = personalInfo.DateOfBirth;
            PhoneNumber = personalInfo.PhoneNumber;
            Address = personalInfo.Address;
            Pesel = personalInfo.Pesel;
            foreach (var parent in parents)
            {
                ParentsNames.Add(parent.Name);
            }
        }

    }
}
