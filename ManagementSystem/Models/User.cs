using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagementSystem.Models
{
    public class User : Entity
    {
        public Boolean IsValid { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
    }
}