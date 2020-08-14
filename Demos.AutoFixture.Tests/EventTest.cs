using System;
using AutoFixture;
using FluentAssertions;
using Xunit;

namespace Demos.AutoFixture.Tests
{
    public class EventTest
    {
        public class Constructor
        {
            [Fact]
            public void Should_set_Created_to_now()
            {
                var fixture = new Fixture();
                var sut = fixture.Create<Event>();

                sut.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(1));
            }

            [Fact]
            public void Should_set_subject()
            {
                var fixture = new Fixture();

                var sut = fixture.Build<Event>().With(x => x.Subject, "testSubject").Create();

                sut.Subject.Should().BeEquivalentTo("testSubject");
            }

            [Fact]
            public void Should_set_content()
            {
                var fixture = new Fixture();
                fixture.Customize<Event>(composer => composer.With(x => x.Subject, "testSubject"));

                var sut = fixture.Create<Event>();

                sut.Content.Should().BeEquivalentTo("testContent");
            }

            [Fact]
            public void Should_set_priority()
            {
                var fixture = new Fixture();
                var priority = 1;
                fixture.Register<Event>(() => new Event(fixture.Create<string>(), fixture.Create<string>(), priority));
                
                var sut = fixture.Create<Event>();

                sut.Priority.Should().Be(1);

                // this works. but why is it not a good idea?
            }
        }
    }
}
