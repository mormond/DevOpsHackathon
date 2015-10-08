using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace FeatureFlags
{
    public class Director : IDirector
    {

        public static IDirector GetInstance()
        {
            return new Director();
        }

        public bool AreAllFeaturesEnabled(ExpandoObject args = null)
        {
            return true;
        }

        public bool IsAnyFeatureEnabled(ExpandoObject args = null)
        {
            return true;
        }

        public bool IsEnabled(string name, ExpandoObject args = null)
        {
            return true;
        }
    }
}