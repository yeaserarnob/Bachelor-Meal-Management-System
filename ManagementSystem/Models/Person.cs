using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagementSystem.Models
{
    public class Person : Entity
    {
        public Boolean IsAdmin { get; set; }
        public String Name { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
    }
}