namespace WebUI.Dtos.ProductDto
{
    public class UpdateProductDtoUI
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
      
        public IFormFile ImgFile { get; set; }
        public string ImgUrl { get; set; }
        public bool ProductStatus { get; set; }
        public int CategoryId { get; set; }
    }
}
