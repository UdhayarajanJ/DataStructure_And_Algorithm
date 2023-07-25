using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_And_Algorithm.Datastructure.hashtable
{
    public class BasicHashTableOperation
    {

        int capacity = 10;
        HashComponent[] structureOfArray;
        int sizeOfTheHashTable = 0;

        //Initialize Array
        void InitateArray(int capacity)
        {
            capacity = capacity > 0 ? capacity : this.capacity;
            capacity = GetPrime(capacity);
            this.capacity = capacity;
            structureOfArray = new HashComponent[capacity];
            for (int i = 0; i < capacity; i++)
            {
                structureOfArray[i] = new HashComponent();
                structureOfArray[i].key = 0;
                structureOfArray[i].data = 0;
            }
        }

        //Get Prime Value
        int GetPrime(int value)
        {
            if (value % 2 == 0)
                value++;

            while (!CheckPrime(value))
                value += 2;

            return value;
        }

        //Check Prime Value
        bool CheckPrime(int value)
        {
            if (value == 1 || value == 0)
                return false;

            for (int i = 2; i < value / 2; i++)
            {
                if (value % i == 0)
                    return false;
            }
            return true;
        }

        //Hash Function
        int HashFunction(int key) => key % capacity;

        //Insert Element
        void InsertData(int key, int data)
        {
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
