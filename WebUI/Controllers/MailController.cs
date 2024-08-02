using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using WebUI.Dtos.MailDto;

namespace WebUI.Controllers
{
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var model = new CreateMailDto();
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(CreateMailDto createMailDto)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("signalR Mail", "seyanardag@yandex.com");            
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", createMailDto.Receiver);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBulilder = new BodyBuilder();
            bodyBulilder.TextBody = createMailDto.Content;

            mimeMessage.Body = bodyBulilder.ToMessageBody();

            mimeMessage.Subject = createMailDto.Subject;


            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.yandex.com.tr", 465, true);
            smtpClient.Authenticate("seyanardag@yandex.com", "zxtchnhkliwyuifc");

            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);
                   


            return View();
        }
    }
}
