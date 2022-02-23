using System.Collections.Generic;
using GoodGame_Studios_Task.Helpers;

namespace GoodGame_Studios_Task.Interfaces
{
    public interface IFactoryManager
    {
        Dictionary<TroopType, int> GetTroops(List<TroopType> troopsToChoose, int minimum, int maximum, int sum);
    }
}
