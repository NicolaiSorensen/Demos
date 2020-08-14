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
                var sut = fixture.Create<Event>();

                sut.Subject.Should().BeEquivalentTo("testSubject");
            }

            [Fact]
            public void Should_set_content()
            {
                var fixture = new Fixture();
                var sut = fixture.Create<Event>();

                sut.Content.Should().BeEquivalentTo("testContent");
            }
        }
    }
}
