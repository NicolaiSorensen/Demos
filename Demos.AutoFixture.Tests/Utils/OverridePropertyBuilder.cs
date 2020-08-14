using System;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;
using AutoFixture.Kernel;

namespace Demos.AutoFixture.Tests.Utils
{
    public class OverridePropertyBuilder<T, TProp> : ISpecimenBuilder
    {
        private readonly PropertyInfo _propertyInfo;
        private readonly object _value;

        public OverridePropertyBuilder(Expression<Func<T, TProp>> expression, object value)
        {
            _propertyInfo = (expression.Body as MemberExpression)?.Member as PropertyInfo ??
                            throw new InvalidOperationException("invalid property expression");
            _value = value;
        }

        public PropertyInfo PropertyInfo => _propertyInfo;

        public object Create(object request, ISpecimenContext context)
        {
            var parameterInfo = request as ParameterInfo;
            if (parameterInfo == null)
            {
                return new NoSpecimen();
            }

            var camelCasedPropertyName = Regex.Replace(_propertyInfo.Name, @"(\w)(.*)", m => m.Groups[1].Value.ToLower(CultureInfo.InvariantCulture) + m.Groups[2]);

            if (parameterInfo.ParameterType != _value.GetType() || parameterInfo.Name != camelCasedPropertyName)
            {
                return new NoSpecimen();
            }

            return _value;
        }
    }
}