using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_And_Algorithm.Datastructure
{
    public class Dequeue
    {
        private int front;
        private int rear;
        private int capacity;
        private int[] dequeueArray;


        public Dequeue(int sizeOfTheDequeueArray)
        {
            front = -1;
            rear = 0;
            capacity = sizeOfTheDequeueArray;
            dequeueArray = new int[capacity];
        }

        private bool IsFull() => (front == 0 && rear == capacity - 1) || (front == rear + 1);
        private bool IsEmpty() => front == -1;

        public void InsertFront(int element)
        {
            if (IsFull())
            {
                Console.WriteLine("Double ended queue is full. Not able to store any data.");
                return;
            }

            if (front == -1)
            {
                front = 0;
                rear = 0;
            }
            else if (front == 0)
                front = capacity - 1;
            else
                front = front - 1;

            dequeueArray[front] = element;
            Console.WriteLine("{0} is inserted at the front of the queue.", element);
        }

        public void InsertRear(int element)
        {
            if (IsFull())
            {
                Console.WriteLine("Double ended queue is full. Not able to store any data.");
                return;
            }

            if (front == -1)
            {
                front = 0;
                rear = 0;
            }
            else if (rear == capacity - 1)
                rear = 0;
            else
                rear = rear + 1;

            dequeueArray[rear] = element;
            Console.WriteLine("{0} is inserted at the rear of the queue.", element);
        }


        public void DeleteFront()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Double ended queue is empty. Not able to remove any data.");
                return;
            }

            if (front == rear)
            {
                front = -1;
                rear = -1;
            }
            else if (front == capacity - 1)
                front = 0;
            else
                front = front + 1;

            Console.WriteLine("Elements are deleted at the front of the queue.");
        }


        public void DeleteRear()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Double ended queue is empty. Not able to remove any data.");
                return;
            }

            if (front == rear)
            {
                front = -1;
                rear = -1;
            }
            else if (rear == 0)
                rear = capacity - 1;
            else
                rear = rear - 1;

            Console.WriteLine("Elements are deleted at the rear of the queue.");
        }


        public void GetFront()
        {
            if (IsEmpty())
                Console.WriteLine("Double ended queue is empty. Don't have any of the data.");
            else
                Console.WriteLine("Dequeue front index [ {0} ] | Dequeue front of the element is [ {1} ]", front, dequeueArray[front]);
        }

        public void GetRear()
        {
            if (IsEmpty())
                Console.WriteLine("Double ended queue is empty. Don't have any of the data.");
            else
                Console.WriteLine("Dequeue rear index [ {0} ] | Dequeue rear of the element is [ {1} ]", rear, dequeueArray[rear]);
        }

    }
}
