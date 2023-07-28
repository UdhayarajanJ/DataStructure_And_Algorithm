using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_And_Algorithm.Datastructure.heaps
{
    public class HeapNode
    {
        public HeapNode prev { get; set; }
        public HeapNode next { get; set; }
        public HeapNode child { get; set; }
        public HeapNode parent { get; set; }
        public int key { get; set; }
        public int degree { get; set; }
        public bool isMarked { get; set; }
    }

    //internal class HeapNode
    //{
    //    private HeapNode _parent;
    //    private HeapNode _left;
    //    private HeapNode _right;
    //    private HeapNode _child;
    //    private int _degree;
    //    private bool _isMark;
    //    private int _key;

    //    public HeapNode()
    //    {
    //        _parent = null;
    //        _left = null;
    //        _right = null;
    //        _child = null;
    //        _degree = 0;
    //        _isMark = false;
    //        _key = 0;
    //    }

    //    public HeapNode(int key) : this()
    //    {
    //        this.key = key;
    //    }

    //    public HeapNode parent
    //    {
    //        get => _parent;
    //        set => _parent = value;
    //    }

    //    public HeapNode left
    //    {
    //        get => _left;
    //        set => _left = value;
    //    }

    //    public HeapNode right
    //    {
    //        get => _right;
    //        set => _right = value;
    //    }

    //    public HeapNode child
    //    {
    //        get => _child;
    //        set => _child = value;
    //    }

    //    public int degree
    //    {
    //        get => _degree;
    //        set => _degree = value;
    //    }

    //    public int key
    //    {
    //        get => _key;
    //        set => _key = value;
    //    }

    //    public bool isMark
    //    {
    //        get => _isMark;
    //        set => _isMark = value;
    //    }


    //}
    public class FibonacciHeaps
    {
        HeapNode minimumNode = null;
        HeapNode headOfTheNode = null;
        HeapNode tailOfTheNode = null;
        int numberOfNodes = 0;

        //private HeapNode _min;
        //private int _n;
        //private bool _trace;
        //private HeapNode _found;

        //public FibonacciHeaps()
        //{
        //    _min = null;
        //    _n = 0;
        //    _trace = false;
        //}

        //public bool trace
        //{
        //    get => _trace;
        //    set => _trace = value;
        //}

        //public static FibonacciHeaps CreateHeaps() => new FibonacciHeaps();

        //private void InsertTheNode(HeapNode heapNode)
        //{
        //    if (_min == null)
        //    {
        //        _min = heapNode;
        //        heapNode.left = _min;
        //        heapNode.right = _min;
        //    }
        //    else
        //    {
        //        heapNode.right = _min;
        //        heapNode.left = _min.left;
        //        _min.left.right = heapNode;
        //        _min.left = heapNode;

        //        if (heapNode.key < _min.key)
        //            _min = heapNode;
        //    }
        //    _n += 1;
        //}

        //private void InsertTheNode(int key) => InsertTheNode(new HeapNode(key));

        ////public void DisplayHeaps() => DisplayHeaps(_min);


        ////private void DisplayHeaps(HeapNode min)
        ////{
        ////    Console.Write("(");
        ////    if (min == null)
        ////    {
        ////        Console.Write(")");
        ////        return;
        ////    }
        ////    else
        ////    {
        ////        HeapNode temp = min;
        ////        do
        ////        {
        ////            Console.Write(temp.key);
        ////            HeapNode childNode = temp.child;
        ////            DisplayHeaps(childNode);
        ////            Console.Write(" -> ");
        ////            temp = temp.right;
        ////        } while (temp != min);
        ////        Console.Write(")");
        ////    }
        ////}

        ////public void MergeHeap(FibonacciHeaps f1,FibonacciHeaps f2,FibonacciHeaps f3)
        ////{
        ////    f3._min = f1._min;

        ////    if(f1._min!=null && f2._min != null)
        ////    {
        ////        HeapNode t1 = f1._min.left;
        ////        HeapNode t2 = f2._min.left;
        ////        f1._min.left = t2;
        ////        t1.right = f2._min;
        ////        f2._min.left = t1;
        ////        t2.right = f1._min;
        ////    }

        ////    if(f1._min==null||(f2._min!=null && f2._min.key < f1._min.key))
        ////    {
        ////        f3._min = f2._min;
        ////        f3._n = f1._n + f2._n;
        ////    }
        ////}

        ////public int FindMinimumKey() => _min.key;

        ////public void DisplayNodes(HeapNode heapNode)
        ////{
        ////    Console.WriteLine("Right");
        ////}
        private void InsertTheNode(int keyValue)
        {
            HeapNode newNode = new HeapNode();
            newNode.child = null;
            newNode.parent = null;
            newNode.key = keyValue;

            if (minimumNode == null)
            {

                newNode.prev = newNode;
                newNode.next = newNode;


                headOfTheNode = newNode;
                tailOfTheNode = newNode;

                minimumNode = newNode;
            }
            else
            {

                newNode.next = headOfTheNode;
                newNode.prev = tailOfTheNode;

                headOfTheNode.prev = newNode;
                tailOfTheNode.next = newNode;

                headOfTheNode = newNode;

                if (headOfTheNode.key < minimumNode.key)
                    minimumNode = headOfTheNode;
            }

            numberOfNodes += 1;
        }

        private void Display()
        {
            Display(minimumNode);
            Console.WriteLine();
        }

        private void Display(HeapNode minimumNode)
        {
            /*
             System.out.print("(");
            if (c == null) {
              System.out.print(")");
              return;
            } else {
              node temp = c;
              do {
                System.out.print(temp.get_key());
                node k = temp.get_child();
                display(k);
                System.out.print("->");
                temp = temp.get_right();
              } while (temp != c);
              System.out.print(")");
            }
             */
            Console.Write("(");
            HeapNode ptr = minimumNode;
            if (ptr == null)
            {
                Console.Write(")");
                return;
            }

            else
            {
                //Console.WriteLine("The root nodes of Heap are: ");
                do
                {
                    Console.Write(ptr.key);
                    HeapNode childrens = ptr.child;
                    Display(childrens);
                    Console.Write(" -> ");
                    ptr = ptr.next;
                } while (ptr != minimumNode && ptr.next != null);
                //Console.WriteLine("\nThe heap has " + numberOfNodes + " nodes");
                Console.Write(")");
            }
        }

        private int ExtractMin()
        {
            if (minimumNode == null)
            {
                Console.WriteLine("Fibonacci Heap Is Empty.");
                return 0;
            }

            HeapNode tempMinimumNode = minimumNode;

            if (tempMinimumNode.child != null)
            {
                HeapNode child = tempMinimumNode.child;
                HeapNode currentChild = child;
                do
                {
                    currentChild.parent = null;
                    currentChild = currentChild.next;
                } while (currentChild != child);

                minimumNode.prev.next = child;
                child.prev = minimumNode.prev;
                minimumNode.next.prev = child;
                child.next = minimumNode.next;

                minimumNode.child = null;
            }

            minimumNode.prev.next = minimumNode.next;
            minimumNode.next.prev = minimumNode.prev;

            if (minimumNode == minimumNode.next)
                minimumNode = null;
            else
            {
                minimumNode = minimumNode.next;
                Consolidate();
            }
            numberOfNodes--;
            return tempMinimumNode.key;
        }

        private void Consolidate()
        {
            HeapNode[] heapNodes;

            HeapNode currentMinimumNode = minimumNode;

            do
            {
                int currentNodeDegree = currentMinimumNode.degree;
                int sizeOfDegree = currentMinimumNode.degree + 1;
                
                heapNodes = new HeapNode[sizeOfDegree];
                int i = 0;

                while (i <= currentNodeDegree)
                {
                    heapNodes[i] = null;
                    i++;
                }

                while(heapNodes[currentNodeDegree] != null)
                {
                    HeapNode othersNode = heapNodes[currentNodeDegree];
                    if (currentMinimumNode.key < othersNode.key)
                    {
                        HeapNode swapNode = currentMinimumNode;
                        currentMinimumNode = othersNode;
                        othersNode = swapNode;
                    }
                    HeapLink(currentMinimumNode, othersNode);
                    heapNodes[currentNodeDegree] = null;
                    currentNodeDegree++;
                }


                heapNodes[currentNodeDegree] = currentMinimumNode;
                currentMinimumNode = currentMinimumNode.next;
            } while (currentMinimumNode != minimumNode);

            minimumNode = null;
            foreach (var item in heapNodes)
            {
                if (item == null)
                    continue;

                if (minimumNode == null)
                {
                    minimumNode = item;
                    minimumNode.next = minimumNode;
                    minimumNode.prev = minimumNode;
                }
                else
                {
                    item.prev = minimumNode.prev;
                    item.next = minimumNode;
                    minimumNode.prev.next = item;
                    minimumNode.prev = item;

                    if (item.key < minimumNode.key)
                        minimumNode = item;
                }
            }

        }

        private void HeapLink(HeapNode child,HeapNode parent)
        {
            child.prev.next = child.next;
            child.next.prev = child.prev;

            child.parent = parent;

            if (parent.child == null)
            {
                parent.child = child;
                child.next = child;
                child.prev = child;
            }
            else
            {
                child.prev = parent.child.prev;
                child.next = parent.child;
                parent.child.prev.next = child;
                parent.child.prev = child;
            }
            parent.degree++;
            child.isMarked = false;
        }

        public void HeapOperation()
        {
            InsertTheNode(34);
            InsertTheNode(3);
            InsertTheNode(200);
            InsertTheNode(10);
            InsertTheNode(4);
            InsertTheNode(123);
            InsertTheNode(2);
            Display();
            Console.WriteLine(ExtractMin());
            Display();
        }
    }
}
