namespace Blorc.Reflection
{
    // Note: this code comes from Catel:
    // https://raw.githubusercontent.com/Catel/Catel/58d964c15281728972d9f1326048fdf665045663/src/Catel.Core/Reflection/Helpers/PropertyHelper.cs

    using System;
    using System.Linq.Expressions;
    using System.Reflection;

    public static partial class PropertyHelper
    {
        public static string GetPropertyName(Expression propertyExpression, bool allowNested = false)
        {
            return GetPropertyName(propertyExpression, allowNested, false);
        }

        public static string GetPropertyName<TValue>(Expression<Func<TValue>> propertyExpression, bool allowNested = false)
        {
            var body = propertyExpression.Body;
            return GetPropertyName(body, allowNested);
        }

        public static string GetPropertyName<TModel, TValue>(Expression<Func<TModel, TValue>> propertyExpression, bool allowNested = false)
        {
            var body = propertyExpression.Body;
            return GetPropertyName(body, allowNested);
        }

        private static string GetPropertyName(Expression propertyExpression, bool allowNested = false, bool nested = false)
        {
            MemberExpression memberExpression;

            var unaryExpression = propertyExpression as UnaryExpression;
            if (unaryExpression != null)
            {
                memberExpression = unaryExpression.Operand as MemberExpression;
            }
            else
            {
                memberExpression = propertyExpression as MemberExpression;
            }

            if (memberExpression is null)
            {
                if (nested)
                {
                    return string.Empty;
                }

                throw new NotSupportedException("No member expression");
            }

            var propertyInfo = memberExpression.Member as PropertyInfo;
            if (propertyInfo is null)
            {
                if (nested)
                {
                    return string.Empty;
                }

                throw new NotSupportedException("No member expression");
            }

            if (allowNested && (memberExpression.Expression != null) && (memberExpression.Expression.NodeType == ExpressionType.MemberAccess))
            {
                var propertyName = GetPropertyName(memberExpression.Expression, true, true);

                return propertyName + (!string.IsNullOrEmpty(propertyName) ? "." : string.Empty) + propertyInfo.Name;
            }

            return propertyInfo.Name;
        }
    }
}
