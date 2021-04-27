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
            Action action = () => WardrobeElement.ConvertFromSizes(sizes);

            action.Should().Throw<ArgumentException>();
        }

        [Theory]
        [InlineData(new int[] { 250 })]
        [InlineData(new int[] { 1, 1500 })]
        [InlineData(new int[] { 10, 520, 1000 })]
        [InlineData(new int[] { 50, 275, 500 })]
        public void Return_true_when_at_least_one_element_fits_wall(int[] sizes)
        {
            var elements = WardrobeElement.ConvertFromSizes(sizes);

            var fitsWall = _sut.IsWardrobeFittingWall(elements);

            fitsWall.Should().BeTrue();
        }

        [Theory]
        [InlineData(new int[] { 251 })]
        [InlineData(new int[] { 1000, 5200 })]
        [InlineData(new int[] { 555, 777, 654645 })]
        public void Return_false_when_all_elements_exceed_the_wall_size(int[] sizes) 
        {
            var elements = WardrobeElement.ConvertFromSizes(sizes);

            var fitsWall = _sut.IsWardrobeFittingWall(elements);

            fitsWall.Should().BeFalse();
            
        }
    }
}
