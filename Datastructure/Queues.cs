using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_And_Algorithm.Datastructure
{
    public class Queues
    {
        private int front;
        private int rear;
        private int capacity;
        private int[] queueArr;

        public Queues(int size)
        {
            front = rear = -1;
            capacity = size;
            queueArr = new int[size];
        }


        public void enqueue(int element)
        {
            if (isFull())
            {
                Console.WriteLine("\nQueue is full not available space.");
                return;
            }

            if(front==-1)
                front = 0;

            queueArr[++rear] = element;

            Console.WriteLine("\nInserted element : {0}", element);
        }

        public void dequeue()
        {
            if (isEmpty())
            {
                Console.WriteLine("\nQueue is already empty. Not able to remove item.");
                return;
            }

            int element = queueArr[front];

            if (front >= rear)
                front = rear = -1;
            else
                front++;

            Console.WriteLine("\nRemoved element : {0}", element);
        }

        public void peek()
        {
            if (isEmpty())
            {
                Console.WriteLine("\nQueue is already empty. No any peek item.");
                return;
            }

            int element = queueArr[front];

            Console.WriteLine("\nPeek element : {0}", element);
        }

        public void printQueueItem()
        {
            if (isEmpty())
            {
                Console.WriteLine("\nQueue is already empty. No traverse any item.");
                return;
            }

            for (int i = front; i <= rear; i++)
                Console.WriteLine("Index Value [{0}] || Queue Element Item : {1}", i, queueArr[i]);
        }


        public bool isFull() => front == 0 && rear == capacity - 1;
        public bool isEmpty() => front == -1;
    }
}
