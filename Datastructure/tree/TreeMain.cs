using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_And_Algorithm.Datastructure.tree
{
    public class TreeMain
    {
        public void TreeOperation()
        {
            int subMenuChoice = 0;
            do
            {
                Console.WriteLine("\n1.Tree Traversal");
                Console.WriteLine("\n2.Binary Tree Traversal");
               

                Console.Write("\nEnter the option : ");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        TreeTraversal treeTraversal = new();
                        treeTraversal.TreeTraversalMain();
                        break;
                    case 2:
                        BinaryTree binaryTree = new();
                        binaryTree.BinaryTreeOperations();
                        break;
                    //case 2:
                    //    MinHeapOperation minHeapOperation = new();
                    //    minHeapOperation.HeapOperation();
                    //    break;
                    //case 3:
                    //    FibonacciHeapOperations fibonacciHeaps = new();
                    //    fibonacciHeaps.HeapOperation();
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
