namespace NuGetGallery.MvcOverrides
{
    using System;
    using System.Collections;
    using System.Globalization;
    using System.Security.Principal;
    using System.Web;
    using System.Web.Caching;
    using System.Web.Profile;
    using System.Web.SessionState;

    //http://stackoverflow.com/questions/7120149/handling-urls-with-appharbor-without-modifying-all-my-controllers

    public abstract class HttpContextProxy : HttpContextBase
    {
        private readonly HttpContextBase _innerHttpContext;

        protected HttpContextProxy(HttpContextBase innerHttpContext)
        {
            _innerHttpContext = innerHttpContext;
        }

        public override void AddError(Exception errorInfo)
        {
            _innerHttpContext.AddError(errorInfo);
        }

        public override Exception[] AllErrors
        {
            get
            {
                return _innerHttpContext.AllErrors;
            }
        }

        public override HttpApplicationStateBase Application
        {
            get
            {
                return _innerHttpContext.Application;
            }
        }

        public override HttpApplication ApplicationInstance
        {
            get
            {
                return _innerHttpContext.ApplicationInstance;
            }
            set
            {
                _innerHttpContext.ApplicationInstance = value;
            }
        }

        public override Cache Cache
        {
            get
            {
                return _innerHttpContext.Cache;
            }
        }

        public override void ClearError()
        {
            _innerHttpContext.ClearError();
        }

        public override IHttpHandler CurrentHandler
        {
            get
            {
                return _innerHttpContext.CurrentHandler;
            }
        }

        public override RequestNotification CurrentNotification
        {
            get
            {
                return _innerHttpContext.CurrentNotification;
            }
        }

        public override Exception Error
        {
            get
            {
                return _innerHttpContext.Error;
            }
        }

        public override object GetGlobalResourceObject(string classKey, string resourceKey)
        {
            return _innerHttpContext.GetGlobalResourceObject(classKey, resourceKey);
        }

        public override object GetGlobalResourceObject(string classKey, string resourceKey, CultureInfo culture)
        {
            return _innerHttpContext.GetGlobalResourceObject(classKey, resourceKey, culture);
        }

        public override object GetLocalResourceObject(string virtualPath, string resourceKey)
        {
            return _innerHttpContext.GetLocalResourceObject(virtualPath, resourceKey);
        }

        public override object GetLocalResourceObject(string virtualPath, string resourceKey, CultureInfo culture)
        {
            return _innerHttpContext.GetLocalResourceObject(virtualPath, resourceKey, culture);
        }

        public override object GetSection(string sectionName)
        {
            return _innerHttpContext.GetSection(sectionName);
        }

        public override object GetService(Type serviceType)
        {
            return _innerHttpContext.GetService(serviceType);
        }

        public override IHttpHandler Handler
        {
            get
            {
                return _innerHttpContext.Handler;
            }
            set
            {
                _innerHttpContext.Handler = value;
            }
        }

        public override bool IsCustomErrorEnabled
        {
            get
            {
                return _innerHttpContext.IsCustomErrorEnabled;
            }
        }

        public override bool IsDebuggingEnabled
        {
            get
            {
                return _innerHttpContext.IsDebuggingEnabled;
            }
        }

        public override bool IsPostNotification
        {
            get
            {
                return _innerHttpContext.IsPostNotification;
            }
        }

        public override IDictionary Items
        {
            get
            {
                return _innerHttpContext.Items;
            }
        }

        public override IHttpHandler PreviousHandler
        {
            get
            {
                return _innerHttpContext.PreviousHandler;
            }
        }

        public override ProfileBase Profile
        {
            get
            {
                return _innerHttpContext.Profile;
            }
        }

        public override void RemapHandler(IHttpHandler handler)
        {
            _innerHttpContext.RemapHandler(handler);
        }

        public override HttpRequestBase Request
        {
            get
            {
                return _innerHttpContext.Request;
            }
        }

        public override HttpResponseBase Response
        {
            get
            {
                return _innerHttpContext.Response;
            }
        }

        public override void RewritePath(string filePath, string pathInfo, string queryString)
        {
            _innerHttpContext.RewritePath(filePath, pathInfo, queryString);
        }

        public override void RewritePath(string filePath, string pathInfo, string queryString, bool setClientFilePath)
        {
            _innerHttpContext.RewritePath(filePath, pathInfo, queryString, setClientFilePath);
        }

        public override void RewritePath(string path)
        {
            _innerHttpContext.RewritePath(path);
        }

        public override void RewritePath(string path, bool rebaseClientPath)
        {
            _innerHttpContext.RewritePath(path, rebaseClientPath);
        }

        public override HttpServerUtilityBase Server
        {
            get
            {
                return _innerHttpContext.Server;
            }
        }

        public override HttpSessionStateBase Session
        {
            get
            {
                return _innerHttpContext.Session;
            }
        }

        public override void SetSessionStateBehavior(SessionStateBehavior sessionStateBehavior)
        {
            _innerHttpContext.SetSessionStateBehavior(sessionStateBehavior);
        }

        public override bool SkipAuthorization
        {
            get
            {
                return _innerHttpContext.SkipAuthorization;
            }
            set
            {
                _innerHttpContext.SkipAuthorization = value;
            }
        }

        public override DateTime Timestamp
        {
            get
            {
                return _innerHttpContext.Timestamp;
            }
        }

        public override TraceContext Trace
        {
            get
            {
                return _innerHttpContext.Trace;
            }
        }

        public override IPrincipal User
        {
            get
            {
                return _innerHttpContext.User;
            }
            set
            {
                _innerHttpContext.User = value;
            }
        }
    }
}