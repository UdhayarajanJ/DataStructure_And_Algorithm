using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_And_Algorithm.Datastructure
{
    class DoublelyCircularLinkedList
    {
        DoubleLinkedListNode _firstNode;
        DoubleLinkedListNode _lastNode;

        public DoublelyCircularLinkedList()
        {

        }

        

        public void Add3Nodes()
        {
            DoubleLinkedListNode nodeOne = new DoubleLinkedListNode(10);
            DoubleLinkedListNode nodeTwo = new DoubleLinkedListNode(20);
            DoubleLinkedListNode nodeThree = new DoubleLinkedListNode(30);

            nodeOne._next = nodeTwo;
            nodeOne._prev = nodeThree;

            nodeTwo._next = nodeThree;
            nodeTwo._prev = nodeOne;

            nodeThree._next = nodeOne;
            nodeThree._prev = nodeTwo;

            _firstNode = nodeOne;
            _lastNode = nodeThree;

            DoubleLinkedListNode traverseNodes = _firstNode;
            bool isReachedAllNodes = false;
            while (!isReachedAllNodes)
            {
                if (_lastNode._next == traverseNodes._next)
                    isReachedAllNodes = true;
                string arrow = traverseNodes._next != _firstNode ? " <=> " : string.Empty;
                Console.Write("{0}{1}",traverseNodes._data,arrow);
                traverseNodes = traverseNodes._next;
            }
        }
    }
}
