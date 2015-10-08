using FeatureFlag;
using FeatureFlag.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureFlagTestConsole
{
    class Program
    {
        const string ON_FEATURE_NAME = "OnFeature";
        const string OUT_OF_DATE = "Out of Date";

        static void Main(string[] args)
        {
            Configuration config = new Configuration();
            Feature onFeature = SetUpOnFeature();
            config.AddFeature(onFeature);
            Feature oldEndDateFeature = SetUpOnFeatureWithEndDateInPast();
            config.AddFeature(oldEndDateFeature);
            IDirector director = new Director(config);
            Console.WriteLine(director.IsEnabled(ON_FEATURE_NAME));
            Console.WriteLine(director.IsEnabled(OUT_OF_DATE));
            Console.WriteLine(director.IsAnyFeatureEnabled());
            Console.WriteLine(director.AreAllFeaturesEnabled());

            Console.ReadLine();

        }

        private static Feature SetUpOnFeature()
        {
            return new Feature(ON_FEATURE_NAME, new OnStrategy());
        }

        private static Feature SetUpOnFeatureWithEndDateInPast()
        {
            return new Feature(OUT_OF_DATE, new OnStrategy(), null, DateTime.Parse("25/9/2015"));
        }

    }
}
