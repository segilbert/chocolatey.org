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

            CompareAndPrepareProfile(SiteProfileConstants.Blog, profile.BlogUrl, user.Username, string.Empty, siteProfiles, prefix: string.Empty);
            CompareAndPrepareProfile(SiteProfileConstants.Codeplex, profile.CodeplexUserName, user.Username, SiteProfileConstants.Images.codeplex, siteProfiles, prefix: SiteProfileConstants.CodeplexProfilePrefix);
            CompareAndPrepareProfile(SiteProfileConstants.Github, profile.GithubUserName, user.Username, SiteProfileConstants.Images.github, siteProfiles, prefix: SiteProfileConstants.GithubProfilePrefix);
            CompareAndPrepareProfile(SiteProfileConstants.Homepage, profile.HomepageUrl, user.Username, string.Empty, siteProfiles, prefix: string.Empty);
            CompareAndPrepareProfile(SiteProfileConstants.StackExchange, profile.StackExchangeUrl, user.Username, SiteProfileConstants.Images.stackexchange, siteProfiles, prefix: string.Empty);
            CompareAndPrepareProfile(SiteProfileConstants.Twitter, profile.TwitterUserName, user.Username, SiteProfileConstants.Images.twitter, siteProfiles, prefix: SiteProfileConstants.TwitterProfilePrefix);
            CompareAndPrepareProfile(SiteProfileConstants.PackagesRepository, profile.PackagesRepository, user.Username, string.Empty, siteProfiles, prefix: string.Empty);
            CompareAndPrepareProfile(SiteProfileConstants.PackagesRepositoryAuto, profile.PackagesRepositoryAuto, user.Username, string.Empty, siteProfiles, prefix: string.Empty);

            profileRepo.CommitChanges();
        }

        private void CompareAndPrepareProfile(string profileName, string profileValue, string userName, string logoUrl, IQueryable<UserSiteProfile> siteProfiles, string prefix)
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
                newSiteProfile.Image = logoUrl;
                profileRepo.InsertOnCommit(newSiteProfile);
            }

            if (siteProfile != null && !string.IsNullOrWhiteSpace(profileValue))
            {
                siteProfile.Url = prefix + profileValue;
                siteProfile.Image = logoUrl;
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
        public const string Homepage = "Personal Homepage";
        public const string Blog = "Personal Blog";
        public const string PackagesRepository = "Chocolatey Packages Repository";
        public const string PackagesRepositoryAuto = "Chocolatey Automatic Packages Repository";


        public static class Images
        {
            private const string URLPATH = "~/Content/Images";
            public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
            public static readonly string twitter = Url("twitter.png");
            public static readonly string github = Url("github.jpg");
            public static readonly string codeplex = Url("codeplex.jpg");
            public static readonly string stackexchange = Url("stackexchange.png");
            public static readonly string nothing_50x50_png = Url("nothing-50x50.png");
        }


    }
}