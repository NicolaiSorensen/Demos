using System;
using AutoFixture;
using AutoFixture.Xunit2;
using FluentAssertions;
using Xunit;

namespace Demos.AutoFixture.Tests
{
    public class EventTestWithAutoData
    {
        public class Constructor
        {
            [Theory]
            [AutoData]
            public void Should_set_Created_to_now(Event sut)
            {
                sut.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(1));

                // hmmm ok that nice!
            }

            [Theory]
            [AutoData]
            public void Should_set_subject(Event sut)
            {
                sut.Subject.Should().BeEquivalentTo("testSubject");

                // damnit I forgot this was still a problem!
            }

            [Theory]
            [AutoData]
            public void Should_set_content([Frozen]Fixture fixture, Event sut)
            {
                fixture.Inject("testContent");

                sut.Content.Should().BeEquivalentTo("testContent");

                //wait what? What the hell is [Frozen]? Whats this inject doing?
            }

            [Theory]
            [AutoData]
            public void Should_set_priority(Event sut, [Frozen] Fixture fixture)
            {
                fixture.Register<int>(() => 1);
                
                sut.Priority.Should().Be(1);

                // Ok but what about this Register method? is that not the same ? wait ?! why is it not returning 1 anymore? Its just parameter order?!

            }
        }
    }
}
