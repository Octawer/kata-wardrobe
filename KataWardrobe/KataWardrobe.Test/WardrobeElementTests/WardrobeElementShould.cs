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
        [InlineData(1)]
        [InlineData(25)]
        [InlineData(uint.MaxValue)]
        public void Not_throw_argument_exception_when_built_with_positive_size(uint size)
        {
            Action action = () => new WardrobeElement(size);

            action.Should().NotThrow<Exception>();
        }
    }
}
