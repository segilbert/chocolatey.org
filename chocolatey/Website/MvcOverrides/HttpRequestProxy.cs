namespace NuGetGallery.MvcOverrides
{
    using System;
    using System.Collections.Specialized;
    using System.IO;
    using System.Security.Authentication.ExtendedProtection;
    using System.Security.Principal;
    using System.Text;
    using System.Web;
    using System.Web.Routing;

    //http://stackoverflow.com/questions/7120149/handling-urls-with-appharbor-without-modifying-all-my-controllers

    public abstract class HttpRequestProxy : HttpRequestBase
    {
        private readonly HttpRequestBase _innerHttpRequest;

        public HttpRequestProxy(HttpRequestBase innerHttpRequest)
        {
            _innerHttpRequest = innerHttpRequest;
        }

        public override string[] AcceptTypes
        {
            get
            {
                return _innerHttpRequest.AcceptTypes;
            }
        }

        public override string AnonymousID
        {
            get
            {
                return _innerHttpRequest.AnonymousID;
            }
        }

        public override string ApplicationPath
        {
            get
            {
                return _innerHttpRequest.ApplicationPath;
            }
        }

        public override string AppRelativeCurrentExecutionFilePath
        {
            get
            {
                return _innerHttpRequest.AppRelativeCurrentExecutionFilePath;
            }
        }

        public override byte[] BinaryRead(int count)
        {
            return _innerHttpRequest.BinaryRead(count);
        }

        public override HttpBrowserCapabilitiesBase Browser
        {
            get
            {
                return _innerHttpRequest.Browser;
            }
        }

        public override HttpClientCertificate ClientCertificate
        {
            get
            {
                return _innerHttpRequest.ClientCertificate;
            }
        }

        public override Encoding ContentEncoding
        {
            get
            {
                return _innerHttpRequest.ContentEncoding;
            }
            set
            {
                _innerHttpRequest.ContentEncoding = value;
            }
        }

        public override int ContentLength
        {
            get
            {
                return _innerHttpRequest.ContentLength;
            }
        }

        public override string ContentType
        {
            get
            {
                return _innerHttpRequest.ContentType;
            }
            set
            {
                _innerHttpRequest.ContentType = value;
            }
        }

        public override HttpCookieCollection Cookies
        {
            get
            {
                return _innerHttpRequest.Cookies;
            }
        }

        public override string CurrentExecutionFilePath
        {
            get
            {
                return _innerHttpRequest.CurrentExecutionFilePath;
            }
        }

        public override string FilePath
        {
            get
            {
                return _innerHttpRequest.FilePath;
            }
        }

        public override HttpFileCollectionBase Files
        {
            get
            {
                return _innerHttpRequest.Files;
            }
        }

        public override Stream Filter
        {
            get
            {
                return _innerHttpRequest.Filter;
            }
            set
            {
                _innerHttpRequest.Filter = value;
            }
        }

        public override NameValueCollection Form
        {
            get
            {
                return _innerHttpRequest.Form;
            }
        }

        public override NameValueCollection Headers
        {
            get
            {
                return _innerHttpRequest.Headers;
            }
        }

        public override ChannelBinding HttpChannelBinding
        {
            get
            {
                return _innerHttpRequest.HttpChannelBinding;
            }
        }

        public override string HttpMethod
        {
            get
            {
                return _innerHttpRequest.HttpMethod;
            }
        }

        public override Stream InputStream
        {
            get
            {
                return _innerHttpRequest.InputStream;
            }
        }

        public override bool IsAuthenticated
        {
            get
            {
                return _innerHttpRequest.IsAuthenticated;
            }
        }

        public override bool IsLocal
        {
            get
            {
                return _innerHttpRequest.IsLocal;
            }
        }

        public override bool IsSecureConnection
        {
            get
            {
                return _innerHttpRequest.IsSecureConnection;
            }
        }

        public override WindowsIdentity LogonUserIdentity
        {
            get
            {
                return _innerHttpRequest.LogonUserIdentity;
            }
        }

        public override int[] MapImageCoordinates(string imageFieldName)
        {
            return _innerHttpRequest.MapImageCoordinates(imageFieldName);
        }

        public override string MapPath(string virtualPath)
        {
            return _innerHttpRequest.MapPath(virtualPath);
        }

        public override string MapPath(string virtualPath, string baseVirtualDir, bool allowCrossAppMapping)
        {
            return _innerHttpRequest.MapPath(virtualPath, baseVirtualDir, allowCrossAppMapping);
        }

        public override NameValueCollection Params
        {
            get
            {
                return _innerHttpRequest.Params;
            }
        }

        public override string Path
        {
            get
            {
                return _innerHttpRequest.Path;
            }
        }

        public override string PathInfo
        {
            get
            {
                return _innerHttpRequest.PathInfo;
            }
        }

        public override string PhysicalApplicationPath
        {
            get
            {
                return _innerHttpRequest.PhysicalApplicationPath;
            }
        }

        public override string PhysicalPath
        {
            get
            {
                return _innerHttpRequest.PhysicalPath;
            }
        }

        public override NameValueCollection QueryString
        {
            get
            {
                return _innerHttpRequest.QueryString;
            }
        }

        public override string RawUrl
        {
            get
            {
                return _innerHttpRequest.RawUrl;
            }
        }

        public override RequestContext RequestContext
        {
            get
            {
                return _innerHttpRequest.RequestContext;
            }
        }

        public override string RequestType
        {
            get
            {
                return _innerHttpRequest.RequestType;
            }
            set
            {
                _innerHttpRequest.RequestType = value;
            }
        }

        public override void SaveAs(string filename, bool includeHeaders)
        {
            _innerHttpRequest.SaveAs(filename, includeHeaders);
        }

        public override NameValueCollection ServerVariables
        {
            get
            {
                return _innerHttpRequest.ServerVariables;
            }
        }

        public override string this[string key]
        {
            get
            {
                return _innerHttpRequest[key];
            }
        }

        public override int TotalBytes
        {
            get
            {
                return _innerHttpRequest.TotalBytes;
            }
        }

        public override Uri Url
        {
            get
            {
                return _innerHttpRequest.Url;
            }
        }

        public override Uri UrlReferrer
        {
            get
            {
                return _innerHttpRequest.UrlReferrer;
            }
        }

        public override string UserAgent
        {
            get
            {
                return _innerHttpRequest.UserAgent;
            }
        }

        public override string UserHostAddress
        {
            get
            {
                return _innerHttpRequest.UserHostAddress;
            }
        }

        public override string UserHostName
        {
            get
            {
                return _innerHttpRequest.UserHostName;
            }
        }

        public override string[] UserLanguages
        {
            get
            {
                return _innerHttpRequest.UserLanguages;
            }
        }

        public override void ValidateInput()
        {
            _innerHttpRequest.ValidateInput();
        }
    }
}