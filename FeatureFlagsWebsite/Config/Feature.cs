using System;
using System.Runtime.Serialization;

namespace FeatureFlags.Config
{
    [DataContract]
    public class ConfigFeature
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "strategy")]
        public string Strategy { get; set; }

        [DataMember(Name = "startDate")]
        public DateTime StartDate { get; set; }

        [DataMember(Name = "endDate")]
        public DateTime EndDate { get; set; }
    }
}
