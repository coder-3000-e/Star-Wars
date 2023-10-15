using System;
using Server.Helpers;

namespace Test.Helpers
{
    public class CompareAttributesTests
    {
        [Fact]
        public void CompareCountAttributes_MoreAttributes_Success()
        {
            var comparer = new CompareAttributes();
            var char1 = "Character1";
            var char2 = "Character2";
            var val1 = new List<string> { "Attribute1", "Attribute2" };
            var val2 = new List<string> { "Attribute1" };
            var attributeName = "attributes";

            var result = comparer.CompareCountAttributes(char1, char2, val1, val2, attributeName);

            Assert.Equal($"{char1} have been in more {attributeName} than {char2}.", result);
        }

        [Fact]
        public void CompareDoubleAttributes_BiggerValue_Success()
        {
            var comparer = new CompareAttributes();
            var char1 = "Character1";
            var char2 = "Character2";
            var height1 = "180.0";
            var height2 = "170.0";
            var attributeName = "height";

            var result = comparer.CompareDoubleAttributes(char1, char2, height1, height2, attributeName);

            Assert.Equal($"{char1} has a bigger {attributeName} than {char2}.", result);
        }

        [Fact]
        public void CompareStringAttributes_DifferentValues_Success()
        {
            var comparer = new CompareAttributes();
            var char1 = "Character1";
            var char2 = "Character2";
            var attribute1 = "Value1";
            var attribute2 = "Value2";

            var result = comparer.CompareStringAttributes(char1, char2, attribute1, attribute2);

            Assert.Equal("Characters have different values for this attribute.", result);
        }
    }
}
