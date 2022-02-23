using System;

namespace GoodGame_Studios_Task.Exceptions
{
    public class UserInputException : Exception
    {
        public readonly string Choice;

        public UserInputException(string choice)
            : base($"Your choice : '{choice}' not valid")
        {
            Choice = choice;
        }
    }
}
