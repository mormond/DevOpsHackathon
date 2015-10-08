using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureFlag
{
    public class Configuration
    {
        private readonly Dictionary<string, Feature> features = new Dictionary<string, Feature>();

        public Configuration()
        {
        }

        public void AddFeature(Feature feature)
        {
            this.features.Add(feature.Name, feature);
        }

        public Feature GetFeature(string featureName)
        {
            return this.features[featureName];
        }

        public List<Feature> Features
        {
            get
            {
                return this.features.Values.ToList<Feature>();
            }
        }
    }
}
