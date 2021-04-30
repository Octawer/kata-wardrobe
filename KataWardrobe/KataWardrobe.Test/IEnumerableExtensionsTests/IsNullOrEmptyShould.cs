using FluentAssertions;
using KataWardrobe.Helpers;
using Xunit;

namespace KataWardrobe.Test.IEnumerableExtensionsTests
{
    public class IsNullOrEmptyShould
    {
        [Fact]
        public void Return_true_when_collection_null()
        {
            int[] source = null;

            source.IsNullOrEmpty().Should().BeTrue();
        }

        [Fact]
        public void Return_true_when_collection_empty()
        {
            var source = new int[] { };

            source.IsNullOrEmpty().Should().BeTrue();
        }

        [Fact]
        public void Return_false_when_collection_has_any_element()
        {
            var source = new int[] { 1 };

            source.IsNullOrEmpty().Should().BeFalse();
        }
    }
}
