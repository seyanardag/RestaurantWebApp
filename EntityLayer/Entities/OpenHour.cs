﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class OpenHour
    {
        public int Id { get; set; }
        public string OpenDays { get; set; }
        public string OpeningHour { get; set; }
        public string ClosingHour { get; set; }
        public bool IsActive { get; set; }
    }
}
