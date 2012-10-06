using System.ComponentModel.DataAnnotations;

namespace NuGetGallery
{
    public class EditProfileViewModel
    {
        [Required]
        [StringLength(255)]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(?i)^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$", ErrorMessage = "This doesn't appear to be a valid email address.")]
        public string EmailAddress { get; set; }

        public string PendingNewEmailAddress { get; set; }

        [Display(Name = "Receive Email Notifications")]
        public bool EmailAllowed { get; set; }

        [Display(Name = "Twitter Username")]
        [StringLength(255)]
        public string TwitterUserName { get; set; }
        
        [Display(Name = "Github Username")]
        [StringLength(255)]
        public string GithubUserName { get; set; }

        [Display(Name = "Codeplex Username")]
        [StringLength(255)]
        public string CodeplexUserName { get; set; }
        
        [Display(Name = "StackExchange Profile Url")]
        [StringLength(255)]
        public string StackExchangeUrl { get; set; }
        
        [Display(Name = "Homepage Url")]
        [StringLength(255)]
        public string HomepageUrl { get; set; } 
        
        [Display(Name = "Blog Url")]
        [StringLength(255)]
        public string BlogUrl { get; set; }      
        
        [Display(Name = "Chocolatey Packages Repository")]
        [StringLength(255)]
        public string PackagesRepository { get; set; }
  
        [Display(Name = "Chocolatey Automatic Packages Repository")]
        [StringLength(255)]
        public string PackagesRepositoryAuto { get; set; }


    }
}