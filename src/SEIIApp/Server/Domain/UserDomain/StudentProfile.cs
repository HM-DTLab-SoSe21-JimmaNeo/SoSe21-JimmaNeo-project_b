﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace SEIIApp.Server.Domain
{
    public class StudentProfile
    {
        public string name { get; set; }
        public string description { get; set; }
        public int experience { get; set; }
    }
}
