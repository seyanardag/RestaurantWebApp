namespace WebUI.Dtos.TestimonialDto

{
    public class CreateTestimonialDtoUI
    {
       
        public string WriterName { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
         public IFormFile ImgFile { get; set; }
        public string ImgUrl { get; set; }
        public bool Status { get; set; }
    }
}
