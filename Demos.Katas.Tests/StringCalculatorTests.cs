using FluentAssertions;
using Xunit;

namespace Demos.Katas.Tests
{
    public class StringCalculatorTests
    {
        public class Add
        {
            [Fact]
            public void Given_emptystring_Then_return_0()
            {
                var sut = new StringCalculator();

                var result = sut.Add(string.Empty);

                result.Should().Be(0);
            }

            [Fact]
            public void Given_single_number_should_return_that_number()
            {
                var sut = new StringCalculator();

                var result = sut.Add("1");

                result.Should().Be(1);
            }
        }
    }
}