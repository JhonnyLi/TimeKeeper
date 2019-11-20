using Microsoft.AspNetCore.Identity;
using System;

namespace TimeKeeper.Web.Models
{
    public class AppRole : IdentityRole
    {
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }

        public AppRole() : base() { }

        public AppRole(string roleName) : base(roleName)
        {
        }
        public AppRole(string roleName, string description, DateTime creationDate) : base(roleName)
        {
            Description = description;
            CreationDate = creationDate;
        }
    }
}
