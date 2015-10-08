using System;
using System.Collections.Generic;
using System.Linq;
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
            this.director = Director.GetInstance();
        }

        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            if (director.IsAnyFeatureEnabled() && !controllerName.EndsWith("_B"))
            {
                controllerName = $"{controllerName}_B";
            }
            return base.CreateController(requestContext, controllerName);

        }

        protected override Type GetControllerType(RequestContext requestContext, string controllerName)
        {
            if (director.IsAnyFeatureEnabled() && !controllerName.EndsWith("_B"))
            {
                controllerName = $"{controllerName}_B";
            }
            return base.GetControllerType(requestContext, controllerName);
        }
    }
}