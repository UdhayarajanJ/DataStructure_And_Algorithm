using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_And_Algorithm.Datastructure
{
    public class CircularQueue
    {
        private int front;
        private int rear;
        private int capacity;
        private int[] queueArr;

        public CircularQueue(int size)
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

            if (front == -1)
                front = 0;

            rear = (rear + 1) % capacity; // rear is incremented  

            queueArr[rear] = element; // assigning a value to the queue at the rear position.  

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

            if (front == rear) // circular queue have only 1 element
                front = rear = -1;

            else
                front = (front + 1) % capacity;

            Console.WriteLine("\nRemoved element : {0}", element);
        }

        public void frontElement()
        {
            if (isEmpty())
            {
                Console.WriteLine("\nQueue is already empty. No any front item.");
                return;
            }

            int element = queueArr[front];

            Console.WriteLine("\nFront element : {0}", element);

            Console.WriteLine("\nFront pointing the index : {0}", front);
        }

        public void rearElement()
        {
            if (isEmpty())
            {
                Console.WriteLine("\nQueue is already empty. No any rear item.");
                return;
            }

            int element = queueArr[rear];

            Console.WriteLine("\nRear element : {0}", element);

            Console.WriteLine("\nRear pointing the index : {0}", rear);
        }

        public void printQueueItem()
        {
            if (isEmpty())
            {
                Console.WriteLine("\nQueue is already empty. No traverse any item.");
                return;
            }

            int i = 0;

            frontElement();

            for (i = front; i != rear; i = (i + 1) % capacity)
                Console.WriteLine("\nIndex Value [{0}] || Queue Element Item : {1}", i, queueArr[i]);

            Console.WriteLine("\nIndex Value [{0}] || Queue Element Item : {1}", i, queueArr[i]);

            rearElement();
        }


        public bool isFull() => (rear + 1) % capacity == front;
        public bool isEmpty() => front == -1;
    }
}
