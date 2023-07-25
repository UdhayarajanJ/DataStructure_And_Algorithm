using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_And_Algorithm.Datastructure
{
    //Creating A Node.
    public class Node
    {
        public Node _next;
        public int _data;
        public Node(int data)
        {
            _data = data;
            _next = null;
        }
    }
    /// <summary>
    /// Simple Linked List Implementation
    /// </summary>
    public class LinkedList
    {
        public Node _head;
        public LinkedList()
        {
            
        }
        

        public void Add3Nodes()
        {
            //Assign Values

            Node firstNode = new Node(12);
            Node secondNode = new Node(20);
            Node thirdNode = new Node(25);


            //Connect Node

            _head = firstNode;
            _head._next = secondNode;
            secondNode._next = thirdNode;


            //Printing Nodes

            while (_head != null)
            {
                Console.Write("{0} -> \t",_head._data);
                _head = _head._next;
            }
        }
    }
}
