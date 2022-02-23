using System;
using System.Linq;
using System.Collections.Generic;
using GoodGame_Studios_Task.Helpers;
using GoodGame_Studios_Task.Managers;
using GoodGame_Studios_Task.Interfaces;

namespace GoodGame_Studios_Task
{
    class Program
    {
        private const string REQUEST_COUNT = "Enter troops count";
        private const string REQUEST_TOTAL = "Enter Total";
        private const string REQUEST_TROOP = "Choose Type";
        private const string REQUEST_AGAIN = "Choose 1 to try again or other to close";
        private const string CHOOSE_VALID_VALUE = "Please Choose Valid Value";
        static void Main(string[] args)
        {
            IRandomManager randomManager = new RandomManager();
            IUserInterface userInterface = new ConsoleManager();
            IFactoryManager factory = new FactoryManager(randomManager);
            Run(userInterface, factory);
        }
        private static void Run(IUserInterface userInterface, IFactoryManager factory)
        {
            var options = Enum
                .GetValues(typeof(TroopType))
                .Cast<TroopType>()
                .Select(val => val.ToString());
            userInterface.ShowMessage($"Troops : [{string.Join("|", options)}]");
            int count = 0;
            int total = 0;
            RequestInt(REQUEST_COUNT, userInterface, (a) =>
            {
                if (options.Count() < a)
                {
                    userInterface.ShowMessage($"Max is {options.Count()}");
                    count = options.Count();
                }
                else
                {
                    count = a;
                }
            });
            List<TroopType> troops = new List<TroopType>();
            for (int i = 0; i < count; i++)
            {
                RequestTroop(userInterface, a =>
                {
                    if (troops.Contains(a))
                    {
                        i--;
                        userInterface.ShowMessage(CHOOSE_VALID_VALUE);
                    }
                    else
                    {
                        troops.Add(a);
                    }
                });
            }
            RequestInt(REQUEST_TOTAL, userInterface, a => total = a);
            do
            {
                Dictionary<TroopType, int> finalResult = factory.GetTroops(troops.ToList(), total * 30 / 100, total * 70 / 100, total);
                userInterface.ShowResult(finalResult, count, total);
            } while (Again(userInterface));
        }
        private static bool Again(IUserInterface userInterface)
        {
            return userInterface.RequestInput(REQUEST_AGAIN) == "1";
        }

        private static void RequestInt(string message, IUserInterface userInterface, Action<int> onSuccess)
        {
            userInterface.RequestChoice(message, onSuccess, (e) =>
            {
                RequestInt(message, userInterface, onSuccess);
            });
        }
        private static void RequestTroop(IUserInterface userInterface, Action<TroopType> onSuccess)
        {
            userInterface.RequestChoice<TroopType>(REQUEST_TROOP, onSuccess, (e) =>
            {
                RequestTroop(userInterface, onSuccess);
            });
        }
    }
}
