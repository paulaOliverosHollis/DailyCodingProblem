using DailyCodingProblem.Models;
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

            Problem5();
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
    }
}
