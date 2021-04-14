using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Lesson6
{
    internal static class Program
    {
        private static readonly List<string> _names = new List<string>();

        private static void Main()
        {
            SetUpEncoding();

            while (true)
                ChooseAction();
        }

        private static void ChooseAction()
        {
            WriteLine("Please, choose the action with the book. By entering the number \n1. Show all the book's values.\n2. Delete a name from the book.\n3. Add a name to the book.\n");
            var userOperation = ReadLine();

            switch (userOperation?.Trim())
            {
                case "1": ShowAllNames(); break;
                case "2": DeleteName(); break;
                case "3": AddNewName(); break;
                default: throw new ArgumentException($"Invalid number operation {userOperation}.");
            }
        }

        private static void AddNewName()
        {
            WriteLine("Please, enter a name:");

            var name = ReadLine();
            _names.Add(name);

            WriteLine($"Name {name} has been added.\n");
        }

        private static void DeleteName()
        {
            if (_names.Count == 0)
            {
                WriteLine("There is nothing to delete. The book is empty.\n");
                return;
            }

            WriteLine("Enter the name which you want to delete:");
            var name = ReadLine();

            WriteLine(_names.Remove(name) ? $"Name {name} has been deleted.\n" : $"No such name as {name}.\n");
        }

        private static void ShowAllNames()
        {
            if (_names.Count == 0)
                WriteLine("\nSorry, there are no names in the book.\n");
            else
            {
                WriteLine("Here are all the names in the book.\n");
                _names.ForEach(name => WriteLine(name));
            }
            WriteLine();
        }

        private static void SetUpEncoding()
        {
            InputEncoding = Encoding.Unicode;
            OutputEncoding = Encoding.Unicode;
        }
    }
}