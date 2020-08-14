using System;
using AutoFixture.Xunit2;
using FluentAssertions;
using Xunit;

namespace Demos.AutoFixture.Tests
{
    public class EventDispatcherTests
    {
        public class SendAll
        {
            [Theory]
            [AutoData]
            public void Should_send_all_valid_events(EventDispatcher sut, Event[] events)
            {
                sut.SendAll(events);

            }
    }
    }
}