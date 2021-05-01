﻿using FluentAssertions;
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
        [InlineData(new uint[] { 251 })]
        [InlineData(new uint[] { 300, 450 })]
        [InlineData(new uint[] { 1000, 255, 5000 })]
        public void Return_empty_matches_when_unfitting_elements(uint[] sizes)
        {
            var elements = WardrobeElement.ConvertFromSizes(sizes);

            var result = _sut.ConfigureWardrobe(elements);

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
        public void Return_valid_combinations_that_fits_the_wall() 
        {
            var sizes = new uint[] { 50, 75, 100, 120 };
            var elements = WardrobeElement.ConvertFromSizes(sizes);

            var result = _sut.ConfigureWardrobe(elements);

            var expectedCombinations = new List<List<WardrobeElement>>();
            expectedCombinations.Add(WardrobeElement.ConvertFromSizes(new uint[] { 50 }));
            expectedCombinations.Add(WardrobeElement.ConvertFromSizes(new uint[] { 75 }));
            expectedCombinations.Add(WardrobeElement.ConvertFromSizes(new uint[] { 100 }));
            expectedCombinations.Add(WardrobeElement.ConvertFromSizes(new uint[] { 120 }));
            expectedCombinations.Add(WardrobeElement.ConvertFromSizes(new uint[] { 50, 75 }));
            expectedCombinations.Add(WardrobeElement.ConvertFromSizes(new uint[] { 50, 100 }));
            expectedCombinations.Add(WardrobeElement.ConvertFromSizes(new uint[] { 50, 120 }));
            expectedCombinations.Add(WardrobeElement.ConvertFromSizes(new uint[] { 75, 100 }));
            expectedCombinations.Add(WardrobeElement.ConvertFromSizes(new uint[] { 75, 120 }));
            expectedCombinations.Add(WardrobeElement.ConvertFromSizes(new uint[] { 100, 120 }));
            expectedCombinations.Add(WardrobeElement.ConvertFromSizes(new uint[] { 50, 75, 100 }));
            expectedCombinations.Add(WardrobeElement.ConvertFromSizes(new uint[] { 50, 75, 120 }));

            result.Should().BeEquivalentTo(expectedCombinations);
        }

    }
}
