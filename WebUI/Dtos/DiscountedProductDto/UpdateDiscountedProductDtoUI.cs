namespace WebUI.Dtos.DiscountedProductDto
{
    public class UpdateDiscountedProductDtoUI
    {
        public int DiscountedProductId { get; set; }
        public string Title { get; set; }
        public int DiscountRate { get; set; }

        public IFormFile ImgFile { get; set; }
        public string ImgUrl { get; set; }

		public bool isActive { get; set; }
	}
}
