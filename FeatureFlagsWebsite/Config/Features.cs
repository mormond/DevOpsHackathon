using System.Runtime.Serialization;

namespace FeatureFlags.Config
{
    [DataContract]
    public class Features
    {
        [DataMember(Name = "features")]
        public ConfigFeature[] Feature { get; set; }
    }
}
