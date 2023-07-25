using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_And_Algorithm.Datastructure.heaps
{
   public class HeapMain
    {
        public void HeapOperation()
        {
            int subMenuChoice = 0;
            do
            {
                Console.WriteLine("\n1.Max Heap Operation.");

                Console.Write("\nEnter the option : ");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        MaxHeapOperation maxHeapOperation = new();
                        maxHeapOperation.HeapOperation();
                        break;
                    //case 2:
                    //    CollisionResolveChaining collisionResolveChaining = new();
                    //    collisionResolveChaining.HashOperation();
                    //    break;
                    //case 3:
                    //    LinearProbing linearProbing = new();
                    //    linearProbing.HashOperation();
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

