using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Requirements
/*
Challenge: given an array of integers, output how many values are included, how
many values are missing between the lowest and highest values, and the values 
that are missing.

Example: int[] values = new int[] {3, 1, 7};
There are 3 included values.
4 values are missing.
The array is missing 2, 4, 5 and 6.
*/
#endregion

namespace MakeArrayConsecutive
{
    class Program
    {
        static List<int> missingValues = new List<int>();
        static int[] values = new int[] { 2, 7, 4, 1, 9 };

        static void Main(string[] args)
        {
            Console.WriteLine("Your array contains {0} values: {1}.\nThere are {2} missing values: {3}",
                values.Length,
                ArrayValues(values),
                ConsecutiveCollection(values),
                MissingValues(missingValues));
        }

        static string ArrayValues(int[] startingValues)
        {
            Array.Sort(values);
            string output = "";

            for (int i = 0; i < values.Length; i++)
            {

                if (values[i] == values[0])
                {
                    output += values[i];
                }
                else if (values[i] != values[values.Length - 1])
                {
                    output += ", " + values[i];
                }
                else 
                {
                    output += " and " + values[i];
                }
            }
            return output;
        }

        static int ConsecutiveCollection(int[] values)
        {
            int minValue = values.Min();
            int maxValue = values.Max();
            int missingNumbers = 0;


            for (int i = minValue + 1; i < maxValue; i++)
            {
                if (!values.Contains(i))
                {
                    missingNumbers++;
                    missingValues.Add(i);
                }
            }
            return missingNumbers;
        }

        static string MissingValues(List<int> values)
        {
            string userNeeds = "";
            if (values.Count > 0)
            {
                for (int i = 0; i < values.Count; i++)
                {
                    if (missingValues[i] == missingValues[values.Count - 1])
                    {
                        userNeeds += " and ";
                    }
                    else if (missingValues[i] != missingValues[0])
                    {
                        userNeeds += ", ";
                    }

                    userNeeds += missingValues[i];

                    if (missingValues[i] == missingValues[values.Count - 1])
                    {
                        userNeeds += ".";
                    }
                }
            }
            return userNeeds;
        }//end MissingValues()
    }
}
