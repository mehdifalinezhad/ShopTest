using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UploadsClean.Domain.Entities.Users
{
    public class ApplicationUser : IdentityUser
    {
        public string FarsiFirstName { set; get; }
        public string FarsiLastName { get; set; }

        public string Password { get; set; }
        public string Role { get; set; }


    }
}
