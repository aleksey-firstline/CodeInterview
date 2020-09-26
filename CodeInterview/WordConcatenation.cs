using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodeInterview
{
    public class WordConcatenation
    {
        [Theory]
        [InlineData("catfoxcat", new string[] { "cat", "fox" }, new int[] { 0, 3 })]
        public void FindWordConcatenation(string str, string[] words, int[] expected)
        {
            var result = new List<int>();
            var uniqWords = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (uniqWords.ContainsKey(word))
                    uniqWords[word]++;
                else
                    uniqWords.Add(word, 1);
            }

            int wordCount = words.Length;
            int wordSize = words[0].Length;

            for (int i = 0; i <= str.Length - wordCount * wordSize; i++)
            {
                var seenWords = new Dictionary<string, int>();
                for (int j = 0; j < wordCount; j++)
                {
                    var index = i + j * wordSize;
                    var word = str.Substring(index, wordSize);

                    if (!uniqWords.ContainsKey(word))
                        break;

                    if (seenWords.ContainsKey(word))
                        seenWords[word]++;
                    else
                        seenWords.Add(word, 1);

                    if (uniqWords[word] < seenWords[word])
                        break;

                    if (j + 1 == wordCount)
                        result.Add(i);
                }
            }

            Assert.Equal(expected, result);
        }
    }
}
