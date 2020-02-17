using System;
using System.Collections.Generic;
using System.Text;

namespace DailyCodingProblem.Models
{
    public class Pair
    {
        public int First { get; set; }

        public int Second { get; set; }

        public Pair(int first, int second)
        {
            First = first;
            Second = second;
        }
    }
}
