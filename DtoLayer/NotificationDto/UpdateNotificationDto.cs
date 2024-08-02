﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.NotificationDto
{
    public class UpdateNotificationDto
    {
        public int NotificationId { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool IsRead { get; set; }
    }
}
