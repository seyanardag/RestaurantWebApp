using System.ComponentModel.DataAnnotations;

namespace WebUI.Dtos.MailDto
{
    public class CreateMailDto
    {
       
        public string Receiver { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }


    }
}
