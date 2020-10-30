using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Given an array of integers, find the pair of adjacent elements that has the largest product and return that product.

Example

For inputArray = [3, 6, -2, -5, 7, 3], the output should be
adjacentElementsProduct(inputArray) = 21.

7 and 3 produce the largest product.
*/

namespace AdjacentElementsProduct
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(AdjacentElementsProduct(new int[] { 3, 8, -2, 5, 7, 3 }));
        }

        static int AdjacentElementsProduct(int[] inputArray)
        {
            int base1 = 0;
            int base2 = 1;
            int[] newArray = new int[inputArray.Length - 1];

            for (int i = 1; i < inputArray.Length; i++)
            {
                newArray[base1] = inputArray[base1] * inputArray[base2];
                base1++;
                base2++;
            }

            return newArray.Max();

        }
    }
}
