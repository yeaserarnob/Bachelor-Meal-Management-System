﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OracleRepository.Entity
{
    public class User : Entity
    {
        public String Username { get; set; }
        public String Password { get; set; }
    }
}
