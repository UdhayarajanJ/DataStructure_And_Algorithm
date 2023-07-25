using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_And_Algorithm.Datastructure
{
    public class PriorityQueue
    {
        //fields
        private List<int> arrayList = null;

        //constructor
        public PriorityQueue()
        {
            arrayList = new List<int>();
        }

        //property
        private int getQueueSize => arrayList.Count;


        //priority wise heap the element in the queue

        public void heapify(int indexValue)
        {
            int largestIndexValue = indexValue;
            int Left = 2 * indexValue + 1;
            int Right = 2 * indexValue + 2;

            if (Left < getQueueSize && arrayList[Left] > arrayList[largestIndexValue])
                largestIndexValue = Left;
            if (Right < getQueueSize && arrayList[Right] > arrayList[largestIndexValue])
                largestIndexValue = Right;

            if (largestIndexValue != indexValue)
            {
                int temp = arrayList[largestIndexValue];
                arrayList[largestIndexValue] = arrayList[indexValue];
                arrayList[indexValue] = temp;
                heapify(largestIndexValue);
            }
        }

        //insert the element in the queue
        public void enqueue(int element)
        {
            //check if root node is there or not
            if (getQueueSize == 0)
                arrayList.Add(element);
            else
            {
                arrayList.Add(element);
                for (int i = getQueueSize / 2 - 1; i >= 0; i--)
                    heapify(i);
            }

        }

        //delete the element in the queue
        public void dequeue(int element)
        {

            if (getQueueSize == 0)
            {
                Console.WriteLine("\nPriority queue is empty. Not able to remove any item.");
                return;
            }

            int i = 0;
            for (i = 0; i < getQueueSize; i++)
                if (element == arrayList[i])
                    break;

            int temp = arrayList[i];
            arrayList[i] = arrayList[getQueueSize - 1];
            arrayList[getQueueSize - 1] = temp;

            arrayList.RemoveAt(getQueueSize - 1);
            for (int j = getQueueSize / 2 - 1; i >= 0; i--)
                heapify(j);

        }

        //print queue element

        public void printPriorityQueue()
        {
            for (int i =0; i < getQueueSize; i++)
                Console.WriteLine("\nIndex Value [{0}] || Queue Element Item : {1}", i, arrayList[i]);
        }
    }
}
