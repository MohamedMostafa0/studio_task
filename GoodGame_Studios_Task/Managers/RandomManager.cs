using System;
using System.Linq;
using GoodGame_Studios_Task.Interfaces;

namespace GoodGame_Studios_Task.Managers
{
    public class RandomManager : IRandomManager
    {
        private static Random _Random = new Random();
        public int[] GetRandomInRangeEqualSum(int min, int max, int sum, int count)
        {
            int[] result = new int[count];
            for (int i = 0; i < count - 1; i++)
            {
                var rest = count - (i + 1);

                var restMinimum = min * rest;
                var restMaximum = max * rest;

                min = Math.Abs(Math.Max(min, sum - restMaximum));
                max = Math.Abs(Math.Min(max, sum - restMinimum));

                if(min > max)
                {
                    int temp = min;
                    min = max;
                    max = temp;
                }

                int random = _Random.Next(min, max);
                result[i] = random;
                sum -= random;
            }
            result[count - 1] = sum;
            return result;
        }
        public int[] GetRandomMax(int min, int max)
        {
            var nums = Enumerable.Range(min, max).ToArray();
            for (int i = 0; i < nums.Length; ++i)
            {
                int randomIndex = _Random.Next(nums.Length);
                int temp = nums[randomIndex];
                nums[randomIndex] = nums[i];
                nums[i] = temp;
            }
            return nums;
        }
    }
}
