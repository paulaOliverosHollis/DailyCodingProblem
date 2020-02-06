using System;
using System.Collections.Generic;

namespace DailyCodingProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            Problem1();
        }

        static void Problem1()
        {
            // Given a list of numbers and a number k, return whether any two numbers from the list add up to k.           

            List<int> listOfNumbers = new List<int>() { 8, 1, 9, 3, 7, 6, 12, 36, 78, 25, 5 };

            Console.Write($"Problem 1:\nPlease enter a number and I'll tell you if any two numbers from the list add up to it: ");

            int number;

            while(!int.TryParse(Console.ReadLine(), out number))
            {
                Console.Write("Your input is invalid. Please enter a valid number: ");
            }

            for(int i = 0; i < listOfNumbers.Count; i ++)
            {
                for(int j = i + 1; j < listOfNumbers.Count; j ++)
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
    }
}
