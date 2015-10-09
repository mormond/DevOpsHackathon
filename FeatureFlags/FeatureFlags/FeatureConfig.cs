using FeatureFlag;
using FeatureFlag.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FeatureFlags
{
    public class FeatureConfig
    {
        private Configuration config;

        public FeatureConfig()
        {
            this.config = new Configuration();

            Feature feature = new Feature("Fred", new OnStrategy(), null, DateTime.Parse("25/9/2015")); 

            this.config.AddFeature(feature);
        }

        public IDirector CreateFeatureDirector()
        {
            return new Director(config);   
        }

    }
}