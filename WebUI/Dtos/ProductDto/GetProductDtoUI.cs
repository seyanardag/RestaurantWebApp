namespace WebUI.Dtos.ProductDto
{
    public class GetProductDtoUI
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImgUrl { get; set; }
        public bool ProductStatus { get; set; }
        public int CategoryId { get; set; }
    }
}
