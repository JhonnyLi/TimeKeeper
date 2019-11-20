using Microsoft.AspNetCore.Identity;
using System;

namespace TimeKeeper.Web.Models
{
    public class AppUser : IdentityUser
    {
        public AppUser() : base() { }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }

    }
}
