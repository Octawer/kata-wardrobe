using FluentAssertions;
using KataWardrobe.Core.Domain;
using System;
using System.Collections.Generic;
using Xunit;

namespace KataWardrobe.Test.FurnitureDealerTests
{
    public class IsWardrobeFittingWallShould
    {
        private readonly FurnitureDealer _sut;

        public IsWardrobeFittingWallShould()
        {
            _sut = new FurnitureDealer();
        }

        [Fact]
        public void Throw_ArgumentNullException_when_null_is_passed()
        {
            List<WardrobeElement> elements = null;

            Action action = () => _sut.IsWardrobeFittingWall(elements);

            var exception = action.Should().Throw<ArgumentNullException>().Which;
            exception.ParamName.Should().Contain(nameof(WardrobeElement));
        }

        [Fact]
        public void Throw_ArgumentNullException_when_no_elements_are_passed()
        {
            var elements = new List<WardrobeElement>();

            Action action = () => _sut.IsWardrobeFittingWall(elements);

            var exception = action.Should().Throw<ArgumentNullException>().Which;
            exception.ParamName.Should().Contain(nameof(WardrobeElement));
        }

        [Theory]
        [InlineData(new int[] { 0 })]
        [InlineData(new int[] { 0, 1, 30 })]
        [InlineData(new int[] { 10, -20 })]
        [InlineData(new int[] { 50, -75, 0 })]
        public void Throw_ArgumentException_when_any_element_has_invalid_size(int[] sizes)
        {
            var elements = WardrobeElement.ConvertFromSizes(sizes);

            Action action = () => _sut.IsWardrobeFittingWall(elements);

            action.Should().Throw<ArgumentException>().WithMessage("One or more wardrobe elements have invalid size defined");
        }

        [Theory]
        [InlineData(new int[] { 1 })]
        [InlineData(new int[] { 10, 20 })]
        [InlineData(new int[] { 50, 75, 100 })]
        public void Return_true_when_element_sizes_sum_up_less_than_250(int[] sizes)
        {
            var elements = WardrobeElement.ConvertFromSizes(sizes);

            var fitsWall = _sut.IsWardrobeFittingWall(elements);

            fitsWall.Should().BeTrue();
        }
    }
}
