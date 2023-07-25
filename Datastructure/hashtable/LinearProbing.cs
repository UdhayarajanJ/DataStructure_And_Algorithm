using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_And_Algorithm.Datastructure.hashtable
{
    /*
    
    Linear Probing

    Linear probing is one of the forms of open addressing. 
    As we know that each cell in the hash table contains a key-value pair, 
    so when the collision occurs by mapping a new key to the cell already occupied by another key, 
    then linear probing technique searches for the closest free locations and adds a new key to that empty cell. 
    In this case, searching is performed sequentially, starting from the position where the collision occurs till the empty cell is not found.

    The key values 3, 2, 9, 6 are stored at the indexes 9, 7, 1, 5 respectively. 
    The calculated index value of 11 is 5 which is already occupied by another key value, i.e., 6. 
    When linear probing is applied, the nearest empty cell to the index 5 is 6; therefore, the value 11 will be added at the index 6.

    The next key value is 13. The index value associated with this key value is 9 when hash function is applied. 
    The cell is already filled at index 9. When linear probing is applied, the nearest empty cell to the index 9 is 0; 
    therefore, the value 13 will be added at the index 0.

     */
    class LinearProbing
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
        int HashFunction(int key) => ((2 * key) + 3) % capacity;

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
            else
            {
                while (structureOfArray[index].data != 0 && structureOfArray[index].key != -1)
                {
                    ++index;
                    index = index % capacity;
                }
                structureOfArray[index].key = key;
                structureOfArray[index].data = data;
                sizeOfTheHashTable++;
                Console.WriteLine("\n Key {0} has been inserted.", key);
            }
        }


        //Remove Element
        void RemoveData(int key)
        {
            //int index = HashFunction(key);
            int i = 0;
            bool isKeyRemoved = false;
            while (i < capacity)
            {
                if (structureOfArray[i].key == key)
                {
                    structureOfArray[i].key = 0;
                    structureOfArray[i].data = 0;
                    isKeyRemoved = true;
                    break;
                }
                i++;
            }

            if (isKeyRemoved)
                Console.WriteLine("\n Key {0} has been removed.", key);
            else
                Console.WriteLine("\n Key doesn't existed.");
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
