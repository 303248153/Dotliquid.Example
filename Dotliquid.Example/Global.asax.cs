using Dotliquid.Example.Dotliquid;
using DotLiquid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Dotliquid.Example
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // DotLiquid的初始化
            Template.FileSystem = new DotliquidTemplateFileSystem();
            Template.RegisterFilter(typeof(DotliquidCustomFilter));
            Template.RegisterTag<ConditionalTag>("conditional");
            Template.RegisterSafeType(typeof(ExampleViewModel), Hash.FromAnonymousObject);
        }
    }
}