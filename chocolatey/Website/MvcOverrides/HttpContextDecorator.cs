namespace NuGetGallery.MvcOverrides
{
    using System.Web;

    //http://stackoverflow.com/questions/7120149/handling-urls-with-appharbor-without-modifying-all-my-controllers

    public class HttpContextDecorator : HttpContextProxy
    {
        public HttpContextDecorator(HttpContextBase innerHttpContext)
            : base(innerHttpContext)
        {
        }

        public override HttpRequestBase Request
        {
            get
            {
                return new HttpRequestDecorator(base.Request);
            }
        }
    }
}