using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personalAccounting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] fullNames = new string[] { "Новиков Иван Олегович", "Назаренко Илья Александрович", "Солодяникна Елаена Егоровна" };
            string[] jobTitles = new string[] { "Фрезировщик", "Менеджер", "Директор" };

            bool isWork = true;
            int userInput = 0;

            while (isWork)
            {
                const int AddCommand = 1;
                const int DrawDossiersCommand = 2;
                const int DeletedDossiersCommand = 3;
                const int SearchNamesakesCommand = 4;
                const int ExitProgrammCommand = 5;

                DrawMenu(AddCommand, DrawDossiersCommand, DeletedDossiersCommand, SearchNamesakesCommand, ExitProgrammCommand);

                Console.Write("Выберите пункт : ");

                if (int.TryParse(ReadInput(), out int result))
                    userInput = result;                

                switch (userInput)
                {
                    case AddCommand:
                        AddDossierСonclusion(ref fullNames,ref jobTitles);
                        break;
                    case DrawDossiersCommand:
                        DrawDossier(fullNames, jobTitles);
                        break;

                    case DeletedDossiersCommand:
                        DeleteDossierСonclusion(ref fullNames,ref jobTitles);
                        break;

                    case SearchNamesakesCommand:
                        SearchSecondName(fullNames);
                        break;

                    case ExitProgrammCommand:
                        Exit(ref isWork);
                        break;

                    default:
                        Repeat();
                        break;
                }

                Console.Clear();
            }
        }

        static void DrawMenu(int Add, int DrawDossiers, int DeletedDossiers, int SearchNamesakes, int ExitProgramm)
        {
            Console.SetCursorPosition(0, 20);
            Console.WriteLine($"{Add}. Добавить досье\n" +
                $"{DrawDossiers}. Вывести все досье\n" +
                $"{DeletedDossiers}. Удалить досье\n" +
                $"{SearchNamesakes}. Поиск по фамилии\n" +
                $"{ExitProgramm}. Выход");
            Console.SetCursorPosition(0, 0);
        }

        static string ReadInput()
        {
            return Console.ReadLine();
        }

        static void AddDossier(ref string[] array, string name)
        {
            string[] tempArray = new string[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
            {
                tempArray[i] = array[i];
            }

            tempArray[array.Length] = name;
            array = tempArray;
        }

        static void DrawDossier(string[] fullNames, string[] jobTitles)
        {
            for (int i = 0; i < fullNames.Length - 1; i++)
            {
                Console.Write($"{i + 1}. {fullNames[i]} - {jobTitles[i]} ");
            }

            Console.Write($"{fullNames.Length}. {fullNames[fullNames.Length - 1]} - {jobTitles[jobTitles.Length - 1]}");

            Console.ReadKey();
        }

        static int GetIndex()
        {
            Console.Write("Введите номер досье : ");
            int index = Convert.ToInt32(Console.ReadLine()) - 1;
            return index;
        }

        static string[] DeleteDossier(string[] array, int index)
        {
            if (index > array.Length || index < 0)
            {
                Console.WriteLine("неверный индекс");
                return array;
            }

            string[] tempArray = new string[array.Length - 1];

            for (int i = 0; i < index; i++)
            {
                tempArray[i] = array[i];
            }

            for (int i = index; i < tempArray.Length; i++)
            {
                tempArray[i] = array[i + 1];
            }

            return tempArray;
        }

        static void SearchSecondName(string[] fullNames)
        {
            char charToSplit = ' ';

            Console.Write("Введите фамилию : ");
            string lastName = ReadInput();

            for (int i = 0; i < fullNames.Length; i++)
            {
                string[] tempArray = fullNames[i].Split(charToSplit);

                if (tempArray[0].ToLower() == lastName.ToLower())
                {
                    Console.WriteLine(fullNames[i]);
                }
            }

            Console.ReadKey();
        }

        static void Exit(ref bool isWork)
        {
            Console.WriteLine("До свидания!");
            Console.ReadKey();

            isWork = false;
        }

        static void AddDossierСonclusion(ref string[] fullNames,ref string[] jobTitles)
        {
            Console.Write("Введите ФИО : ");
            string fullName = ReadInput();

            Console.Write("Введите должность : ");
            string jobTitle = ReadInput();

            AddDossier(ref fullNames, fullName);
            AddDossier(ref jobTitles, jobTitle);
        }

        static void DeleteDossierСonclusion(ref string[] fullNames,ref string[] jobTitles)
        {
            int index = GetIndex();

            fullNames = DeleteDossier(fullNames, index);
            jobTitles = DeleteDossier(jobTitles, index);
        }

        static void Repeat()
        {
            Console.WriteLine("Попробуйте еще раз!");
            Console.ReadKey();
        }
    }
}
