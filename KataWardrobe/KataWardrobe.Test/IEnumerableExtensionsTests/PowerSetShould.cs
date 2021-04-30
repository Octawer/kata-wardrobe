using FluentAssertions;
using KataWardrobe.Helpers;
using System.Collections.Generic;
using Xunit;

namespace KataWardrobe.Test.IEnumerableExtensionsTests
{
    public class PowerSetShould
    {
        [Fact]
        public void Return_all_posible_subsets_for_zero_items()
        {
            var source = new object[] { };

            var powerSet = source.PowerSet();

            var expectedPowerSet = new HashSet<List<object>>();
            expectedPowerSet.Add(new List<object> { });

            powerSet.Should().BeEquivalentTo(expectedPowerSet);
        }

        [Fact]
        public void Return_all_posible_subsets_for_one_object()
        {
            var source = new[] { (Id: 1, Name: "nameA") };

            var powerSet = source.PowerSet();

            var expectedPowerSet = new HashSet<List<(int Id, string Name)>>();
            expectedPowerSet.Add(new List<(int Id, string Name)> { });
            expectedPowerSet.Add(new List<(int Id, string Name)> { (Id: 1, Name: "nameA") });

            powerSet.Should().BeEquivalentTo(expectedPowerSet);
        }

        [Fact]
        public void Return_all_posible_subsets_for_three_ints()
        {
            var source = new[] { 50, 75, 100 };

            var powerSet = source.PowerSet();

            var expectedPowerSet = new HashSet<List<int>>();
            expectedPowerSet.Add(new List<int> { });
            expectedPowerSet.Add(new List<int> { 50 });
            expectedPowerSet.Add(new List<int> { 75 });
            expectedPowerSet.Add(new List<int> { 100 });
            expectedPowerSet.Add(new List<int> { 50, 100 });
            expectedPowerSet.Add(new List<int> { 75, 100 });
            expectedPowerSet.Add(new List<int> { 50, 75 });
            expectedPowerSet.Add(new List<int> { 50, 75, 100 });

            powerSet.Should().BeEquivalentTo(expectedPowerSet);
        }

        [Fact]
        public void Return_all_posible_subsets_for_three_strings()
        {
            var source = new[] { "aa", "bb", "cc" };

            var powerSet = source.PowerSet();

            var expectedPowerSet = new HashSet<List<string>>();
            expectedPowerSet.Add(new List<string> { });
            expectedPowerSet.Add(new List<string> { "aa" });
            expectedPowerSet.Add(new List<string> { "bb" });
            expectedPowerSet.Add(new List<string> { "cc" });
            expectedPowerSet.Add(new List<string> { "aa", "cc" });
            expectedPowerSet.Add(new List<string> { "bb", "cc" });
            expectedPowerSet.Add(new List<string> { "aa", "bb" });
            expectedPowerSet.Add(new List<string> { "aa", "bb", "cc" });

            powerSet.Should().BeEquivalentTo(expectedPowerSet);
        }
    }
}
