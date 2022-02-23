using GoodGame_Studios_Task.Helpers;
using System;
using System.Collections.Generic;

namespace GoodGame_Studios_Task.Interfaces
{
    public interface IUserInterface
    {
        void ShowLine();
        void ShowMessage(object message);
        string RequestInput(string prompt);
        void RequestChoice<T>(string prompt, Action<T> onSuccess, Action<String> onError) where T : struct, Enum;
        void RequestChoice(string prompt, Action<int> onSuccess, Action<String> onError);
        void ShowResult(Dictionary<TroopType, int> result, int count , int total);
    }
}
