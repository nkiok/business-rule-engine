using System;
using System.Collections.Generic;
using CSharpFunctionalExtensions;
using Engine.Core.Commands;
using Engine.Core.Domain;

namespace Engine.Core.Rules
{
    public class MembershipStatusNotificationRule : IBusinessRule<OrderContext>
    {
        private readonly ISender _sender;

        private readonly IDictionary<ProductType, Func<OrderContext, Result>> _notificationMap =  new Dictionary<ProductType, Func<OrderContext, Result>>();

        public MembershipStatusNotificationRule(ISender sender)
        {
            _sender = sender;

            _notificationMap[ProductType.NewMembership] = SendActivationNotificationCommand;
            _notificationMap[ProductType.UpgradeMembership] = SendUpgradeNotificationCommand;
        }

        public Result Apply(OrderContext context) 
            => Result.SuccessIf(Predicate(context.Product), Consts.RuleDoesNotApply).Tap(() => _notificationMap[context.Product.Type].Invoke(context));

        private static bool Predicate(Product product) 
            => product.Type == ProductType.NewMembership || product.Type == ProductType.UpgradeMembership;

        private Result SendActivationNotificationCommand(OrderContext context)
        {
            _sender.Send(new MembershipActivationNotificationCommand(context.Product, context.OrderMaster.Id));

            return Result.Success();
        }

        private Result SendUpgradeNotificationCommand(OrderContext context)
        {
            _sender.Send(new MembershipUpgradeNotificationCommand(context.Product, context.OrderMaster.Id));

            return Result.Success();
        }
    }
}
