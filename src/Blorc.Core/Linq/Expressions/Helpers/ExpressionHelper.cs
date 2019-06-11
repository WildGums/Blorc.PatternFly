namespace Blorc.Linq.Expressions
{
    // Note: this code comes from Catel:
    // https://github.com/Catel/Catel/blob/58d964c15281728972d9f1326048fdf665045663/src/Catel.Core/Helpers/ExpressionHelper.cs

    using System;
    using System.Linq.Expressions;
    using System.Reflection;
    using Blorc.Reflection;

    public static class ExpressionHelper
    {
        public static string GetPropertyName<TSource, TProperty>(Expression<Func<TSource, TProperty>> propertyExpression)
        {
            return PropertyHelper.GetPropertyName(propertyExpression);
        }

        public static string GetPropertyName<TProperty>(Expression<Func<TProperty>> propertyExpression)
        {
            return PropertyHelper.GetPropertyName(propertyExpression);
        }

        public static object GetOwner<TProperty>(Expression<Func<TProperty>> propertyExpression)
        {
            var expressionToHandle = GetExpressionToHandle(propertyExpression);

            var body = expressionToHandle as MemberExpression;
            if (body is null)
            {
                return null;
            }

            var constantExpression = body.Expression as ConstantExpression;
            if (constantExpression != null)
            {
                return constantExpression.Value;
            }

            var memberExpression = body.Expression as MemberExpression;
            if (memberExpression != null)
            {
                var resolvedMemberExpression = ResolveMemberExpression(memberExpression);
                return resolvedMemberExpression;
            }

            return null;
        }

        private static object ResolveMemberExpression(MemberExpression memberExpression)
        {
            var fieldInfo = memberExpression.Member as FieldInfo;
            if (fieldInfo != null)
            {
                var ownerConstantExpression = memberExpression.Expression as ConstantExpression;
                if (ownerConstantExpression != null)
                {
                    return fieldInfo.GetValue(ownerConstantExpression.Value);
                }
            }

            var propertyInfo = memberExpression.Member as PropertyInfo;
            if (propertyInfo != null)
            {
                var ownerConstantExpression = memberExpression.Expression as ConstantExpression;
                if (ownerConstantExpression != null)
                {
                    return propertyInfo.GetValue(ownerConstantExpression.Value, null);
                }

                // Note: this is support for .NET native
                var subMemberExpression = memberExpression.Expression as MemberExpression;
                if (subMemberExpression != null)
                {
                    var resolvedMemberExpression = ResolveMemberExpression(subMemberExpression);
                    return propertyInfo.GetValue(resolvedMemberExpression, null);
                }
            }

            // Fallback but is a bit slower
            var lamdaExpression = Expression.Lambda(memberExpression);
            return lamdaExpression.Compile().DynamicInvoke();
        }

        private static Expression GetExpressionToHandle<TProperty>(Expression<Func<TProperty>> propertyExpression)
        {
            var expressionToHandle = propertyExpression.Body;

            // Might occur in Android, maybe on other platforms as well
            var unaryExpression = expressionToHandle as UnaryExpression;
            if (unaryExpression != null)
            {
                expressionToHandle = unaryExpression.Operand;
            }

            return expressionToHandle;
        }
    }
}
