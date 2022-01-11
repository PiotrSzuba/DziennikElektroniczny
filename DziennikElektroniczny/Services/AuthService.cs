using DziennikElektroniczny.Data;
using DziennikElektroniczny.Models;
using DziennikElektroniczny.ViewModels;
using JWT.Algorithms;
using JWT.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace DziennikElektroniczny.Services
{
    public class AuthService
    {
        private readonly DziennikElektronicznyContext _context;
        private static String secret = "SDFDSo#isejfs!@DASD(#FSHDAHAIUF";
       
        public AuthService(DziennikElektronicznyContext context)
        {
            this._context = context;
        }
        
        public string AuthenticateCredentials(LoginView loginView)
        {
            var person = _context.Person.Where(person => person.Login == loginView.Login).FirstOrDefault();
            if (person == null) throw new HttpResponseException(HttpStatusCode.Unauthorized);
            // todo hashing
            if (person.HashedPassword == loginView.Password)
            {
                return this.GenerateJWT(person);
            }

            return null;
        }

        public string GenerateJWT(Person person)
        {
            var token = JwtBuilder.Create()
                      .WithAlgorithm(new HMACSHA256Algorithm()) // symmetric
                      .WithSecret(secret)
                      //.AddClaim("exp", DateTimeOffset.UtcNow.AddHours(24).ToUnixTimeSeconds())
                      .AddClaim("personId", person.PersonId)
                      .Encode();
            
            return token;
        }

        public Person GetPersonFromJWT(string token)
        {
            var payload = JwtBuilder.Create()
                        .WithAlgorithm(new HMACSHA256Algorithm()) // symmetric
                        .WithSecret(secret)
                        .MustVerifySignature()
                        .Decode<IDictionary<string, object>>(token);
            int personId = (int) payload["personId"];
            if (personId < 1) return null;

            var person = _context.Person.Where(person => person.PersonId == personId).FirstOrDefault();
            return person;
        }
    }
}
