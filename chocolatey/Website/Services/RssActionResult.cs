namespace NuGetGallery
{
    using System.ServiceModel.Syndication;
    using System.Web.Mvc;
    using System.Xml;

    public class RSSActionResult : ActionResult
    {
        public SyndicationFeed Feed { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.ContentType = "application/rss+xml";

            if (Feed != null)
            {
                Rss20FeedFormatter rssFormatter = new Rss20FeedFormatter(Feed);

                using (var xmlWriter = new XmlTextWriter(context.HttpContext.Response.Output))
                {
                    xmlWriter.Formatting = Formatting.Indented;
                    rssFormatter.WriteTo(xmlWriter);
                }
            }
        }
    }
}