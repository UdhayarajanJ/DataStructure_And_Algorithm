using DataStructure_And_Algorithm.Datastructure.hashtable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_And_Algorithm.Datastructure
{
    class HashComponent
    {
        public int key;
        public int data;
    }
    public class HashTableMain
    {
        public void HashOperation()
        {
            //Console.Write("\nEnter the choice you want : ");
            //int capacityOfHashTable = Convert.ToInt32(Console.ReadLine());
            int subMenuChoice = 0;
            do
            {
                Console.WriteLine("\n1.Basic Hash Table Operations.");
                Console.WriteLine("2.Open  Hashing : Collision Resolving Chaining");
                Console.WriteLine("3.Close Hashing : Collision Resolving Linear Probing");
                //Console.WriteLine("3.Display The Data");
                //Console.WriteLine("4.Size Of The HashTable");

                Console.Write("\nEnter the option : ");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        BasicHashTableOperation basicHashTableOperation = new();
                        basicHashTableOperation.HashOperation();
                        break;
                    case 2:
                        CollisionResolveChaining collisionResolveChaining = new();
                        collisionResolveChaining.HashOperation();
                        break;
                    case 3:
                        LinearProbing linearProbing = new();
                        linearProbing.HashOperation();
                        break;
                    //case 2:
                    //    Console.Write("\nEnter the key :");
                    //    key = Convert.ToInt32(Console.ReadLine());
                    //    RemoveData(key);
                    //    break;
                    //case 3:
                    //    DisplayData();
                    //    break;
                    //case 4:
                    //    Console.WriteLine("\n Size of the hashtable : {0}", SizeOfHashTable());
                    //    break;
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
