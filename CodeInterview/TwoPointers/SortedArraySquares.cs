using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodeInterview.TwoPointers
{
    public class SortedArraySquares
    {
        [Theory]
        [InlineData(new[] { -2, -1, 0, 2, 3 }, new[] { 0, 1, 4, 4, 9 })]
        public void MakeSquares(int[] arr, int[] expected)
        {
            int[] squares = new int[arr.Length];

            int left = 0;
            int right = arr.Length - 1;

            int index = arr.Length - 1;
            while (left <= right)
            {
                int leftSum = arr[left] * arr[left];
                int rightSum = arr[right] * arr[right];

                if (leftSum > rightSum)
                {
                    squares[index--] = leftSum;
                    left++;
                }
                else
                {
                    squares[index--] = rightSum;
                    right--;
                }
            }

            Assert.Equal(squares, expected);
        }
    }
}
