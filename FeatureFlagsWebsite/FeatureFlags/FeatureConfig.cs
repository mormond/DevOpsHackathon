using FeatureFlag;
using FeatureFlag.Strategies;
using FeatureFlags.Config;
using Newtonsoft.Json;
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

            Features features = ReadConfigFeatures();

            foreach (ConfigFeature featureConfig in features.Feature)
            {
                Feature feature = new Feature(featureConfig.Name, new OnStrategy(), featureConfig.StartDate, featureConfig.EndDate);
                this.config.AddFeature(feature);
            }

            //Feature feature = new Feature("Fred", new OnStrategy(), null, DateTime.Parse("25/9/2015")); 

            
        }

        public IDirector CreateFeatureDirector()
        {
            return new Director(config);   
        }

        private Features ReadConfigFeatures()
        {
            const string CONFIG = "FeatureConfiguration";
            string json = System.Configuration.ConfigurationManager.AppSettings[CONFIG];
            Features features = JsonConvert.DeserializeObject<Features>(json);
            return features;
        }

    }
}