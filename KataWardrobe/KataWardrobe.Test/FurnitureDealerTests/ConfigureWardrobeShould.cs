using FluentAssertions;
using KataWardrobe.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace KataWardrobe.Test.FurnitureDealerTests
{
    public class ConfigureWardrobeShould
    {
        private readonly FurnitureDealer _sut;

        public ConfigureWardrobeShould()
        {
            _sut = new FurnitureDealer();
        }

        [Fact]
        public void Receive_non_empty_elements_collection()
        {
            var elements = new List<WardrobeElement>();

            Action action = () => _sut.ConfigureWardrobe(elements);

            action.Should().Throw<ArgumentNullException>();
        }

        [Theory]
        [InlineData(new int[] { 0 })]
        [InlineData(new int[] { 0, 1 })]
        [InlineData(new int[] { 10, -5, 150 })]
        [InlineData(new int[] { -2, 0, 100, 500 })]
        public void Receive_valid_elements_collection(int[] sizes)
        {
            Action action = () => WardrobeElement.ConvertFromSizes(sizes);

            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Return_elements_combinations()
        {
            var elements = new List<WardrobeElement> { new WardrobeElement(size:10) };

            var result = _sut.ConfigureWardrobe(elements);

            result.GetType().Should().Be(typeof(List<List<WardrobeElement>>));
        }

        [Theory]
        [InlineData(new int[] { 251 })]
        [InlineData(new int[] { 300, 450 })]
        [InlineData(new int[] { 1000, 255, 5000 })]
        public void Return_empty_matches_when_unfitting_elements(int[] sizes)
        {
            var elements = WardrobeElement.ConvertFromSizes(sizes);

            List<List<WardrobeElement>> result = _sut.ConfigureWardrobe(elements);

            result.Should().BeEmpty();
        }

        [Theory]
        [InlineData(new int[] { 100 })]
        [InlineData(new int[] { 250, 450 })]
        [InlineData(new int[] { 10, 500, 5000 })]
        public void Return_one_match_when_only_one_element_fits(int[] sizes)
        {
            var elements = WardrobeElement.ConvertFromSizes(sizes);

            var result = _sut.ConfigureWardrobe(elements);

            result.SelectMany(r => r).Count().Should().Be(1);
        }

        [Fact]
        public void Return_valid_combinations_when_more_than_one_fits() 
        {
            var sizes = new int[] { 100, 150 };
            var elements = WardrobeElement.ConvertFromSizes(sizes);
        }

    }
}
