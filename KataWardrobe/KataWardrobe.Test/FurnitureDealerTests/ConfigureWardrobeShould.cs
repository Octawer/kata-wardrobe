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
        [InlineData(new uint[] { 0 })]
        [InlineData(new uint[] { 0, 1 })]
        [InlineData(new uint[] { 10, 0, 150 })]
        [InlineData(new uint[] { 0, 0, 100, 500 })]
        public void Receive_valid_elements_collection(uint[] sizes)
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
        [InlineData(new uint[] { 251 })]
        [InlineData(new uint[] { 300, 450 })]
        [InlineData(new uint[] { 1000, 255, 5000 })]
        public void Return_empty_matches_when_unfitting_elements(uint[] sizes)
        {
            var elements = WardrobeElement.ConvertFromSizes(sizes);

            List<List<WardrobeElement>> result = _sut.ConfigureWardrobe(elements);

            result.Should().BeEmpty();
        }

        [Theory]
        [InlineData(new uint[] { 100 })]
        [InlineData(new uint[] { 250, 450 })]
        [InlineData(new uint[] { 10, 500, 5000 })]
        public void Return_one_match_when_only_one_element_fits(uint[] sizes)
        {
            var elements = WardrobeElement.ConvertFromSizes(sizes);

            var result = _sut.ConfigureWardrobe(elements);

            result.SelectMany(r => r).Count().Should().Be(1);
        }

        [Fact]
        public void Return_valid_combinations_when_more_than_one_fits() 
        {
            var sizes = new uint[] { 100, 150 };
            var elements = WardrobeElement.ConvertFromSizes(sizes);
        }

    }
}
