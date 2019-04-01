using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public class Game
    {
        private int desiredNum;
        private String userName;
        private int attempts = 0;
        private readonly Random random = new Random();
        private readonly List<int> History = new List<int>();

        private static readonly String[] Phrases = {
            ", ты хорошо справляешься :)",
            ", еще немножко и у тебя все получится!",
            ", ты почти у цели!",
            ", хорошо идешь",
            ", ты главное не унывай и все получится"
            };

        public Game() { }
        
        public void Start()
        {
            Console.WriteLine("Здравствуйте! Введите Ваше имя");
            userName = Console.ReadLine();
            desiredNum = random.Next(51) + 1;
            DateTime dateStart = DateTime.Now;
            GameLoop();
            DateTime dateStop = DateTime.Now;
            TimeSpan dif = dateStop - dateStart;
            Console.WriteLine("На игру вы потратили " + dif.Minutes + " минут и " + dif.Seconds + " секунд");
        }

        private void GameLoop()
        {
            int enteredNum = 0;
            while (enteredNum != desiredNum)
            {
                Console.WriteLine("Введите число от 1 до 50");
                String enteredString = Console.ReadLine();
                if (enteredString.Equals("q"))
                {
                    Console.WriteLine("Извините, но вы так и не угадали мое число :(");
                    Console.WriteLine("До свидания");
                    Environment.Exit(0);
                }
                bool isParsingSuccessful = Int32.TryParse(enteredString, out enteredNum);
                if (!isParsingSuccessful)
                {
                    Console.WriteLine("Извините, но я таких чисел не знаю");
                    continue;
                }
                if (enteredNum < 1 || enteredNum > 50)
                {
                    continue;
                }
                attempts++;
                if (enteredNum != desiredNum)
                {
                    History.Add(enteredNum);
                    if (enteredNum < desiredNum)
                    {
                        Console.WriteLine("Ваше число меньше моего");
                    } else
                    {
                        Console.WriteLine("Ваше число больше моего");
                    }
                    if (attempts % 4 == 0)
                    {
                        Console.WriteLine(userName + Phrases[random.Next(Phrases.Length)]);
                    }
                } else
                {
                    Console.WriteLine("Ура! Вы выиграли");
                    Console.WriteLine("Всего попыток: " + attempts);
                    Console.WriteLine("Ваша история:");
                    foreach(var element in History) {
                        Console.WriteLine(element + (element > desiredNum ? " больше" : " меньше"));
                    }
                    Console.WriteLine(desiredNum + " угадали");
                }
            }
        }
    }
}
