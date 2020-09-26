using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CodeInterview
{
    public class LongestSubstringKReplacement
    {
        [Theory]
        [InlineData("aabccbb", 2, 5)]
        [InlineData("abbcb", 1, 4)]
        [InlineData("abccde", 1, 3)]
        public void FindLength(string str, int K, int expected)
        {
            var uniqChars = new Dictionary<char, int>();
            var j = 0;
            var maxRepLength = 0;
            var maxLength = 0;
            for (var i = 0; i < str.Length; i++)
            {
                var rightChar = str[i];
                if (uniqChars.TryGetValue(rightChar, out var rightCharCount))
                    uniqChars[rightChar] = rightCharCount + 1;
                else
                    uniqChars.Add(rightChar, 1);

                maxRepLength = Math.Max(maxRepLength, uniqChars[rightChar]);

                if (i - j + 1 - maxRepLength > K)
                {
                    var leftChar = str[j];
                    uniqChars[leftChar] = -1;

                    j++;
                }

                maxLength = Math.Max(maxLength, i - j + 1);
            }

            Assert.Equal(maxLength, expected);
        }
    }
}
