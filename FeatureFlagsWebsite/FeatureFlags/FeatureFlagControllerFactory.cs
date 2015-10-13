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
        private const string FeatureControllerSuffix = "_B";
        private const string ControllersNamespace = "FeatureFlags.Controllers";
        private const string ControllerSuffix = "Controller";

        private IDirector director;

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

        private bool ControllerExists(string controllerName)
        {
            string fullControllerName = ControllersNamespace + "." + controllerName + ControllerSuffix;
            return (Type.GetType(fullControllerName, false) != null);
        }

        private string CheckRequiredFeaturesEnabledAndRewriteControllerName(string controllerName, Func<bool> featureFunction)
        {
            if (!controllerName.EndsWith(FeatureControllerSuffix))
                if (featureFunction())
                {
                    string bControllerName = controllerName + FeatureControllerSuffix;
                    controllerName = ControllerExists(bControllerName) ? bControllerName : controllerName;
                }
            return controllerName;
        }

        private string CheckAnyFeatureEnabledAndRewriteControllerName(string controllerName)
        {
            return CheckRequiredFeaturesEnabledAndRewriteControllerName(controllerName, () => director.IsAnyFeatureEnabled());
        }

        private string CheckAllFeaturesEnabledAndRewriteControllerName(string controllerName)
        {
            return CheckRequiredFeaturesEnabledAndRewriteControllerName(controllerName, () => director.AreAllFeaturesEnabled());
        }

        private string CheckNamedFeatureEnabledAndRewriteControllerName(string controllerName, string featureName, ExpandoObject args)
        {
            if (!controllerName.EndsWith(FeatureControllerSuffix))
                if (director.IsEnabled(featureName, args))
                {
                    string bControllerName = controllerName + FeatureControllerSuffix;
                    controllerName = ControllerExists(bControllerName) ? bControllerName : controllerName;
                }
            return controllerName;
        }

    }
}