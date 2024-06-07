using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Autokuca.Model
{
    public class ApplicationUser : IdentityUser
    {
        //dodatna svojstva koja idu u tablicu sa predefiniranim
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}