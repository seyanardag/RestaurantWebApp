namespace WebUI.Dtos.AboutDto
{
    public class GetAboutDtoUI
    {
        public int AboutId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
		public bool isSelected { get; set; }
	}
}
