using AutoFixture;

namespace Demos.AutoFixture.Tests.Utils
{
    public static class FixtureExtensions
    {
        public static FixtureCustomization<T> Construct<T>(this IFixture fixture)
            => new FixtureCustomization<T>(fixture);
    }
}
