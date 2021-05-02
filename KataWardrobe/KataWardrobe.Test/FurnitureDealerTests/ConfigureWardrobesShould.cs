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
    public class ConfigureWardrobesShould
    {
        private readonly FurnitureDealer _sut;

        public ConfigureWardrobesShould()
        {
            _sut = new FurnitureDealer();
        }

        [Fact]
        public void Receive_non_null_elements_collection()
        {
            List<WardrobeElement> elements = null;

            Action action = () => _sut.ConfigureWardrobes(elements);

            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Receive_non_empty_elements_collection()
        {
            var elements = new List<WardrobeElement>();

            Action action = () => _sut.ConfigureWardrobes(elements);

            action.Should().Throw<ArgumentNullException>();
        }

        [Theory]
        [InlineData(new WardrobeElementSize[] { WardrobeElementSize.S })]
        [InlineData(new WardrobeElementSize[] { WardrobeElementSize.M })]
        [InlineData(new WardrobeElementSize[] { WardrobeElementSize.L })]
        [InlineData(new WardrobeElementSize[] { WardrobeElementSize.XL })]
        public void Return_one_match_when_only_one_element_fits(WardrobeElementSize[] sizes)
        {
            var elements = WardrobeFactory.BuildElements(sizes);

            List<Wardrobe> wardrobes = _sut.ConfigureWardrobes(elements);

            wardrobes.Count.Should().Be(1);
            wardrobes.First().Elements.Count.Should().Be(1);
        }

        [Fact]
        public void Return_valid_combinations_that_fits_the_wall() 
        {
            var sizes = new WardrobeElementSize[] { WardrobeElementSize.S, WardrobeElementSize.M, WardrobeElementSize.L, WardrobeElementSize.XL };
            var elements = WardrobeFactory.BuildElements(sizes);

            List<Wardrobe> wardrobes = _sut.ConfigureWardrobes(elements);

            var expectedWardrobes = new List<Wardrobe>();
            expectedWardrobes.Add(WardrobeFactory.BuildWardrobe(new WardrobeElementSize[] { WardrobeElementSize.S }));
            expectedWardrobes.Add(WardrobeFactory.BuildWardrobe(new WardrobeElementSize[] { WardrobeElementSize.M }));
            expectedWardrobes.Add(WardrobeFactory.BuildWardrobe(new WardrobeElementSize[] { WardrobeElementSize.L }));
            expectedWardrobes.Add(WardrobeFactory.BuildWardrobe(new WardrobeElementSize[] { WardrobeElementSize.XL }));
            expectedWardrobes.Add(WardrobeFactory.BuildWardrobe(new WardrobeElementSize[] { WardrobeElementSize.S, WardrobeElementSize.M }));
            expectedWardrobes.Add(WardrobeFactory.BuildWardrobe(new WardrobeElementSize[] { WardrobeElementSize.S, WardrobeElementSize.L }));
            expectedWardrobes.Add(WardrobeFactory.BuildWardrobe(new WardrobeElementSize[] { WardrobeElementSize.S, WardrobeElementSize.XL }));
            expectedWardrobes.Add(WardrobeFactory.BuildWardrobe(new WardrobeElementSize[] { WardrobeElementSize.M, WardrobeElementSize.L }));
            expectedWardrobes.Add(WardrobeFactory.BuildWardrobe(new WardrobeElementSize[] { WardrobeElementSize.M, WardrobeElementSize.XL }));
            expectedWardrobes.Add(WardrobeFactory.BuildWardrobe(new WardrobeElementSize[] { WardrobeElementSize.L, WardrobeElementSize.XL }));
            expectedWardrobes.Add(WardrobeFactory.BuildWardrobe(new WardrobeElementSize[] { WardrobeElementSize.S, WardrobeElementSize.M, WardrobeElementSize.L }));
            expectedWardrobes.Add(WardrobeFactory.BuildWardrobe(new WardrobeElementSize[] { WardrobeElementSize.S, WardrobeElementSize.M, WardrobeElementSize.XL }));

            wardrobes.Should().BeEquivalentTo(expectedWardrobes);
        }

    }
}
