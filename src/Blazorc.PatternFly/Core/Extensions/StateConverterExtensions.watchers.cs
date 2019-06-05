namespace Blazorc.PatternFly
{
    using System;
    using System.Linq.Expressions;

    public static partial class StateConverterContainerExtensions
    {
        public static StateConverterContainer Watch<TProperty>(this StateConverterContainer container, Expression<Func<TProperty>> propertyExpression)
        {
            var owner = ExpressionHelper.GetOwner(propertyExpression);
            var propertyName = ExpressionHelper.GetPropertyName(propertyExpression);

            return container.Add(new PropertyStateWatcher(owner, propertyName));
        }
    }
}
