using System.Collections.Generic;
using GoodGame_Studios_Task.Helpers;
using GoodGame_Studios_Task.Interfaces;

namespace GoodGame_Studios_Task.Managers
{
    public class FactoryManager : IFactoryManager
    {
        private readonly IRandomManager RandomManager;

        private int[] memoization;
        private int index = -1;

        public FactoryManager(IRandomManager randomManager)
        {
            RandomManager = randomManager;
        }
        public Dictionary<TroopType, int> GetTroops(List<TroopType> troopsToChoose, int minimum, int maximum, int sum)
        {
            index++;
            if (memoization == null)
            {
                memoization = RandomManager.GetRandomMax(0, sum * 20 / 100);
            }
            if (index >= memoization.Length)
                index = 0;

            Dictionary<TroopType, int> troops = new Dictionary<TroopType, int>();
            foreach (var item in troopsToChoose)
            {
                troops.Add(item, 0);
            }
            int[] requestRandomInRange = RandomManager.GetRandomInRangeEqualSum(minimum, maximum, sum, troopsToChoose.Count);
            int lastSum = memoization[index];
            for (int i = 0; i < requestRandomInRange.Length; i++)
            {
                requestRandomInRange[i] -= lastSum;
            }
            int[] requestRandomItems = RandomManager.GetRandomInRangeEqualSum(0, lastSum * troopsToChoose.Count, lastSum * troopsToChoose.Count, troopsToChoose.Count);
            for (int i = 0; i < requestRandomInRange.Length; i++)
            {
                troops[troopsToChoose[i]] = requestRandomInRange[i];
            }
            for (int i = 0; i < requestRandomItems.Length; i++)
            {
                troops[troopsToChoose[i]] += requestRandomItems[i];
            }
            return troops;
        }
    }
}
