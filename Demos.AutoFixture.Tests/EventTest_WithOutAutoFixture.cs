using System;
using FluentAssertions;
using Xunit;

namespace Demos.AutoFixture.Tests
{
    public class EventTest_WithOutAutoFixture
    {
        public class Constructor
        {
            [Fact]
            public void Should_set_Created_to_now()
            {
                var sut = new Event("testSubject", "testContent", 1);

                sut.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(1));
            }

            [Fact]
            public void Should_set_subject()
            {
                var sut = new Event("testSubject", "testContent", 1);

                sut.Subject.Should().BeEquivalentTo("testSubject");
            }

            [Fact]
            public void Should_set_content()
            {
                var sut = new Event("testSubject", "testContent", 1);

                sut.Content.Should().BeEquivalentTo("testContent");
            }
        }
    }
}