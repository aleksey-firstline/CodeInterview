using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodeInterview.SlidingWindow
{
    public class StringPermutation
    {
        [Theory]
        [InlineData("aaacb", "abc", true)] 
        [InlineData("odicf", "dc", false)]
        public void FindPermutation(string str, string pattern, bool expacted)
        {
            var result = false;
            int j = 0;
            var map = new Dictionary<char, int>();
            for (int i = 0; i < pattern.Length; i++)
            {
                var c = pattern[i];
                if (map.TryGetValue(c, out var rightCharCount))
                    map[c] = rightCharCount + 1;
                else
                    map.Add(c, 1);
            }

            for (int i = 0; i < str.Length; i++)
            {
                var c = str[i];
                if (i - j > pattern.Length || !map.ContainsKey(c))
                {
                    var r = str[j];
                    if (str.Contains(r))
                    {
                        if (map.TryGetValue(r, out var rightCharCount))
                            map[r] = rightCharCount + 1;
                        else
                            map.Add(r, 1);
                    }
                    j++;
                }

                if (map.ContainsKey(c))
                {
                    map[c] -= 1;
                    if (map[c] == 0)
                    {
                        map.Remove(c);
                    }
                }

                if (map.Count == 0)
                {
                    result = true;
                }
            }

            Assert.Equal(expacted, result);
        }
    }
}
