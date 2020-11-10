using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPairingTool
{
    class Program
    {
        static void Main(string[] args)
        {
            bool endProgram = false;
            do
            {
                Console.Title = "Student Pairing Tool";
                List<string> studentList = new List<string>();
                List<string> studentGroups = new List<string>();
                bool exit = false;
                int studentQuantity;

                do
                {
                    Console.Write("Enter number of students: ");
                    bool isValid = int.TryParse(Console.ReadLine(), out studentQuantity);
                    if (isValid)
                    {
                        exit = true;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("That is not a valid number.\n");
                    }
                } while (!exit);

                Console.Clear();

                studentList = AddStudents(studentQuantity);
                studentGroups = StudentSort(studentList);
                Console.WriteLine(GroupDisplay(studentGroups));

                bool endMenu = false;

                do
                {
                    Console.WriteLine("What would you like to do?\n" +
                            "R)esort List\n" +
                            "N)ew List\n" +
                            "E)nd Program");
                    ConsoleKey menuChoice = Console.ReadKey(true).Key;

                    switch (menuChoice)
                    {
                        case ConsoleKey.R:
                            Console.Clear();
                            studentGroups = StudentSort(studentList);
                            Console.WriteLine(GroupDisplay(studentGroups));
                            break;

                        case ConsoleKey.N:
                            endMenu = true;
                            break;

                        case ConsoleKey.E:
                            endMenu = true;
                            endProgram = true;
                            break;

                        default:
                            Console.Clear();
                            Console.WriteLine($"{menuChoice} was not a valid option. Please choose again.");
                            break;
                    }
                } while (!endMenu);
                Console.Clear();
            } while (!endProgram);
            Console.WriteLine("Closing Pairing Tool");
        }//end Main()

        static List<string> AddStudents(int studentNumber)
        {
            Console.Clear();
            List<string> students = new List<string>();

            for (int i = 1; i <= studentNumber; i++)
            {
                bool exit = false;
                do
                {
                    Console.Title = $"Student {i} of {studentNumber}";
                    Console.Write($"Student {i}'s name: ");
                    string studentName = Console.ReadLine().Trim();
                    
                    if (studentName.Length > 0)
                    {
                        students.Add(studentName);
                        exit = true;
                        Console.Clear();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Student name must contain at least one character.");
                    }
                } while (!exit);
            }
            return students;
        }

        static List<string> StudentSort(List<string> students)
        {
            Console.Title = "Your list of student pairs.";
            List<string> groupings = new List<string>();
            List<string> workingList = new List<string>();

            foreach (string name in students)
            {
                workingList.Add(name);
            }

            Random rand = new Random();

            while (workingList.Count > 0)
            {
                if (workingList.Count == 3)
                {
                    groupings.Add(workingList[0] + ", " + workingList[1] + ", and " + workingList[2]);
                    workingList.Clear();
                }
                else
                {
                    int indexOne = rand.Next(workingList.Count);
                    string firstStudent = workingList[indexOne];
                    workingList.Remove(workingList[indexOne]);

                    int indexTwo = rand.Next(workingList.Count);
                    string secondStudent = workingList[indexTwo];
                    workingList.Remove(workingList[indexTwo]);

                    groupings.Add(firstStudent + " and " + secondStudent);
                }
            }
            return groupings;
        }

        static string GroupDisplay(List<string> studentGroups)
        {
            string groupInfo = "Your groups are:\n";
            int count = 1;

            foreach (string group in studentGroups)
            {
                groupInfo += $"{count}) {group}\n";
                count++;
            }

            return groupInfo;
        }
    }
}
