using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_And_Algorithm.Datastructure.heaps
{
    public class MaxHeapOperation
    {
        private ArrayList _arrayList;
        public MaxHeapOperation() => _arrayList = new ArrayList();
        // Size Of The Heap
        private Task<int> SizeOfTheHeap() => _arrayList is null ? Task.FromResult(0) : Task.FromResult(_arrayList.Count);
        //Insert Node
        private async Task InsertNode(int value)
        {
            int size = await SizeOfTheHeap();

            if (size == 0)
                _arrayList.Add(value);
            else
            {
                _arrayList.Add(value);
                for (int i = (size / 2) - 1; i >= 0; i--)
                    await Heapify(i);

            }
        }
        //Heapfify
        private async Task Heapify(int currentItemIndex)
        {
            int size = await SizeOfTheHeap();
            int largest = currentItemIndex;

            int leftChildNode = 2 * currentItemIndex + 1;
            int rightChildNode = 2 * currentItemIndex + 2;

            if (leftChildNode < size && (int)_arrayList[leftChildNode] > (int)_arrayList[largest])
                largest = leftChildNode;
            if (rightChildNode < size && (int)_arrayList[rightChildNode] > (int)_arrayList[largest])
                largest = rightChildNode;

            if (largest != currentItemIndex)
            {
                int temp = (int)_arrayList[largest];
                _arrayList[largest] = _arrayList[currentItemIndex];
                _arrayList[currentItemIndex] = temp;
                await Heapify(largest);
            }
        }

        //DeleteNode
        private async Task DeleteNode(int value)
        {
            int size = await SizeOfTheHeap();
            int foundIndexValue = 0;
            bool isFound = false;

            for (int i = 0; i < size; i++)
            {
                if (value == (int)_arrayList[i])
                {
                    foundIndexValue = i;
                    isFound = true;
                    break;
                }
            }

            if (!isFound)
            {
                Console.WriteLine("Value Not Found In The Heap. Enter Correct Value.");
                return;
            }

            int temp = (int)_arrayList[foundIndexValue];
            _arrayList[foundIndexValue] = _arrayList[size - 1];
            _arrayList[size - 1] = temp;

            _arrayList.RemoveAt(size - 1);

            for (int i = (size / 2) - 1; i >= 0; i--)
                await Heapify(i);
        }

        private void PrintNodes()
        {
            int index = 0;
            foreach (int item in _arrayList)
                Console.WriteLine("[ " + item + " ]  -> [" + index++ + "]");
            Console.WriteLine("\n");
        }


        public void HeapOperation()
        {
            int subMenuChoice = 0;
            do
            {
                Console.WriteLine("\n1.Insert The Node");
                Console.WriteLine("2.Remove The Node");
                Console.WriteLine("3.Display The Node");
                Console.Write("\nEnter the option : ");
                int option = Convert.ToInt32(Console.ReadLine());
                int data = 0;
                switch (option)
                {
                    case 1:
                        Console.Write("\nEnter the Node Value :");
                        data = Convert.ToInt32(Console.ReadLine());
                        InsertNode(data).Wait();
                        break;
                    case 2:
                        Console.Write("\nEnter the Node Value :");
                        data = Convert.ToInt32(Console.ReadLine());
                        DeleteNode(data).Wait();
                        break;
                    case 3:
                        PrintNodes();
                        break;
                    default:
                        Console.WriteLine("Invalid Option.");
                        break;
                }
                Console.Write("\nTo you want to continue then. [ press - {0} ].", 2);
                subMenuChoice = Convert.ToInt32(Console.ReadLine());
            } while (subMenuChoice == 2);
        }
    }
}
