using System;
using System.Collections.Generic;
using System.Linq;
using GoodGame_Studios_Task.Exceptions;
using GoodGame_Studios_Task.Helpers;
using GoodGame_Studios_Task.Interfaces;

namespace GoodGame_Studios_Task.Managers
{
    public class ConsoleManager : IUserInterface
    {

        public void ShowLine()
        {
            Console.WriteLine("===================================");
        }
        public void ShowMessage(object message)
        {
            Console.WriteLine(message);
        }
        public string RequestInput(string prompt)
        {
            Console.WriteLine($"{prompt}: ");
            return Console.ReadLine();
        }

        public void RequestChoice<T>(string prompt, Action<T> onSuccess, Action<string> onError)
            where T : struct, Enum
        {
            var options = Enum
               .GetValues(typeof(T))
               .Cast<T>()
               .Select(val => val.ToString());
            string choice = RequestInput($"{prompt} [{string.Join("|", options)}]");
            try
            {
                if (Enum.TryParse<T>(choice, false, out T result))
                {
                    onSuccess?.Invoke(result);
                }
                else
                {
                    throw new UserInputException(choice);
                }
            }
            catch (UserInputException ex)
            {
                ShowMessage(ex.ToString());
                onError?.Invoke(ex.ToString());
            }
        }
        public void RequestChoice(string prompt, Action<int> onSuccess,Action<string> onError)
        {
            string choice = RequestInput($"{prompt}");
            try
            {
                if (int.TryParse(choice, out int result))
                {
                    onSuccess?.Invoke(result);
                }
                else
                {
                    throw new UserInputException(choice);
                }
            }
            catch (UserInputException ex)
            {
                ShowMessage(ex.ToString());
                onError?.Invoke(ex.ToString());
            }
        }

        public void ShowResult(Dictionary<TroopType, int> result, int count, int total)
        {
            ShowLine();
            ShowMessage($"Count is {count}");
            ShowLine();
            ShowMessage($"Total is {total}");
            ShowLine();
            ShowMessage("Troops is");
            foreach (var item in result)
            {
                ShowMessage($"              - {item.Key}");
            }
            ShowLine();
            foreach (var item in result)
            {
                ShowMessage($"{item.Key} : {item.Value}");
            }
        }
    }
}
