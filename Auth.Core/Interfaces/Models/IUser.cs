﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Core.Interfaces.Models
{
    public interface IUser
    {
        public string UUID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
