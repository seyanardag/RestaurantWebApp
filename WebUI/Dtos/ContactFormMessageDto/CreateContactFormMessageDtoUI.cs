﻿
namespace WebUI.Dtos.ContactFormMessageDto
{
	public class CreateContactFormMessageDtoUI
	{
		
		public string NameSurname { get; set; }
		public string Mail { get; set; }
		public string Phone { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public DateTime Date { get; set; }
		public bool IsRead { get; set; }
	}
}
