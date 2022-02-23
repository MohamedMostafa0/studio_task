namespace GoodGame_Studios_Task.Interfaces
{
    public interface IRandomManager
    {
        int[] GetRandomInRangeEqualSum(int min, int max, int sum, int count);
        int[] GetRandomMax(int min ,int max);
    }
}
