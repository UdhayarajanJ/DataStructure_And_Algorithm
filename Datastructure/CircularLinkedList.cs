using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_And_Algorithm.Datastructure
{
    public class CircularLinkedList
    {
        public Node _head;
        public CircularLinkedList()
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
            thirdNode._next = _head;


            //Printing Nodes

            Node headNode = _head;

            while (_head._next != headNode)
            {
                Console.Write("{0} -> \t", _head._data);
                _head = _head._next;
            }
            Console.Write("{0}", _head._data);
        }
    }
}
