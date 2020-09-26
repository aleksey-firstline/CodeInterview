using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodeInterview
{
    public class LongestSubarrayWithOnesAfterReplacement
    {
        [Theory]
        [InlineData(new[] {1, 1, 0, 1, 0}, 1, 4)]
        [InlineData(new[] { 0, 1, 1, 0, 0, 0, 1, 1, 0, 1, 1 }, 2, 6)]
        [InlineData(new[] { 0, 1, 0, 0, 1, 1, 0, 1, 1, 0, 0, 1, 1 }, 3, 9)]
        public void FindLength(int[] arr, int k, int expected)
        {
            int size = 0;
            int j = 0;
            int kk = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 1)
                    kk++;

                if (i - j + 1 - kk > k)
                {
                    if (arr[j] == 1)
                        kk -= arr[j];
                    j++;
                }

                size = Math.Max(size, i - j + 1);
            }

            Assert.Equal(expected, size);
        }
    }
}
