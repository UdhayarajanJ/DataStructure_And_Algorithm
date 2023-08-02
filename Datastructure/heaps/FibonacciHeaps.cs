using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_And_Algorithm.Datastructure.heaps
{
    public class Nodes
    {
        public Nodes prev { get; set; }
        public Nodes next { get; set; }
        public Nodes child { get; set; }
        public Nodes parent { get; set; }
        public int key { get; set; }
        public int degree { get; set; }
        public bool isMarked { get; set; }
    }
    public class FibonacciHeapOperations
    {
        private Nodes minimumNode { get; set; }
        private Nodes foundNode { get; set; }
        private int numberOfNodes { get; set; }

        public FibonacciHeapOperations()
        {
            minimumNode = null;
            numberOfNodes = 0;
        }

        public void InsertNode(int key)
        {
            Nodes newNodes = new Nodes();
            newNodes.child = null;
            newNodes.parent = null;
            newNodes.prev = newNodes;
            newNodes.next = newNodes;
            newNodes.degree = 0;
            newNodes.key = key;
            InsertNode(newNodes);
        }

        private void InsertNode(Nodes newNode)
        {
            if (minimumNode == null)
            {
                minimumNode = newNode;
                newNode.prev = newNode;
                newNode.next = newNode;
            }
            else
            {
                newNode.next = minimumNode;
                newNode.prev = minimumNode.prev;
                minimumNode.prev.next = newNode;
                minimumNode.prev = newNode;

                if (newNode.key < minimumNode.key)
                    minimumNode = newNode;
            }
            numberOfNodes += 1;
        }

        private int ExtractMin()
        {
            Nodes tempMinimumNode = minimumNode;
            if (tempMinimumNode != null)
            {
                Nodes minimumNodeChild = tempMinimumNode.child;
                Nodes childNextNode = minimumNodeChild;
                Nodes checkMinimumNode = minimumNodeChild;
                if (minimumNodeChild != null)
                {
                    do          
                    {
                        childNextNode = minimumNodeChild.next;
                        InsertNode(minimumNodeChild);
                        minimumNodeChild.parent = null;
                        minimumNodeChild = childNextNode;
                    } while (minimumNodeChild != null && minimumNodeChild != checkMinimumNode);
                }

                tempMinimumNode.prev.next = tempMinimumNode.next;
                tempMinimumNode.next.prev = tempMinimumNode.prev;
                tempMinimumNode.child = null;

                if (tempMinimumNode.next == tempMinimumNode)
                    minimumNode = null;
                else
                {
                    minimumNode = minimumNode.next;
                    Consolidate();
                }

                numberOfNodes -= 1;
                return tempMinimumNode.key;
            }
            return 0;
        }

        public void Consolidate()
        {
            double phiValue = (1.0 + Math.Sqrt(5)) / 2;
            int maxDegree = (int)(Math.Log(numberOfNodes) / Math.Log(phiValue));
            Nodes[] heapNodes = new Nodes[maxDegree + 1];

            for (int i = 0; i <= maxDegree; i++)
                heapNodes[i] = null;

            Nodes tempMinimumNode = minimumNode;
            if (tempMinimumNode != null)
            {
                Nodes checkMinimumNode = minimumNode;
                do
                {
                    int degree = checkMinimumNode.degree;
                    while (heapNodes[degree] != null)
                    {
                        Nodes childrenNode = null;
                        Nodes parentNode = null;
                        if (heapNodes[degree].key > checkMinimumNode.key)
                        {
                            childrenNode = heapNodes[degree];
                            parentNode = checkMinimumNode;
                        }
                        else
                        {
                            childrenNode = checkMinimumNode;
                            parentNode = heapNodes[degree];
                        }
                        HeapLink(childrenNode, parentNode);
                        heapNodes[degree] = null;
                        checkMinimumNode = parentNode;
                        degree += 1;
                    }
                    heapNodes[degree] = checkMinimumNode;
                    checkMinimumNode = checkMinimumNode.next;

                } while (checkMinimumNode != null && checkMinimumNode != tempMinimumNode);

                minimumNode = null;
                for (int i = 0; i <= maxDegree; ++i)
                    if (heapNodes[i] != null)
                        InsertNode(heapNodes[i]);
            }

        }

        public void HeapLink(Nodes child, Nodes parent)
        {
            child.prev.next = child.next;
            child.next.prev = child.prev;

            Nodes parentOldChild = parent.child;

            if (parentOldChild == null)
            {
                child.prev = child;
                child.next = child;
            }
            else
            {
                child.next = parentOldChild;
                child.prev = parentOldChild.prev;

                parentOldChild.prev.next = child;
                parentOldChild.prev = child;

            }

            child.parent = parent;
            parent.child = child;
            parent.degree += 1;
        }

        private void Display()
        {
            Display(minimumNode);
            Console.WriteLine();
        }

        private void Display(Nodes minimumNode)
        {
            Console.Write("(");

            if (minimumNode == null)
            {
                Console.Write(")");
                return;
            }

            else
            {
                Nodes ptr = minimumNode;
                do
                {
                    Console.Write(ptr.key);
                    Nodes childrens = ptr.child;
                    Display(childrens);
                    Console.Write(" -> ");
                    ptr = ptr.next;
                } while (ptr != minimumNode);
                Console.Write(")");
            }
        }

        private Nodes FindNode(int findKeyValue)
        {
            foundNode = null;
            FindNode(findKeyValue, minimumNode);
            return foundNode;
        }

        private void FindNode(int keyValue, Nodes nodeValue)
        {
            if (foundNode != null || nodeValue == null)
                return;
            else
            {
                Nodes tempNode = nodeValue;
                do
                {
                    if (keyValue == tempNode.key)
                        foundNode = tempNode;
                    else
                    {
                        Nodes childNode = tempNode.child;
                        FindNode(keyValue, childNode);
                        tempNode = tempNode.next;
                    }
                } while (tempNode != nodeValue && foundNode == null);
            }
        }

        private void DecreaseKey(int oldKeyValue,int newKeyValue)
        {
            Nodes foundedNode = FindNode(oldKeyValue);
            DecreaseKey(foundedNode, newKeyValue);
        }

        private void DecreaseKey(Nodes foundedNode, int newKeyValue)
        {
            if (newKeyValue > foundedNode.key)
                return;

            foundedNode.key = newKeyValue;
            Nodes parent = foundedNode.parent;

            if(parent!=null && foundedNode.key < parent.key)
            {
                Cut(foundedNode, parent);
                CascadingCut(parent);
            }

            if (foundedNode.key < minimumNode.key)
                minimumNode = foundedNode;
        }

        private void Cut(Nodes foundedNode,Nodes parentNode)
        {
            foundedNode.prev.next = foundedNode.next;
            foundedNode.next.prev = foundedNode.prev;

            parentNode.degree -= 1;
            
            foundedNode.prev = null;
            foundedNode.next = null;
            foundedNode.parent = null;
            InsertNode(foundedNode);
            foundedNode.isMarked = false;
        }

        private void CascadingCut(Nodes parentNode)
        {
            Nodes topLevelParent = parentNode.parent;
            if (topLevelParent != null)
            {
                if (topLevelParent.isMarked == false)
                    topLevelParent.isMarked = true;
                else
                {
                    Cut(parentNode, topLevelParent);
                    CascadingCut(topLevelParent);
                }
            }
        }

        private void DeleteNode(int keyValue)
        {
            Nodes foundNode = FindNode(keyValue);
            DecreaseKey(foundNode, int.MinValue);
            int extractMinValue = ExtractMin();
        }

        public void HeapOperation()
        {
            //Part - 1
            InsertNode(34);
            InsertNode(3);
            InsertNode(200);
            InsertNode(10);
            InsertNode(4);
            InsertNode(123);
            InsertNode(2);
            InsertNode(134);
            InsertNode(13);
            InsertNode(1200);
            InsertNode(110);
            InsertNode(14);
            InsertNode(1123);
            InsertNode(12);
            Console.WriteLine("\n Display All Rooted Value:\n");
            Display();
            Console.WriteLine("\n Extracted Min Value : {0}\n",ExtractMin());
            Display();
            DecreaseKey(14, 11);
            Console.WriteLine("\n After Decrease Key :\n");
            Display();
            DeleteNode(11);
            Console.WriteLine("\n After Delete Node :\n");
            Display();
            //Console.WriteLine("\n Extracted Min Value : {0}\n", ExtractMin());
        }
    }
}
