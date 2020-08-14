using System.Linq;
using AutoFixture;

namespace Demos.AutoFixture.Tests.Utils
{
    public static class AutoFixtureExtensions
    {
        public static IFixture ConstructorArgumentFor<TTargetType, TValueType>(
            this IFixture fixture,
            string parameterName,
            TValueType value)
        {
            var existingRegistrations = fixture.Customizations
                .Where(x => x is ConstructorArgumentRelay<TTargetType, TValueType>)
                .Select(x => x as ConstructorArgumentRelay<TTargetType, TValueType>)
                .Where(x => x.ParameterName == parameterName).ToList();

            foreach (var existingRegistration in existingRegistrations)
            {
                fixture.Customizations.Remove(existingRegistration);
            }

            fixture.Customizations.Add(new ConstructorArgumentRelay<TTargetType, TValueType>(parameterName, value));

            return fixture;
        }
    }
}