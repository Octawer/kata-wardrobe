using FluentAssertions;
using KataWardrobe.Core.Domain;
using KataWardrobe.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace KataWardrobe.Test.FurnitureDealerTests
{
    public class ConfigureWardrobeShould
    {
        private readonly FurnitureDealer _sut;
        private readonly WardrobeElementFactory _factory;

        public ConfigureWardrobeShould()
        {
            _sut = new FurnitureDealer();
            _factory = new WardrobeElementFactory();
        }

        [Fact]
        public void Receive_non_null_elements_collection()
        {
            List<WardrobeElement> elements = null;

            Action action = () => _sut.ConfigureWardrobe(elements);

            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Receive_non_empty_elements_collection()
        {
            var elements = new List<WardrobeElement>();

            Action action = () => _sut.ConfigureWardrobe(elements);

            action.Should().Throw<ArgumentNullException>();
        }

        [Theory]
        [InlineData(new int[] { 50 })]
        [InlineData(new int[] { 75 })]
        [InlineData(new int[] { 100 })]
        [InlineData(new int[] { 120 })]
        public void Return_one_match_when_only_one_element_fits(int[] sizes)
        {
            var elements = _factory.ConvertFromSizes(sizes);

            var result = _sut.ConfigureWardrobe(elements);

            result.SelectMany(r => r).Count().Should().Be(1);
        }

        [Fact]
        public void Return_valid_combinations_that_fits_the_wall() 
        {
            var sizes = new int[] { 50, 75, 100, 120 };
            var elements = _factory.ConvertFromSizes(sizes);

            var result = _sut.ConfigureWardrobe(elements);

            var expectedCombinations = new List<List<WardrobeElement>>();
            expectedCombinations.Add(_factory.ConvertFromSizes(new int[] { 50 }));
            expectedCombinations.Add(_factory.ConvertFromSizes(new int[] { 75 }));
            expectedCombinations.Add(_factory.ConvertFromSizes(new int[] { 100 }));
            expectedCombinations.Add(_factory.ConvertFromSizes(new int[] { 120 }));
            expectedCombinations.Add(_factory.ConvertFromSizes(new int[] { 50, 75 }));
            expectedCombinations.Add(_factory.ConvertFromSizes(new int[] { 50, 100 }));
            expectedCombinations.Add(_factory.ConvertFromSizes(new int[] { 50, 120 }));
            expectedCombinations.Add(_factory.ConvertFromSizes(new int[] { 75, 100 }));
            expectedCombinations.Add(_factory.ConvertFromSizes(new int[] { 75, 120 }));
            expectedCombinations.Add(_factory.ConvertFromSizes(new int[] { 100, 120 }));
            expectedCombinations.Add(_factory.ConvertFromSizes(new int[] { 50, 75, 100 }));
            expectedCombinations.Add(_factory.ConvertFromSizes(new int[] { 50, 75, 120 }));

            result.Should().BeEquivalentTo(expectedCombinations);
        }

    }
}
