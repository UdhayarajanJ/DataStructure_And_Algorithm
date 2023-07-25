using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_And_Algorithm.Datastructure
{
    public class Stack
    {
        private int[] stackArr = null;
        private int top = -1;
        private int capacity = 0;

        //Creating a stack
        public Stack(int size)
        {
            stackArr = new int[size];
            capacity = size;
            top = -1;
        }

        public void push(int element)
        {
            if (isFull())
            {
                Console.WriteLine("\nStack is full not available space.");
                return;
            }
            Console.WriteLine("\nInserted element : {0}", element);
            stackArr[++top] = element;
        }

        public void pop()
        {
            if (isEmpty())
            {
                Console.WriteLine("\nStack is empty. Not able to remove the item.");
                return;
            }
            Console.WriteLine("\nRemoved element : {0}", stackArr[top]);
            --top;
        }

        public void peek()
        {
            if (isEmpty())
            {
                Console.WriteLine("\nStack is empty. Not available any item.");
                return;
            }
            Console.WriteLine("\nPeek element : {0}", stackArr[top]);
        }

        public void printStackElement()
        {
            for (int i = 0; i <= top; i++)
                Console.WriteLine("Index Value [{0}] || Stack Element Item : {1}", i, stackArr[i]);
        }


        public bool isFull() => top == capacity - 1;
        public bool isEmpty() => top == -1;
    }
}
