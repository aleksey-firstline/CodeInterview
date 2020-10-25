using System;
using System.Collections.Generic;
using Xunit;

namespace CodeInterview.SlidingWindow
{
    public class LengthOfLongestNoRepeatSubstring
    {
        [Theory]
        [InlineData("aaabcd", 4)]
        [InlineData("aarrbb", 2)]
        [InlineData("abcde", 5)]
        public void FindLength(string str, int expected)
        {
            var chars = new Dictionary<char, int>();
            var winStart = 0;
            var maxSize = 0;

            for (var winEnd = 0; winEnd < str.Length; winEnd++)
            {
                var rightChar = str[winEnd];
                if (chars.ContainsKey(rightChar))
                {
                    winStart = Math.Max(winStart, chars[rightChar] + 1);
                }

                if (!chars.TryAdd(rightChar, winEnd))
                {
                    chars[rightChar] = winEnd;
                }

                maxSize = Math.Max(maxSize, winEnd - winStart + 1);
            }

            Assert.Equal(maxSize, expected);
        }
    }
}
