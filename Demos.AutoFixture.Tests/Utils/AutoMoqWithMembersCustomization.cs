using AutoFixture.AutoMoq;

namespace Demos.AutoFixture.Tests.Utils
{
    public class AutoMoqWithMembersCustomization : AutoMoqCustomization
    {
        public AutoMoqWithMembersCustomization()
        {
            ConfigureMembers = true;
        }
    }
}