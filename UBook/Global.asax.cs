using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Couchbase;
using Couchbase.Authentication;

namespace UBook
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ClusterHelper.Initialize(new Couchbase.Configuration.Client.ClientConfiguration
            {
                Servers = new List<Uri> { new Uri ("couchebase://localhost")} },new PasswordAuthenticator("Administrator","niraj@1234")
            
            );
        }
        protected void Application_End()
        {
            ClusterHelper.Close();
        }
    }
}
