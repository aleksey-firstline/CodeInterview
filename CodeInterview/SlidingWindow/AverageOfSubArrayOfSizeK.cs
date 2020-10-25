using Xunit;

namespace CodeInterview.SlidingWindow
{
    public class AverageOfSubArrayOfSizeK
    {
        [Theory]
        [InlineData(new []{ 1, 3, 2, 6, -1, 4, 1, 8, 2 }, 5, new []{ 2.2, 2.8, 2.4, 3.6, 2.8 })]
        [InlineData(new []{ 1, 3, 2 }, 3, new []{ 2.0 })]
        public void CalculateAverages(int[] array, int k, double[] expected)
        {
            var result = new double[array.Length - k + 1];

            double sum = 0;
            var startFrame = 0;
            //O(N)
            for (int endFrame = 0; endFrame < array.Length; endFrame++)
            {
                sum += array[endFrame];

                if (endFrame >= k - 1)
                {
                    result[startFrame] = sum / k;
                    sum -= array[startFrame];
                    startFrame++;
                }
            }

            Assert.Equal(expected, result);
        }
    }
}
