using FluentAssertions;
using KataWardrobe.Core.Domain;
using KataWardrobe.Core.Domain.Enums;
using KataWardrobe.Core.Domain.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace KataWardrobe.Test.FurnitureDealerTests
{
    public class OptimizeWardrobeShould
    {
        private readonly FurnitureDealer _sut;

        public OptimizeWardrobeShould()
        {
            _sut = new FurnitureDealer();
        }

        [Fact]
        public void Receive_non_null_elements_collection()
        {
            List<WardrobeElement> elements = null;

            Action action = () => _sut.OptimizeWardrobe(elements);

            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Receive_non_empty_elements_collection()
        {
            var elements = new List<WardrobeElement>();

            Action action = () => _sut.OptimizeWardrobe(elements);

            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Receive_elements_collection_with_at_least_one_fit()
        {
            var elements = new List<WardrobeElement>();

            Action action = () => _sut.OptimizeWardrobe(elements);

            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Return_the_cheapest_combination_of_elements_that_occupy_the_most_of_wall()
        {
            var sizes = new WardrobeElementSize[] { WardrobeElementSize.S, WardrobeElementSize.M, WardrobeElementSize.L, WardrobeElementSize.XL };
            var elements = WardrobeFactory.BuildElements(sizes);

            Wardrobe wardrobe = _sut.OptimizeWardrobe(elements);

            var expectedWardrobe = WardrobeFactory.BuildWardrobe(new WardrobeElementSize[] { WardrobeElementSize.S, WardrobeElementSize.M, WardrobeElementSize.XL });
            wardrobe.Should().BeEquivalentTo(expectedWardrobe);
        }
    }
}
