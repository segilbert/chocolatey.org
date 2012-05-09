namespace NuGetGallery
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceModel.Syndication;
    using System.Web.Mvc;

    public class RssController : Controller
    {
        private readonly IPackageService packageSvc;
        public IConfiguration Configuration { get; set; }

        public RssController(
            IPackageService packageSvc,
            IConfiguration configuration
        )
        {
            this.packageSvc = packageSvc;
            Configuration = configuration;
        }

        [ActionName("feed.rss")]
        public ActionResult Feed(int? page, int? pageSize)
        {
            var siteRoot = EnsureTrailingSlash(Configuration.GetSiteRoot(useHttps:false));
            IQueryable<Package> packageVersions = packageSvc.GetLatestPackageVersions(allowPrerelease: false)
                .OrderByDescending(p => p.Published);

            SyndicationFeed feed = new SyndicationFeed("Chocolatey", "Chocolatey Packages", new Uri(siteRoot));
            feed.Copyright = new TextSyndicationContent("Chocolatey copyright FerventCoder Software, Packages copyright original owner(s), Products copyright original author(s).");
            feed.Language = "en-US";

            List<SyndicationItem> items = new List<SyndicationItem>();
            foreach (Package package in packageVersions.ToList())
            {
                string title = string.Format("{0} ({1})", package.PackageRegistration.Id, package.Version);
                var galleryUrl = siteRoot + "packages/" + package.PackageRegistration.Id + "/" + package.Version;
                SyndicationItem item = new SyndicationItem(
                        title,
                        package.Summary,
                        new Uri(galleryUrl),
                        package.PackageRegistration.Id + "." + package.Version,
                        package.Published
                    );
                item.PublishDate = package.Published;

                items.Add(item);
            }
            //this will bomb until you have one published package in the feed.
            feed.LastUpdatedTime = packageVersions.First().Published;
            feed.Items = items;

            return new RSSActionResult { Feed = feed };
        }

        private static string EnsureTrailingSlash(string siteRoot)
        {
            if (!siteRoot.EndsWith("/", StringComparison.Ordinal))
            {
                siteRoot = siteRoot + '/';
            }
            return siteRoot;
        }

        //private IEnumerable<Package> GetPackagesFromRepo()
        //{
        //    var packages = PackageRepo.GetAll().Where(p => p.Listed);
        //    //packages = packages.Where(p => !p.IsPrerelease);
        //    //packages.OrderByDescending(p => p.Published);

        //    return packages;
        //}
    }
}