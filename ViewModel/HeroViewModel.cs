﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskApp.ViewModel
{
    public class HeroViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public Group GroupName { get; set; }
        public string HeroGroupName { get; set; }

    }
}
