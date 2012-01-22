namespace NuGetGallery.MvcOverrides
{
    using System;
    using System.Web;

    //http://stackoverflow.com/questions/7120149/handling-urls-with-appharbor-without-modifying-all-my-controllers

    public class HttpRequestDecorator : HttpRequestProxy
    {
        public HttpRequestDecorator(HttpRequestBase innerHttpRequest)
            : base(innerHttpRequest)
        {
        }

        public override bool IsSecureConnection
        {
            get
            {
                return string.Equals(Headers["X-Forwarded-Proto"], "https", StringComparison.OrdinalIgnoreCase);
            }
        }

        public override Uri Url
        {
            get
            {
                var url = base.Url;
                var urlBuilder = new UriBuilder(url);

                if (IsSecureConnection)
                {
                    urlBuilder.Port = 443;
                    urlBuilder.Scheme = "https";
                }
                else
                {
                    urlBuilder.Port = 80;
                }

                if (RequestContext.HttpContext.Request.IsLocal)
                {
                    urlBuilder.Port = RequestContext.HttpContext.Request.Url.Port;
                }

                return urlBuilder.Uri;
            }
        }

        public override string UserHostAddress
        {
            get
            {
                const string forwardedForHeader = "HTTP_X_FORWARDED_FOR";
                var forwardedFor = ServerVariables[forwardedForHeader];
                if (forwardedFor != null)
                {
                    return forwardedFor;
                }

                return base.UserHostAddress;
            }
        }
    }
}