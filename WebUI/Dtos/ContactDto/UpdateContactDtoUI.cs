namespace WebUI.Dtos.ContactDto
{
    public class UpdateContactDtoUI
    {
        public int ContactId { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
		public bool isSelected { get; set; }

	}
}
