using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureFlag.Strategies
{
    public class OffStrategy : StrategyBase
    {
        public OffStrategy() : base(null) { }

        public override bool IsEnabled(ExpandoObject args)
        {
            return false;
        }
    }
}
