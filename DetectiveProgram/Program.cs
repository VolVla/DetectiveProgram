using System;
using System.Collections.Generic;
using System.Linq;

namespace DetectiveProgram
{
    internal class Program
    {
        static void Main()
        {
            Detective detective = new Detective();
            ConsoleKey exitButton = ConsoleKey.Enter;
            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine("Для начало работы нажмите на любую клавишу");
                Console.ReadKey();
                Console.Clear();
                detective.WorkDetective();
                Console.WriteLine($"\nВы хотите выйти из программы?Нажмите {exitButton}.\nДля продолжение работы нажмите любую другую клавишу");

                if (Console.ReadKey().Key == exitButton)
                {
                    Console.WriteLine("Вы вышли из программы");
                    isWork = false;
                }

                Console.Clear();
            }
        }
    }

    class Detective
    {
        private List<Criminal> _criminals;

        public Detective()
        {
            _criminals = new List<Criminal>
            {
                new Criminal("Petrov Alexand Vladimirovich ", Nationality.Russian, 175, 60, true),
                new Criminal("Vladimir Nicolai Antonovich", Nationality.Polish, 162, 50, false),
                new Criminal("Antonov Vladislav Petrovich", Nationality.Swedish, 180, 70, false),
                new Criminal("Valeri Valeri Alexandrovich", Nationality.Bulgarian, 170, 70, false),
                new Criminal("Ivanov Ivan Gvozdikov", Nationality.Russian, 200, 160, false)
            };
        }

        public void WorkDetective()
        {
            bool isCorrect = false;

            while (isCorrect == false)
            {
                Console.WriteLine($"Введите Рост");
                bool checkHeight = int.TryParse(Console.ReadLine(), out int _heightCriminal);

                if (checkHeight == false)
                {
                    Console.WriteLine("Введены не корректные данные роста");
                    continue;
                }

                Console.WriteLine("Вес");
                bool checkWeight = int.TryParse(Console.ReadLine(), out int _weightCriminal);

                if (checkWeight == false)
                {
                    Console.WriteLine("Введены не корректные данные веса");
                    continue;
                }

                Console.WriteLine("Национальность преступника");
                bool checkNational = Enum.TryParse(Console.ReadLine(), out Nationality nationality);

                if (checkNational == false)
                {
                    Console.WriteLine("Введены не корректные данные национальности");
                    continue;
                }

                var filteredCriminals = _criminals.Where(criminal => criminal.IsDetention == false && (criminal.Height == _heightCriminal && criminal.Weight == _weightCriminal && criminal.Nationality == nationality));
                ShowCriminal(filteredCriminals);
                isCorrect = true;
            }
        }

        private void ShowCriminal(IEnumerable<Criminal> filteredCriminals)
        {
            int emptyList = 0;

            if (filteredCriminals.Count() == emptyList)
            {
                Console.WriteLine("Данный преступник не найден");
            }
            else
            {
                foreach (var criminal in filteredCriminals)
                {
                    Console.WriteLine($"Имя преступника {criminal.FullName},Рост - {criminal.Height} Вес - {criminal.Weight}, Национальность - {criminal.Nationality}");
                }
            }
        }
    }

    enum Nationality
    {
        Unknown,
        Russian,
        Polish,
        Swedish,
        Bulgarian,
    }

    class Criminal
    {
        public Criminal(string fullName, Nationality nationality, int height, int weight, bool isDetention)
        {
            FullName = fullName;
            Nationality = nationality;
            Height = height;
            Weight = weight;
            IsDetention = isDetention;
        }

        public Nationality Nationality { get; private set; }
        public bool IsDetention { get; private set; }
        public string FullName { get; private set; }
        public int Height { get; private set; }
        public int Weight { get; private set; }
    }
}