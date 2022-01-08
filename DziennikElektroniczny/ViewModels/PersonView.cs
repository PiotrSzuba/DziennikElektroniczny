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
        public PersonView(Person person)
        {
            Id = person.PersonId;
            Role = person.Role;
            Login = person.Login;
            HashedPassword = person.HashedPassword;
            PersonalInfoId = person.PersonalInfoId;
        }
    }
}
