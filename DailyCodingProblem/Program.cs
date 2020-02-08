using System;
using System.Collections.Generic;

namespace DailyCodingProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            Problem1();

            Problem2();
        }

        /// <summary>
        /// Given a list of numbers and a number k, return whether any two numbers from the list add up to k.
        /// </summary>
        static void Problem1()
        {
            List<int> listOfNumbers = new List<int>() { 8, 1, 9, 3, 7, 6, 12, 36, 78, 25, 5 };

            Console.Write($"Problem 1- Please enter a number and I'll tell you if any two numbers from the list [{string.Join(", ", listOfNumbers)}] add up to it: ");

            int number;

            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.Write("Your input is invalid. Please enter a valid number: ");
            }

            for (int i = 0; i < listOfNumbers.Count; i++)
            {
                for (int j = i + 1; j < listOfNumbers.Count; j++)
                {
                    int sum = listOfNumbers[i] + listOfNumbers[j];

                    if (sum == number)
                    {
                        Console.WriteLine($"Found two numbers that add up to {number}!\n{listOfNumbers[i]} + {listOfNumbers[j]} = {number}");
                        return;
                    }
                }
            }

            Console.WriteLine($"Sorry! There is not two numbers in the list that add up to {number}");
        }


        /// <summary>
        /// Given an array of integers, return a new array such that each element of the new array is the product of all the numbers in the original array except the one at the current index.
        /// </summary>
        static void Problem2()
        {
            Console.WriteLine("I need you to give me at least five integers. Please enter one at the time!");
            List<int> listOfNumbers = new List<int>();

            while(listOfNumbers.Count < 5)
            {
                Console.Write("Please enter a number: ");
                int number;
                
                while(!int.TryParse(Console.ReadLine(), out number))
                {
                    Console.Write("Your input is not valid. Please enter a integer: ");
                }

                listOfNumbers.Add(number);
                
            }

            List<int> listOfProducts = new List<int>();

            for (int i = 0; i < listOfNumbers.Count; i++)
            {
                int element = listOfNumbers[i];
                listOfNumbers.RemoveAt(i);
                int product = 1;
                
                for (int j = 0; j < listOfNumbers.Count; j++)
                {
                    product *= listOfNumbers[j];
                }

                listOfProducts.Add(product);
                listOfNumbers.Insert(i, element);
            }

            foreach (int number in listOfProducts)
            {
                Console.Write($"{number} ");
            }
        }
    }
}
