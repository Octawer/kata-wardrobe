using FluentAssertions;
using KataWardrobe.Core.Domain;
using KataWardrobe.Core.Domain.Enums;
using System;
using Xunit;

namespace KataWardrobe.Test.WardrobeElementTests
{
    public class WardrobeElementShould
    {

        [Fact]
        public void Throw_argument_exception_when_built_with_zero_size() 
        {
            Action action = () => WardrobeFactory.Build(0);

            action.Should().Throw<ArgumentException>();
        }

        [Theory]
        [InlineData(WardrobeElementSize.S, 50)]
        [InlineData(WardrobeElementSize.M, 75)]
        [InlineData(WardrobeElementSize.L, 100)]
        [InlineData(WardrobeElementSize.XL, 120)]
        public void Only_be_available_in_fixed_sizes(WardrobeElementSize size, int cms) 
        {
            var element = WardrobeFactory.Build(size);

            element.Size.Should().Be(cms);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(45)]
        [InlineData(250)]
        [InlineData(550)]
        public void Throw_exception_if_not_allowed_size(int size) 
        {
            Action action = () => WardrobeFactory.Build((WardrobeElementSize)size);

            action.Should().Throw<Exception>();
        }

        [Theory]
        [InlineData(WardrobeElementSize.S, 59)]
        [InlineData(WardrobeElementSize.M, 62)]
        [InlineData(WardrobeElementSize.L, 90)]
        [InlineData(WardrobeElementSize.XL, 111)]
        public void Have_fixed_price_dependant_on_its_size(WardrobeElementSize size, int price) 
        {
            var element = WardrobeFactory.Build(size);

            element.Price.Should().Be(price);
        }
    }
}
