using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureFlag
{
    public class Feature
    {
        private readonly string name;
        private readonly DateTime startDate;
        private readonly DateTime endDate;
        private readonly StrategyBase strategy;

        public Feature(string name, StrategyBase strategy) : this(name, strategy, null, null)
        {
            
        }

        public Feature(string name, StrategyBase strategy, DateTime? startDate, DateTime? endDate)
        {
            this.name = name;
            this.strategy = strategy;
            this.startDate = startDate ?? DateTime.MinValue;
            this.endDate = endDate ?? DateTime.MaxValue;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public DateTime StartDate
        {
            get
            {
                return this.startDate;
            }
        }

        public DateTime EndDate
        {
            get
            { 
                return this.endDate;
            }
        }

        public StrategyBase Strategy
        {
            get
            {
                return this.strategy;
            }
        }
    }
}
