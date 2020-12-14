namespace SoftGamesShop.Web.ViewModels.Contacts
{
    using System.ComponentModel.DataAnnotations;

    public class ContactFormViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter you'r name")]
        [StringLength(10, ErrorMessage = "Name must be at least {2} and not more than {1} symbols.", MinimumLength = 3)]
        [Display(Name = "You'r name here.")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter you'r email adress")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [Display(Name = "You'r email address")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a subject for the message")]
        [StringLength(100, ErrorMessage = "Subject must be at least {2} and not more than {1} symbols.", MinimumLength = 5)]
        [Display(Name = "Message subject")]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your message")]
        [StringLength(10000, ErrorMessage = "Message must be at least {2} symbols.", MinimumLength = 20)]
        [Display(Name = "Message content")]
        public string Content { get; set; }
    }
}
