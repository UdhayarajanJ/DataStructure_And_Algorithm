using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_And_Algorithm.Datastructure.hashtable
{
    /*
     
    Let's first understand the chaining to resolve the collision.

    Suppose we have a list of key values

    A = 3, 2, 9, 6, 11, 13, 7, 12 where m = 10, and h(k) = 2k+3

    In this case, we cannot directly use h(k) = ki/m as h(k) = 2k+3

    The index of key value 3 is:
    index = h(3) = (2(3)+3)%10 = 9
     
     */
    public class CollisionResolveChaining
    {

        int capacity = 10;
        HashComponent[] structureOfArray;
        int sizeOfTheHashTable = 0;

        //Initialize Array
        void InitateArray(int capacity)
        {
            capacity = capacity > 0 ? capacity : this.capacity;
            this.capacity = capacity;
            structureOfArray = new HashComponent[capacity];
            for (int i = 0; i < capacity; i++)
            {
                structureOfArray[i] = new HashComponent();
                structureOfArray[i].key = 0;
                structureOfArray[i].data = 0;
            }
        }

        //Hash Function
        int HashFunction(int key) => ((2*key)+3) % capacity;

        //Insert Element
        void InsertData(int key, int data)
        {
            if (sizeOfTheHashTable == capacity)
            {
                Console.WriteLine("Hash Table Is Full Now.");
                return;
            }

            int index = HashFunction(key);
            if (structureOfArray[index].data == 0)
            {
                structureOfArray[index].key = key;
                structureOfArray[index].data = data;
                sizeOfTheHashTable++;
                Console.WriteLine("\n Key {0} has been inserted.", key);
            }
            else if (structureOfArray[index].key == key)
                structureOfArray[index].data = data;
            else
                Console.WriteLine("\n Collision occured.");
        }


        //Remove Element
        void RemoveData(int key)
        {
            int index = HashFunction(key);

            if (structureOfArray == null || structureOfArray[index].data == 0)
                Console.WriteLine("\n Key doesn't existed.");
            else
            {
                structureOfArray[index].key = 0;
                structureOfArray[index].data = 0;
                Console.WriteLine("\n Key {0} has been removed.", key);
                sizeOfTheHashTable--;
            }
        }

        // Display Hash Table
        void DisplayData()
        {
            for (int i = 0; i < capacity; i++)
            {
                if (structureOfArray[i].data == 0)
                    Console.WriteLine("\n Array [ {0} ] : / ", i);
                else
                    Console.WriteLine("\n Key : {1} Array [ {0} ] : {2} ", i, structureOfArray[i].key, structureOfArray[i].data);
            }
        }

        //Size Of The Hash Function
        int SizeOfHashTable() => sizeOfTheHashTable;


        //Hash Table Operation

        public void HashOperation()
        {
            Console.Write("\nEnter the size of the Hash Table :");
            int capacityOfHashTable = Convert.ToInt32(Console.ReadLine());
            InitateArray(capacityOfHashTable);
            int subMenuChoice = 0;
            do
            {
                Console.WriteLine("\n1.Insert The Data");
                Console.WriteLine("2.Remove The Data");
                Console.WriteLine("3.Display The Data");
                Console.WriteLine("4.Size Of The HashTable");
                Console.Write("\nEnter the option : ");
                int option = Convert.ToInt32(Console.ReadLine());
                int key = 0;
                int data = 0;
                switch (option)
                {
                    case 1:
                        Console.Write("\nEnter the key :");
                        key = Convert.ToInt32(Console.ReadLine());
                        Console.Write("\nEnter the data :");
                        data = Convert.ToInt32(Console.ReadLine());
                        InsertData(key, data);
                        break;
                    case 2:
                        Console.Write("\nEnter the key :");
                        key = Convert.ToInt32(Console.ReadLine());
                        RemoveData(key);
                        break;
                    case 3:
                        DisplayData();
                        break;
                    case 4:
                        Console.WriteLine("\n Size of the hashtable : {0}", SizeOfHashTable());
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
