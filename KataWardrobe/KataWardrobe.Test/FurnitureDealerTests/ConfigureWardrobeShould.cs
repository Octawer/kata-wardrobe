using FluentAssertions;
using KataWardrobe.Core.Domain;
using KataWardrobe.Core.Domain.Enums;
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
        [InlineData(new WardrobeElementSize[] { WardrobeElementSize.S })]
        [InlineData(new WardrobeElementSize[] { WardrobeElementSize.M })]
        [InlineData(new WardrobeElementSize[] { WardrobeElementSize.L })]
        [InlineData(new WardrobeElementSize[] { WardrobeElementSize.XL })]
        public void Return_one_match_when_only_one_element_fits(WardrobeElementSize[] sizes)
        {
            var elements = WardrobeFactory.Build(sizes);

            var result = _sut.ConfigureWardrobe(elements);

            result.SelectMany(r => r).Count().Should().Be(1);
        }

        [Fact]
        public void Return_valid_combinations_that_fits_the_wall() 
        {
            var sizes = new WardrobeElementSize[] { WardrobeElementSize.S, WardrobeElementSize.M, WardrobeElementSize.L, WardrobeElementSize.XL };
            var elements = WardrobeFactory.Build(sizes);

            var result = _sut.ConfigureWardrobe(elements);

            var expectedCombinations = new List<List<WardrobeElement>>();
            expectedCombinations.Add(WardrobeFactory.Build(new WardrobeElementSize[] { WardrobeElementSize.S }));
            expectedCombinations.Add(WardrobeFactory.Build(new WardrobeElementSize[] { WardrobeElementSize.M }));
            expectedCombinations.Add(WardrobeFactory.Build(new WardrobeElementSize[] { WardrobeElementSize.L }));
            expectedCombinations.Add(WardrobeFactory.Build(new WardrobeElementSize[] { WardrobeElementSize.XL }));
            expectedCombinations.Add(WardrobeFactory.Build(new WardrobeElementSize[] { WardrobeElementSize.S, WardrobeElementSize.M }));
            expectedCombinations.Add(WardrobeFactory.Build(new WardrobeElementSize[] { WardrobeElementSize.S, WardrobeElementSize.L }));
            expectedCombinations.Add(WardrobeFactory.Build(new WardrobeElementSize[] { WardrobeElementSize.S, WardrobeElementSize.XL }));
            expectedCombinations.Add(WardrobeFactory.Build(new WardrobeElementSize[] { WardrobeElementSize.M, WardrobeElementSize.L }));
            expectedCombinations.Add(WardrobeFactory.Build(new WardrobeElementSize[] { WardrobeElementSize.M, WardrobeElementSize.XL }));
            expectedCombinations.Add(WardrobeFactory.Build(new WardrobeElementSize[] { WardrobeElementSize.L, WardrobeElementSize.XL }));
            expectedCombinations.Add(WardrobeFactory.Build(new WardrobeElementSize[] { WardrobeElementSize.S, WardrobeElementSize.M, WardrobeElementSize.L }));
            expectedCombinations.Add(WardrobeFactory.Build(new WardrobeElementSize[] { WardrobeElementSize.S, WardrobeElementSize.M, WardrobeElementSize.XL }));

            result.Should().BeEquivalentTo(expectedCombinations);
        }

    }
}
