using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace FeatureFlags
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private FeatureConfig featureConfig;

        public FeatureConfig FeatureFlagConfiguration {

            get
            {
                if (this.featureConfig == null)
                {
                    this.featureConfig = new FeatureConfig();
                }

                return this.featureConfig;
            }
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ControllerBuilder.Current.SetControllerFactory(typeof(FeatureFlags.FeatureFlagControllerFactory));
        }
    }
}
