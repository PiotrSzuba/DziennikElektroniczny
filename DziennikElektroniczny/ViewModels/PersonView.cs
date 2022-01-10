using System;
using DziennikElektroniczny.Models;

namespace DziennikElektroniczny.ViewModels
{
    public class PersonView
    {
        public int Id { get; set; }
        public int Role { get; set; }
        public string Login { get; set; }
        public string HashedPassword { get; set; }
        public int PersonalInfoId { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Pesel { get; set; }
        public PersonView(Person person,PersonalInfo personalInfo)
        {
            Id = person.PersonId;
            Role = person.Role;
            Login = person.Login;
            HashedPassword = person.HashedPassword;
            PersonalInfoId = person.PersonalInfoId;
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
