using System;
using System.Collections.Generic;
using System.Text;

namespace DailyCodingProblem.Models
{
    public class Node
    {
        public int Value { get; set; }

        public Node LeftChild { get; set; }

        public Node RightChild { get; set; }

        public Node(int value, Node leftChild, Node rightChild)
        {
            Value = value;
            LeftChild = leftChild;
            RightChild = rightChild;
        }
    }
}
