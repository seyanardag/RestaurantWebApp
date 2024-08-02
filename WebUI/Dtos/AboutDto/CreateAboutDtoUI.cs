namespace WebUI.Dtos.AboutDto
{
    public  class CreateAboutDtoUI
    {
      
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile ImgFile { get; set; }

        public string ImgUrl { get; set; }
		public bool isSelected { get; set; }
	}
}
