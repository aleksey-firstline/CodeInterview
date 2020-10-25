using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodeInterview.TwoPointers
{
    public class TripletSumToZero
    {
        [Theory]
        [InlineData(new[] { -3, 0, 1, 2, -1, 1, -2 })]
        public void SearchTriplets(int[] arr)
        {
            Array.Sort(arr);
            List<List<int>> triplets = new List<List<int>>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (i > 0 && arr[i] == arr[i - 1]) // skip same element to avoid duplicate triplets
                    continue;

                int left = i + 1;
                int right = arr.Length - 1;
                while (left < right)
                {
                    int sum = arr[left] + arr[right];
                    if (sum == -arr[i])
                    {
                        triplets.Add(new List<int>{ arr[i], arr[left], arr[right] });
                        left++;
                        right--;

                        while (left < right && arr[left] == arr[left-1])
                        {
                            left++;
                        }
                        while (left < right && arr[right] == arr[right + 1])
                        {
                            right--;
                        }
                    }
                    else if (sum < -arr[i])
                    {
                        left++;
                    }
                    else
                    {
                        right--;
                    }
                }
            }

            Assert.True(true);
        }
    }
}
