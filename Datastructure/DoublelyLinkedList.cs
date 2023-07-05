using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_And_Algorithm.Datastructure
{
    //Create a node of double linked list node
    public class DoubleLinkedListNode
    {
        public DoubleLinkedListNode _prev;
        public DoubleLinkedListNode _next;
        public int _data;
        public DoubleLinkedListNode(int data)
        {
            _prev = null;
            _next = null;
            _data = data;
        }
    }
    public class DoublelyLinkedList
    {
        public DoubleLinkedListNode _head;
        public DoublelyLinkedList()
        {

        }

        public void Add3Nodes()
        {
            //Assign value of nodes
            DoubleLinkedListNode firstNode = new DoubleLinkedListNode(10);
            DoubleLinkedListNode secondNode = new DoubleLinkedListNode(20);
            DoubleLinkedListNode thirdNode = new DoubleLinkedListNode(30);


            //Connect the node
            firstNode._prev = null;
            firstNode._next = secondNode;

            secondNode._prev = firstNode;
            secondNode._next = thirdNode;

            thirdNode._prev = secondNode;
            thirdNode._next = null;

            _head = firstNode;


            //Print the node
            while (_head._next != null)
            {
                Console.Write("{0} -> ",_head._data);
                _head = _head._next;
            }
            Console.Write("{0}", _head._data);

        }
    }
}
