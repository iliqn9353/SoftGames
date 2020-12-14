namespace SoftGamesShop.Web.Controllers
{
    using System.Net;
    using System.Net.Mail;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SoftGamesShop.Data.Common.Repositories;
    using SoftGamesShop.Data.Models;
    using SoftGamesShop.Web.ViewModels.Contacts;

    public class ContactsController : Microsoft.AspNetCore.Mvc.Controller
    {
        private const string RedirectedFromContactForm = "RedirectedFromContactForm";
        private readonly IDeletableEntityRepository<ContactsModel> contactRepository;

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
        [System.Obsolete]
        public async Task<IActionResult> SendMail(ContactFormViewModel contactsModel)
        {
            var fromAddress = new MailAddress("softgamesshop@gmail.com", contactsModel.Name);
            var toAddress = new MailAddress("iliqn9353@gmail.com", "To Name");
            var subject = contactsModel.Title;
            var body = contactsModel.Content;
            const string fromPassword = "101020Ik";

            var smtp = new System.Net.Mail.SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body + " Message was sent by: " + contactsModel.Name + " E-mail: " + contactsModel.Email,
            })
            {
                smtp.Send(message);
            }

            var email = new ContactsModel
            {
                Name = contactsModel.Name,
                Email = contactsModel.Email,
                Message = contactsModel.Content,
                Subject = contactsModel.Title,
            };
            await this.contactRepository.AddAsync(email);
            await this.contactRepository.SaveChangesAsync();
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
