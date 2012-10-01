namespace NuGetGallery
{
    public class UserSiteProfile : IEntity
    {
        public int Key { get; set; }

        public string Name { get; set; }
        public string Url { get; set; }
        public string Username { get; set; }
    }
}