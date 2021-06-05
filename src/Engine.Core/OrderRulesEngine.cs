using Engine.Core.Domain;

namespace Engine.Core
{
    public class OrderRulesEngine
    {
        private readonly RulesProcessor _rulesProcessor;

        public OrderRulesEngine(RulesProcessor rulesProcessor)
        {
            _rulesProcessor = rulesProcessor;
        }

        public void Run(Order order)
        {
            foreach (var product in order.Detail.Products)
            {
                _rulesProcessor.ApplyRules(new OrderContext(order.Master, product));
            }
        }
    }
}
