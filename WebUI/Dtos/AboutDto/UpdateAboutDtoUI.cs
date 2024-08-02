namespace WebUI.Dtos.AboutDto
{
    public class UpdateAboutDtoUI
    {
        public int AboutId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile ImgFile { get; set; }

        public string ImgUrl { get; set; }
		public bool isSelected { get; set; }
	}
}
