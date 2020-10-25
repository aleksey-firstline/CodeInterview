using Xunit;

namespace CodeInterview.SlidingWindow
{
    public class SmallestSubarrayWithGivenSum
    {
        [Theory]
        [InlineData(new []{ 2, 3, 8 }, 7, 1)]
        [InlineData(new []{ 2, 3, 1 }, 7, 0)]
        [InlineData(new []{ 2, 1, 5, 2, 3, 2 }, 7, 2)]
        [InlineData(new []{ 2, 3, 6, 4 }, 1, 1)]
        public void CalculateAverages(int[] arr, int S, int expected)
        {
            var minSize = 0;
            var sum = 0;
            var j = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];

                while (sum >= S)
                {
                    var size = i + 1 - j;
                    if (minSize > size || minSize == 0)
                        minSize = size;

                    sum -= arr[j];
                    j++;
                }
            }

            Assert.Equal(expected, minSize);
        }
    }
}
