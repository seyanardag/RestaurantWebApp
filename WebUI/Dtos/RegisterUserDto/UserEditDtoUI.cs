using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebUI.Dtos.RegisterUserDto
{
    public class UserEditDtoUI
    {
        [Required(ErrorMessage = "Bu alan zorunludur")]
        [Display(Name = "Ad")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur")]
        [DisplayName("Soyad")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur")]
        [DisplayName("Kullanıcı Adı")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur")]
        [DisplayName("Şifre")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur")]
        [DisplayName("Şifre Tekrar")]
        [Compare("Password")]
        public string PasswordConfirm { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur")]
        [DisplayName("e-posta")]
        public string Email { get; set; }
      
        public string ImageUrl { get; set; }
        public IFormFile ImageFile { get; set; } = null;
    }
}
