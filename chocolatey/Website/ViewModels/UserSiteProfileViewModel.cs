namespace NuGetGallery
{
    public class UserSiteProfileViewModel
    {
        public UserSiteProfileViewModel(UserSiteProfile siteProfile)
        {
            Name = siteProfile.Name;
            Url = siteProfile.Url;
            Image = siteProfile.Image;
        }

        public string Name { get; set; }
        public string Url { get; set; }
        public string Image { get; set; }
    }
}