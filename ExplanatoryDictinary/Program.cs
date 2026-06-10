using System;
using System.Collections.Generic;

namespace ExplanatoryDictinary
{
    internal class Program
    {
        const int CommandClearConsole = 1;
        const int CommandWriteAllWordsInDictionary = 2;
        const int InputWord = 3;
        const int CommandExitProgram = 4;

        static void Main(string[] args)
        {
            Dictionary<string, string> explanatoryDictionary = new Dictionary<string, string>(5);

            string[] wordsForDictionary = new string[5] { "аэроплан", "богатырь", "голубой", "дуэт", "изморозь" };
            string[] meaningsOfWords = new string[5] { "летательный аппарат.",
            "1) герой русских былин, воин, совершающий подвиг; 2) человек большой силы.",
            "имеющий окраску цвета неба: светло-синий, небесный, лазурный.",
            "1) музыкальное произведение для двух исполнителей (музыкантов, певцов, танцоров); 2) исполнение такого произведения двумя людьми.",
            "похожий на иней осадок, образующийся в туманную морозную погоду на ветвях деревьев, проводах и т. п.." };

            if (TryFillDictionary(explanatoryDictionary, wordsForDictionary, meaningsOfWords))
                ShowMenu(explanatoryDictionary, wordsForDictionary, meaningsOfWords);
        }

        private static bool TryFillDictionary(Dictionary<string, string> dictionary, string[] words, string[] meanings)
        {
            if (words.Length != meanings.Length)
            {
                Console.WriteLine("Количество слов и объяснений не равны.");
                return false;
            }

            for (int i = 0; i < words.Length; i++)
            {
                if (dictionary.ContainsKey(words[i]))
                    Console.WriteLine("Слово не добавлено, т.к. оно уже есть в словаре.");
                else
                    dictionary.Add(words[i], meanings[i]);
            }
            return true;
        }

        private static void ShowMenu(Dictionary<string, string> explanatoryDictionary, string[] wordsForDictionary, string[] meaningsOfWords)
        {
            int userInput;
            bool userSearch = true;

            Console.WriteLine("Выбрите пункт меню: " +
                $"\nочистить консоль - {CommandClearConsole}" +
                $"\nпоказать все слова в словаре - {CommandWriteAllWordsInDictionary}" +
                $"\nввести слово - {InputWord}" +
                $"\nвыйти из программы - {CommandExitProgram}");

            while (userSearch)
            {
                userInput = ReadInt();
                Console.WriteLine();

                switch (userInput)
                {
                    case CommandClearConsole:
                        Console.Clear();
                        break;

                    case CommandWriteAllWordsInDictionary:
                        WriteAllWords(explanatoryDictionary);
                        break;

                    case InputWord:
                        ReadUserWord(explanatoryDictionary);
                        break;

                    case CommandExitProgram:
                        Console.WriteLine("Вы вышли из программы...");
                        userSearch = false;
                        break;

                    default:
                        Console.WriteLine("Введена неверная команда. Повторите попытку.");
                        break;
                }

                Console.WriteLine("\n");
            }
        }

        private static void WriteAllWords(Dictionary<string, string> explanatoryDictionary)
        {
            foreach (string key in explanatoryDictionary.Keys)
                Console.WriteLine(key);
        }

        private static void ReadUserWord(Dictionary<string, string> explanatoryDictionary)
        {
            Console.Write("Введите интересующее слово: ");
            string userWord = Console.ReadLine();
            userWord = userWord.ToLower();

            if (explanatoryDictionary.ContainsKey(userWord))
                Console.WriteLine($"Значение слова '{userWord}' - {explanatoryDictionary[userWord]}");
            else
                Console.WriteLine("Такого слова в словаре нет.");
        }

        private static int ReadInt()
        {
            int number = 0;
            Console.WriteLine("Введите число: ");

            while (int.TryParse(s: Console.ReadLine(), out number) == false)
                Console.WriteLine("Введённое значение не является числом.");

            return number;
        }
    }
}
