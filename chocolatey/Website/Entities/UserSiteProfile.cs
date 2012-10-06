using System.ComponentModel.DataAnnotations;

namespace NuGetGallery
{
    public class UserSiteProfile : IEntity
    {
        public int Key { get; set; }

        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Url { get; set; }
        [StringLength(400)]
        public string Image { get; set; }
        public string Username { get; set; }
    }
}