using FluentAssertions;
using KataWardrobe.Core.Domain;
using System;
using Xunit;

namespace KataWardrobe.Test.WardrobeElementTests
{
    public class WardrobeElementShould
    {
        [Fact]
        public void Throw_argument_exception_when_built_with_zero_size() 
        {
            Action action = () => new WardrobeElement(0);

            action.Should().Throw<ArgumentException>();
        }

        [Theory]
        [InlineData(50)]
        [InlineData(75)]
        [InlineData(100)]
        [InlineData(120)]
        public void Only_be_available_in_fixed_sizes(uint size) 
        {
            var element = new WardrobeElement(size);

            element.Size.Should().Be(size);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(45)]
        [InlineData(250)]
        [InlineData(550)]
        public void Throw_exception_if_not_allowed_size(uint size) 
        {
            Action action = () => new WardrobeElement(size);

            action.Should().Throw<Exception>();
        }

        [Theory]
        [InlineData(50,59)]
        [InlineData(75, 62)]
        [InlineData(100, 90)]
        [InlineData(120, 111)]
        public void Have_fixed_price_dependant_on_its_size(uint size, uint price) 
        {
            var element = new WardrobeElement(size);

            element.Price.Should().Be(price);
        }
    }
}
