using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using AutoFixture;

namespace Demos.AutoFixture.Tests.Utils
{
    public class FixtureCustomization<T>
    {
        public FixtureCustomization(IFixture fixture)
        {
            Fixture = fixture;
        }

        public IFixture Fixture { get; }

        public FixtureCustomization<T> With<TProp>(Expression<Func<T, TProp>> expression, object value)
        {
            var existingRegistrations = Fixture.Customizations
                .Where(x => x is OverridePropertyBuilder<T, TProp>)
                .Select(x => x as OverridePropertyBuilder<T, TProp>)
                .Where(x => x.PropertyInfo.Name == ((expression.Body as MemberExpression)?.Member as PropertyInfo)?.Name).ToList();

            foreach (var existingRegistration in existingRegistrations)
            {
                Fixture.Customizations.Remove(existingRegistration);
            }

            Fixture.Customizations.Add(new OverridePropertyBuilder<T, TProp>(expression, value));

            return this;
        }

        public T Create() => Fixture.Create<T>();
    }
}