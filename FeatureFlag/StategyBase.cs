using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureFlag
{
    public delegate bool IsEnabled(ExpandoObject args);

    public abstract class StrategyBase
    {
        private readonly IsEnabled function;

        protected StrategyBase(IsEnabled function)
        {
            this.function = function;
        }

        public virtual bool IsEnabled(ExpandoObject args)
        {
            return this.function(args);
        }
    }
}
