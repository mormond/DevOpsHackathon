using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace FeatureFlags
{
    public interface IDirector
    {
        bool IsEnabled(string name, ExpandoObject args = null);

        bool IsAnyFeatureEnabled(ExpandoObject args = null);

        bool AreAllFeaturesEnabled(ExpandoObject args = null);
    }
}