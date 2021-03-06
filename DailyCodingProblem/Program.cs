﻿using DailyCodingProblem.Models;
using System;
using System.Collections.Generic;

namespace DailyCodingProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            //Problem1();

            //Problem2();

            //Problem3();

            //Problem4();

            //Problem5();

            //Problem6();

            Console.WriteLine(Problem7("0123"));
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

        static void Problem3()
        {
            Node root = new Node(
                0,
                new Node(
                    1,
                    new Node(11, null, null),
                    new Node(12, null, null)),
                new Node(
                    2,
                    new Node(21, null, null),
                    new Node(22, null, null)));

            Console.WriteLine(SerializeProblem3(root));
        }

        static string SerializeProblem3(Node root)
        {
            if (root == null)
            {
                return "null/";
            }
            string serializedTree = root.Value.ToString() + "/";

            serializedTree += SerializeProblem3(root.LeftChild);

            serializedTree += SerializeProblem3(root.RightChild);

            return serializedTree;
        }

        //static Node DeserializeProblem3(string serializedTree)
        //{

        //}

        /// <summary>
        /// Given an array of integers, find the first missing positive integer in linear time and constant space. 
        /// In other words, find the lowest positive integer that does not exist in the array. The array can contain duplicates and negative numbers as well.
        /// </summary>
        static void Problem4()
        {
            List<int> numbers = new List<int>() { 3, 4, -1, 1 };

            for (int i = 1; i <= int.MaxValue; i++)
            {
                if (!numbers.Exists(element => element == i))
                {
                    Console.WriteLine($"The lowest positive integer that does not exist in the array is {i}");
                    return;
                }
            }

            Console.WriteLine($"There is no possitive integer under or equal to {int.MaxValue} that is not a part of the array.");
        }

        /// <summary>
        /// Write two functions that take a pair (it can be a pair of ints, strings, etc.) as a parameter. One of the functions returns 
        /// the first item of the pair and the other function returns the second item of the pair.         
        /// </summary>
        static void Problem5()
        {
            Pair pairOfInts = new Pair(7, 8);

            Console.WriteLine($"The pair is [{pairOfInts.First}, {pairOfInts.Second}]. The function GetFirstItem(pair) returned [{GetFirstItem(pairOfInts)}] and " +
                $"the function GetSecondItem(pair) returned [{GetSecondItem(pairOfInts)}].");
        }

        static int GetFirstItem(Pair pair)
        {
            return pair.First;
        }

        static int GetSecondItem(Pair pair)
        {
            return pair.Second;
        }

        /// <summary>
        /// Create a function that accepts RGB values (3 integers) and converts them into their Hexadecimal equivalent
        /// The valid decimal values for RGB are 0 - 255. Any(r, g, b) argument values that fall out of that range should be rounded to the closest valid value.
        /// Hexadecimal Colors should always be 6 digits(i.e.don't shorten 000000 to 0)
        /// </summary>
        static void Problem6()
        {
            Console.WriteLine(ConvertToHex(CheckDecimalValueRange(-1), CheckDecimalValueRange(285), CheckDecimalValueRange(255)));
        }

        static string ConvertToHex(int r, int g, int b)
        {
            return ($"{r.ToString("X2")}{g.ToString("X2")}{b.ToString("X2")}");
        }

        //Checks decimal values to make sure that they are between 0 and 255. If value is out of range, it rounds up or down.
        static int CheckDecimalValueRange(int value)
        {
            if (value < 0)
            {
                return 0;
            }
            else if (value > 255)
            {
                return 255;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Given the mapping a = 1, b = 2, ... z = 26, and an encoded message, count the number of ways it can be decoded.
        /// For example, the message '111' would give 3, since it could be decoded as 'aaa', 'ka', and 'ak'.
        /// You can assume that the messages are decodable. For example, '001' is not allowed.
        /// </summary>
        static int Problem7(string message)
        {
            if (message == null)
            {
                return 0;
            }

            if (message == string.Empty)
            {
                return 1;
            }

            int numberOfPaths = 0;

            if (int.TryParse(message[0].ToString(), out int oneDigit) && oneDigit > 0)
            {
                numberOfPaths += Problem7(message.Substring(1));
            }

            if (message.Length > 1 && message[0] != '0' && int.TryParse(message.Substring(0, 2), out int twoDigits) && twoDigits < 27)
            {
                numberOfPaths += Problem7(message.Substring(2));
            }

            return numberOfPaths;
        }
    }
}
