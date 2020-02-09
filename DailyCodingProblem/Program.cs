﻿using System;
using System.Collections.Generic;

namespace DailyCodingProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            //Problem1();

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
        /// Given an array of integers, return a new array such that each element of the new array is the product 
        /// of all the numbers in the original array except the one at the current index.
        /// </summary>
        static void Problem2()
        {
            Console.WriteLine("Please enter 5 integers, one at the time!");
            List<int> listOfNumbers = new List<int>();

            while (listOfNumbers.Count < 5)
            {
                Console.Write("Enter an integer: ");

                int number;

                while (!int.TryParse(Console.ReadLine(), out number))
                {
                    Console.Write("Your input is not valid. Please enter an integer: ");
                }

                listOfNumbers.Add(number);
            }

            List<int> listOfProducts = new List<int>();

            for (int i = 0; i < listOfNumbers.Count; i++)
            {
                int product = 1;

                for (int j = 0; j < listOfNumbers.Count; j++)
                {
                    if (j == i)
                    {
                        continue;
                    }

                    product *= listOfNumbers[j];
                }

                listOfProducts.Add(product);
            }

            foreach (int number in listOfProducts)
            {
                Console.Write($"{number} ");
            }
        }
    }
}