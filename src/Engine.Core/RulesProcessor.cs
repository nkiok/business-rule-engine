using System.Collections.Generic;
using Engine.Core.Domain;
using Engine.Core.Rules;

namespace Engine.Core
{
    public class RulesProcessor
    {
        private readonly IEnumerable<IBusinessRule<OrderContext>> _rules;

        public RulesProcessor(IEnumerable<IBusinessRule<OrderContext>> rules)
        {
            _rules = rules;
        }

        public void ApplyRules(OrderContext context)
        {
            foreach (var rule in _rules)
            {
                rule.Apply(context);
            }
        }
    }
}
