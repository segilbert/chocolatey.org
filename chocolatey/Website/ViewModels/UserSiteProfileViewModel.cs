namespace NuGetGallery
{
    public class UserSiteProfileViewModel
    {
        public UserSiteProfileViewModel(UserSiteProfile siteProfile)
        {
            Name = siteProfile.Name;
            Url = siteProfile.Url;
        }

        public string Name { get; set; }
        public string Url { get; set; } 
    }
}