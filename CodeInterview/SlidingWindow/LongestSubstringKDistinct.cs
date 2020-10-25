using System;
using System.Collections.Generic;
using Xunit;

namespace CodeInterview.SlidingWindow
{
    public class LongestSubstringKDistinct
    {
        [Theory]
        [InlineData("aaabcd", 2, 4)]
        [InlineData("aaabcd", 1, 3)]
        [InlineData("fbcdrrrgg", 2, 5)]
        [InlineData("abcd", 2, 2)]
        public void FindLength(string str, int K, int expected)
        {
            var uniqChars = new Dictionary<char, int>();
            var j = 0;
            var maxLength = 0;

            for (var i = 0; i < str.Length; i++)
            {
                var rightChar = str[i];
                if (uniqChars.TryGetValue(rightChar, out var rightCharCount))
                    uniqChars[rightChar] = rightCharCount + 1;
                else
                    uniqChars.Add(rightChar, 1);

                while (uniqChars.Count > K)
                {
                    var leftChar = str[j];
                    if (uniqChars.TryGetValue(leftChar, out var leftCharCount))
                        uniqChars[leftChar] = leftCharCount - 1;

                    if (uniqChars[leftChar] == 0)
                        uniqChars.Remove(leftChar);

                    j++;
                }

                maxLength = Math.Max(maxLength, i - j + 1);
            }

            Assert.Equal(maxLength, expected);
        }
    }
}
