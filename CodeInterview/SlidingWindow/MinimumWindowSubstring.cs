using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodeInterview.SlidingWindow
{
    public class MinimumWindowSubstring
    {
        [Theory]
        [InlineData("aabdec", "abc", "abdec")]
        public static void FindSubstring(string str, string pattern, string expected)
        {
            var uniqChars = new Dictionary<char, int>();
            foreach (var item in pattern)
            {
                if (uniqChars.ContainsKey(item))
                    uniqChars[item] += 1;
                else
                    uniqChars.Add(item, 1);
            }

            var matched = 0;
            var j = 0;
            var minLen = str.Length + 1;
            var start = 0;
            for (int i = 0; i < str.Length; i++)
            {
                var rightChar = str[i];
                if (uniqChars.ContainsKey(rightChar))
                {
                    uniqChars[rightChar] -= 1;

                    if (uniqChars[rightChar] >= 0)
                        matched++;
                }

                while (matched == pattern.Length)
                {
                    if (minLen > i - j + 1)
                    {
                        minLen = i - j + 1;
                        start = j;
                    }

                    var leftChar = str[j];
                    if (uniqChars.ContainsKey(leftChar))
                    {
                        if (uniqChars[leftChar] == 0)
                            matched--;

                        uniqChars[leftChar] += 1;
                    }

                    j++;
                }
            }

            var result = str.Substring(start, minLen);
        }
    }
}
