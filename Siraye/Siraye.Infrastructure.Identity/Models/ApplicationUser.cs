using Microsoft.AspNetCore.Identity;
using Siraye.Application.DTOs.Account;
using System;
using System.Collections.Generic;
using System.Text;

namespace Siraye.Infrastructure.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<RefreshToken> RefreshTokens { get; set; }
        public bool OwnsToken(string token)
        {
            return this.RefreshTokens?.Find(x => x.Token == token) != null;
        }
        public static ApplicationUser ToDto(this ApplicationUser userData)
        {
            return new ApplicationUser
            {
                Id = userData.Id,
                FirstName = userData.FirstName,
                LastName = userData.LastName,
                Email = userData.Email

            };
        }
    }
}
