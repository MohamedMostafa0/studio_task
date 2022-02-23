using GoodGame_Studios_Task.Helpers;

namespace GoodGame_Studios_Task.Models
{
    public abstract class BaseTroop
    {
        public TroopType TroopType { get; private set; }

        public BaseTroop(TroopType troopType)
        {
            TroopType = troopType;
        }
    }
}
