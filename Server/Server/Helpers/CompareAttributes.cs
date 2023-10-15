namespace Server.Helpers
{
    public class CompareAttributes
    {
        public string CompareCountAttributes(string char1, string char2, List<string> val1, List<string> val2, string attributeName)
        {
            var count1 = val1.Count();
            var count2 = val2.Count();

            if (count1 > count2)
            {
                return $"{char1} have been in more {attributeName} than {char2}.";
            }
            else if (count1 < count2)
            {
                return $"{char2} have been in more {attributeName} than {char1}.";
            }
            else
            {
                return $"Characters have the same amount of {attributeName}.";
            }
        }

        public string CompareDoubleAttributes(string char1, string char2, string height1, string height2, string attributeName)
        {
            var height1Value = double.Parse(height1, System.Globalization.CultureInfo.InvariantCulture);
            var height2Value = double.Parse(height2, System.Globalization.CultureInfo.InvariantCulture);

            if (height1Value > height2Value)
            {
                return $"{char1} has a bigger {attributeName} than {char2}.";
            }
            else if (height1Value < height2Value)
            {
                return $"{char2} has a bigger {attributeName} than {char1}.";
            }
            else
            {
                return $"Characters have the same {attributeName}.";
            }
        }
        public string CompareStringAttributes(string char1, string char2, string attribute1, string attribute2)
        {
            if (string.IsNullOrWhiteSpace(attribute1) && string.IsNullOrWhiteSpace(attribute2))
            {
                return "Both characters have no data for this attribute.";
            }
            else if (string.IsNullOrWhiteSpace(attribute1))
            {
                return $"{char2} has a value for this attribute.";
            }
            else if (string.IsNullOrWhiteSpace(attribute2))
            {
                return $"{char1} has a value for this attribute.";
            }
            else if (attribute1 == attribute2)
            {
                return "Both characters have the same value for this attribute.";
            }
            else
            {
                return "Characters have different values for this attribute.";
            }
        }
    }
}

