using FeatureFlag;
using System;
using System.Dynamic;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FeatureFlags
{
    public class FeatureFlagControllerFactory : DefaultControllerFactory
    {
        IDirector director;

        public FeatureFlagControllerFactory()
        {
            MvcApplication app = HttpContext.Current.ApplicationInstance as MvcApplication;

            if (app != null)
            {
                this.director = app.FeatureFlagConfiguration.CreateFeatureDirector();
            }
            else
            {
                throw new NullReferenceException("Could not access MvcApplication object");
            }
        }

        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            string newControllerName = CheckAnyFeatureEnabledAndRewriteControllerName(controllerName);
            return base.CreateController(requestContext, newControllerName);
        }

        protected override Type GetControllerType(RequestContext requestContext, string controllerName)
        {
            string newControllerName = CheckAnyFeatureEnabledAndRewriteControllerName(controllerName);
            return base.GetControllerType(requestContext, newControllerName);
        }


        private string CheckAnyFeatureEnabledAndRewriteControllerName(string controllerName)
        {
            if (director.IsAnyFeatureEnabled() && !controllerName.EndsWith("_B"))
            {
                controllerName = $"{controllerName}_B";
            }
            return controllerName;
        }

        private string CheckAllFeaturesEnabledAndRewriteControllerName(string controllerName)
        {
            if (director.AreAllFeaturesEnabled() && !controllerName.EndsWith("_B"))
            {
                controllerName = $"{controllerName}_B";
            }
            return controllerName;
        }

        private string CheckNamedFeatureEnabledAndRewriteControllerName(string controllerName, string featureName, ExpandoObject args)
        {
            if (director.IsEnabled(featureName, args) && !controllerName.EndsWith("_B"))
            {
                controllerName = $"{controllerName}_B";
            }
            return controllerName;
        }

    }
}