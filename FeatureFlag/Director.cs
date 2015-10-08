using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureFlag
{
    public class Director : IDirector
    {
        private readonly Configuration config;

        public Director(Configuration config)
        {
            this.config = config;
        }

        public bool AreAllFeaturesEnabled(ExpandoObject args = null)
        {
            bool result = true;

            foreach (Feature feature in this.config.Features)
            {
                result = result && IsFeatureEnabled(feature, args);
            }

            return result;
        }

        public bool IsAnyFeatureEnabled(ExpandoObject args = null)
        {
            bool result = false;

            foreach (Feature feature in this.config.Features)
            {
                result = result || IsFeatureEnabled(feature, args);
            }

            return result;
        }

        public bool IsEnabled(string name, ExpandoObject args = null)
        {
            bool result = false;
            Feature feature = this.config.GetFeature(name);
            if (feature != null)
            {
                result = IsFeatureEnabled(feature, args);
            }
            return result;
        }

        private bool IsFeatureEnabled(Feature feature, ExpandoObject args)
        {
            return feature.Strategy.IsEnabled(args) && IsInDateRange(feature);
        }

        private bool IsInDateRange(Feature feature)
        {
            DateTime now = DateTime.Now;
            return (now >= feature.StartDate && now <= feature.EndDate);
        }
    }
}
