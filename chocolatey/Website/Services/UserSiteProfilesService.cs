using System.Collections.Generic;
using System.Linq;

namespace NuGetGallery
{
    public class UserSiteProfilesService : IUserSiteProfilesService
    {
        private readonly IEntityRepository<UserSiteProfile> profileRepo;

        public UserSiteProfilesService(IEntityRepository<UserSiteProfile> profileRepo)
        {
            this.profileRepo = profileRepo;
        }

        public IEnumerable<UserSiteProfile> GetUserProfiles(User user)
        {
            return profileRepo.GetAll().Where(x => x.Username == user.Username).ToList();

            //return (from p in profileRepo.GetAll()
            //        where p.Username == user.Username
            //        select p).ToList();
        }

        public void SaveProfiles(User user, EditProfileViewModel profile)
        {
            var siteProfiles = GetUserProfiles(user).AsQueryable();

            CompareAndPrepareProfile(SiteProfileConstants.Blog,profile.BlogUrl,user.Username,siteProfiles,prefix:string.Empty);
            CompareAndPrepareProfile(SiteProfileConstants.Codeplex,profile.CodeplexUserName,user.Username,siteProfiles,prefix:SiteProfileConstants.CodeplexProfilePrefix);
            CompareAndPrepareProfile(SiteProfileConstants.Github,profile.GithubUserName,user.Username,siteProfiles,prefix:SiteProfileConstants.GithubProfilePrefix);
            CompareAndPrepareProfile(SiteProfileConstants.Homepage, profile.HomepageUrl, user.Username, siteProfiles, prefix: string.Empty);
            CompareAndPrepareProfile(SiteProfileConstants.StackExchange, profile.StackExchangeUrl, user.Username, siteProfiles, prefix: string.Empty);
            CompareAndPrepareProfile(SiteProfileConstants.Twitter, profile.TwitterUserName, user.Username, siteProfiles, prefix: SiteProfileConstants.TwitterProfilePrefix);
            
            profileRepo.CommitChanges();
        }

        private void CompareAndPrepareProfile(string profileName, string profileValue,string userName, IQueryable<UserSiteProfile> siteProfiles, string prefix)
        {
            var siteProfile = siteProfiles.FirstOrDefault(x => x.Name == profileName);
            
            if (siteProfile != null && string.IsNullOrWhiteSpace(profileValue))
            {
                profileRepo.DeleteOnCommit(siteProfile);
            }

            if (siteProfile == null && !string.IsNullOrWhiteSpace(profileValue))
            {
                var newSiteProfile = new UserSiteProfile();
                newSiteProfile.Username = userName;
                newSiteProfile.Name = profileName;
                newSiteProfile.Url = prefix + profileValue;
                profileRepo.InsertOnCommit(newSiteProfile);
            }
            
            if (siteProfile != null && !string.IsNullOrWhiteSpace(profileValue))
            {
                siteProfile.Url = prefix + profileValue;
            }
        }
    }

    public static class SiteProfileConstants
    {
        public const string Twitter = "Twitter";
        public const string TwitterProfilePrefix = "http://twitter.com/";
        public const string Github = "Github";
        public const string GithubProfilePrefix = "https://github.com/";
        public const string Codeplex = "Codeplex";
        public const string CodeplexProfilePrefix = "http://www.codeplex.com/site/users/view/";
        public const string StackExchange = "StackExchange";
        public const string Homepage = "Homepage";
        public const string Blog = "Blog";
    }
}