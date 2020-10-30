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
            List<string> studentList = new List<string>();
            bool exit = false;
            int studentQuantity;
            Random rand = new Random();
            List<string> studentGroups = new List<string>();
            int count = 1;

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

            for (int i = 1; i <= studentQuantity; i++)
            {
                Console.Write("Student name: ");
                studentList.Add(Console.ReadLine());
                Console.Clear();
            }

            //foreach (string student in studentList)
            //{
            //    Console.WriteLine(student);
            //}

            while (studentList.Count > 0)
            {
                if (studentList.Count == 3)
                {
                    studentGroups.Add(studentList[0] + ", " + studentList[1] + ", and " + studentList[2]);
                    studentList.Clear();
                }
                else
                {
                    int indexOne = rand.Next(studentList.Count);
                    string firstStudent = studentList[indexOne];
                    studentList.Remove(studentList[indexOne]);

                    int indexTwo = rand.Next(studentList.Count);
                    string secondStudent = studentList[indexTwo];
                    studentList.Remove(studentList[indexTwo]);

                    studentGroups.Add(firstStudent + " and " + secondStudent);
                }
            }

            Console.WriteLine("Your groups are:");
            foreach (string group in studentGroups)
            {
                Console.WriteLine($"{count}) {group}");
                count++;
            }

        }
    }
}
