using System;
using DziennikElektroniczny.Models;

namespace DziennikElektroniczny.ViewModels
{
    public class PersonalInfoView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Pesel { get; set; }
        public PersonalInfoView(PersonalInfo personalInfo)
        {
            Id = personalInfo.PersonalInfoId;
            Name = personalInfo.Name;
            SecondName = personalInfo.SecondName;
            Surname = personalInfo.Surname;
            DateOfBirth = personalInfo.DateOfBirth;
            PhoneNumber = personalInfo.PhoneNumber;
            Address = personalInfo.Address;
            Pesel = personalInfo.Pesel;
        }
    }
}
