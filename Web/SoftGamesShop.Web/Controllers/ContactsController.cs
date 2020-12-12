namespace SoftGamesShop.Web.Controllers
{

    using MailKit.Net.Smtp;
    using Microsoft.AspNetCore.Mvc;
    using MimeKit;
    using MimeKit.Text;
    using SoftGamesShop.Data.Common.Repositories;
    using SoftGamesShop.Data.Models;
    using System.Threading.Tasks;

    public class ContactsController : Microsoft.AspNetCore.Mvc.Controller
    {
        IDeletableEntityRepository<ContactsModel> contactRepository;
        private const string RedirectedFromContactForm = "RedirectedFromContactForm";

        public ContactsController(IDeletableEntityRepository<ContactsModel> contactRepository)
        {
            this.contactRepository = contactRepository;
        }

        public IActionResult Contact()
        {
            this.ViewData["Message"] = "Your contact page.";

            return this.View();
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<IActionResult> SendMail(ContactsModel contactsModel)
        {
            if (this.ModelState.IsValid)
            {
                var message = new MimeMessage();

                message.To.Add(new MailboxAddress("iliqn9353@gmail.com"));

                message.From.Add(new MailboxAddress("softgamesshop@gmail.com"));

                message.Subject = contactsModel.Subject;

                message.Body = new TextPart(TextFormat.Html)
                {
                    Text = contactsModel.Message + " Message was sent by: " + contactsModel.Name + " E-mail: " + contactsModel.Email,
                };

                using (var emailClient = new SmtpClient())
                {
                    emailClient.Connect("smtp.gmail.com", 587, false);
                    emailClient.Authenticate("softgamesshop@gmail.com", "101020Ik");//Delete before deploy !
                    emailClient.Send(message);
                    emailClient.Disconnect(false);
                }

                var email = new ContactsModel
                {
                    Name = contactsModel.Name,
                    Email = contactsModel.Email,
                    Message = contactsModel.Message,
                    Subject = contactsModel.Subject,
                };
                await this.contactRepository.AddAsync(email);
                await this.contactRepository.SaveChangesAsync();
            }

            this.TempData[RedirectedFromContactForm] = true;
            return this.RedirectToAction("ThankYou");
        }

        public IActionResult ThankYou()
        {
            if (this.TempData[RedirectedFromContactForm] == null)
            {
                return this.NotFound();
            }

            return this.View();
        }
    }
}
