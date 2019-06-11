namespace Blorc.StateConverters
{
    using System;
    using System.Linq.Expressions;
    using Blorc.Linq.Expressions;

    public static partial class StateConverterContainerExtensions
    {
        public static StateConverterContainer Update<TProperty>(this StateConverterContainer container, Expression<Func<TProperty>> propertyExpression)
        {
            var owner = ExpressionHelper.GetOwner(propertyExpression);
            var propertyName = ExpressionHelper.GetPropertyName(propertyExpression);

            return container.Add(new PropertyStateUpdater(owner, propertyName));
        }
    }
}
