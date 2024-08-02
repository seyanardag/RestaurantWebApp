namespace WebUI.Dtos.DiscountedProductDto
{
    public class ResultDiscountedProductDtoUI
    {
        public int DiscountedProductId { get; set; }
        public string Title { get; set; }
        public int DiscountRate { get; set; }
        public string ImgUrl { get; set; }
		public bool isActive { get; set; }
	}
}
