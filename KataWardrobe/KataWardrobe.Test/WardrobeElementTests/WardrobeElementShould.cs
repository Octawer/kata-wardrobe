using FluentAssertions;
using KataWardrobe.Core.Domain;
using System;
using Xunit;

namespace KataWardrobe.Test.WardrobeElementTests
{
    public class WardrobeElementShould
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-25)]
        [InlineData(int.MinValue)]
        public void Throw_argument_exception_when_built_with_invalid_size(int size) 
        {
            Action action = () => new WardrobeElement(size);

            action.Should().Throw<ArgumentException>();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(25)]
        [InlineData(int.MaxValue)]
        public void Have_valid_size_when_built_with_positive_size(int size)
        {
            var element = new WardrobeElement(size);

            element.HasValidSize.Should().BeTrue();
        }
    }
}
