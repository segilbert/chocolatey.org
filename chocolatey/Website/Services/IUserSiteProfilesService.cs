using System.Collections.Generic;

namespace NuGetGallery
{
    public interface IUserSiteProfilesService
    {
        IEnumerable<UserSiteProfile> GetUserProfiles(User user);
        void SaveProfiles(User user,EditProfileViewModel profile);
    }
}