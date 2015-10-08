using System.Dynamic;

namespace FeatureFlag
{
    public interface IDirector
    {
        bool IsEnabled(string name, ExpandoObject args = null);

        bool IsAnyFeatureEnabled(ExpandoObject args = null);

        bool AreAllFeaturesEnabled(ExpandoObject args = null);
    }
}