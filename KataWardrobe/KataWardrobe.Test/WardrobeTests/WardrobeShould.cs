using FluentAssertions;
using KataWardrobe.Core.Domain;
using KataWardrobe.Core.Domain.Enums;
using KataWardrobe.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace KataWardrobe.Test.WardrobeTests
{
    public class WardrobeShould
    {
        private Wardrobe _wardrobe;

        public WardrobeShould()
        {
            _wardrobe = WardrobeFactory.BuildWardrobe(new[] { WardrobeElementSize.S, WardrobeElementSize.M, WardrobeElementSize.L });
        }

        [Fact]
        public void Have_a_list_of_elements_that_compose_the_wardrobe()
        {
            _wardrobe.Elements.Should().NotBeNull();
            _wardrobe.Elements.Should().NotBeEmpty();
            _wardrobe.Elements.GetType().Should().Be(typeof(List<WardrobeElement>));
        }

        [Fact]
        public void Have_at_least_one_element()
        {
            var elements = new List<WardrobeElement>();
            Action action = () => _wardrobe = new Wardrobe(elements);

            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Not_have_elements_without_size()
        {
            var elements = new List<WardrobeElement> { new ModuleS(), new ModuleM(), new ModuleL(), new ModuleXL() };
            Action action = () => _wardrobe = new Wardrobe(elements);

            action.Should().NotThrow<Exception>();
            _wardrobe.Elements.ForEach(e => e.Size.Should().NotBe(0));
        }

        [Fact]
        public void Not_have_elements_without_price()
        {
            var elements = new List<WardrobeElement> { new ModuleS(), new ModuleM(), new ModuleL(), new ModuleXL() };
            Action action = () => _wardrobe = new Wardrobe(elements);

            action.Should().NotThrow<Exception>();
            _wardrobe.Elements.ForEach(e => e.Price.Should().NotBe(0));
        }

        [Fact]
        public void Have_the_total_cost_of_the_elements()
        {
            _wardrobe.Price.Should().Be(_wardrobe.Elements.Sum(e => e.Price));
        }

        [Fact]
        public void Not_have_zero_cost()
        {
            _wardrobe.Price.Should().NotBe(0);
        }

        [Fact]
        public void Have_the_total_size_of_the_elements()
        {
            _wardrobe.Size.Should().Be(_wardrobe.Elements.Sum(e => e.Size));
        }

        [Fact]
        public void Not_have_zero_size()
        {
            _wardrobe.Size.Should().NotBe(0);
        }
    }
}
