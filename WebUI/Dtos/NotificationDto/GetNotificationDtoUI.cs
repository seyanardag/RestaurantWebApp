﻿namespace WebUI.Dtos.NotificationDto
{
    public class GetNotificationDtoUI
    {
        public int NotificationId { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool IsRead { get; set; }
    }
}