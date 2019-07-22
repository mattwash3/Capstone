using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class ApplicationUser : IdentityUser
    {
        //public int UserId { get; set; }
        //userManager.AddClaim(id, new Claim("UserId", UserId));
        public string RoleString { get; set; }
        public ApplicationUser() : base() { }       
    }
}
