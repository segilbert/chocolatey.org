namespace NuGetGallery.MvcOverrides
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    //http://stackoverflow.com/questions/7120149/handling-urls-with-appharbor-without-modifying-all-my-controllers

    public class CustomMvcRouteHandler : MvcRouteHandler
    {
        protected override IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new CustomMvcHandler(requestContext);
        }
    }
}
