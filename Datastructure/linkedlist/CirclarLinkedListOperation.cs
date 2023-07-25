using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_And_Algorithm.Datastructure
{
    public class CirclarLinkedListOperation
    {
        bool _isReachedLast = false;
        Node _firstNode;
        Node _lastNode;
        public void InsertBeginning(int data)
        {
            Node newNode = new Node(data);

            if (_lastNode == null || _firstNode == null)
            {
                _lastNode = newNode;
                _firstNode = newNode;
                _lastNode._next = _firstNode;
            }
            else
            {
                newNode._next = _firstNode;
                _firstNode = newNode;
                _lastNode._next = _firstNode;

            }
            Console.WriteLine("Inserted at beginning and data [ {0} ]", data);
        }


        public void InsertEnd(int data)
        {
            Node newNode = new Node(data);

            if (_lastNode == null || _firstNode == null)
            {
                _lastNode = newNode;
                _firstNode = newNode;
                _lastNode._next = _firstNode;
                return;
            }



            Node _traverseNode = _firstNode;
            while (_traverseNode._next != _firstNode)
                _traverseNode = _traverseNode._next;

            _lastNode = newNode;
            _lastNode._next = _firstNode;

            _traverseNode._next = _lastNode;

            Console.WriteLine("Inserted at end and data [ {0} ]", data);
        }


        public void InsertAtPosition(int data, int position)
        {

            if (position < 0)
            {
                Console.WriteLine("Position must be greater then 0.");
                return;
            }


            Node newNode = new Node(data);

            if (_lastNode == null || _firstNode == null)
            {
                _lastNode = newNode;
                _firstNode = newNode;
                _lastNode._next = _firstNode;
                return;
            }

            if (position == 1)
            {
                InsertBeginning(data);
                return;
            }



            int traceNodeCount = 1;

            Node traceNodes = _firstNode;
            Node previousNode = null;
            Node nextNode = null;

            bool isPositionFound = false;

            while (traceNodes._next != _firstNode)
            {
                previousNode = traceNodes;
                nextNode = traceNodes._next;
                traceNodes = traceNodes._next;
                if (traceNodeCount == position - 1)
                {
                    isPositionFound = true;
                    break;
                }
                traceNodeCount++;
            }

            if (!isPositionFound)
            {
                Console.WriteLine("Not found the position of the linked list.");
                return;
            }

            previousNode._next = newNode;
            newNode._next = nextNode;

            Console.WriteLine("Inserted at position [ {0} ] || Inserted at data [ {1} ]", position, data);
        }


        public void DeleteBeginning()
        {
            if (_firstNode == null)
            {
                Console.WriteLine("Linked list is empty");
                return;
            }

            int removedData = _firstNode._data;

            _firstNode = _firstNode._next;
            _lastNode._next = _firstNode;

            Console.WriteLine("Deleted at beginning and data [ {0} ]", removedData);
        }


        public void DeleteEnd()
        {
            if (_firstNode == null)
            {
                Console.WriteLine("Linked list is empty");
                return;
            }

            Node _last = _firstNode;
            int removedDataValue = 0;

            if (_firstNode._next == _firstNode)
            {
                removedDataValue = _last._data;
                _firstNode = null;
                Console.WriteLine("Deleted at end and data [ {0} ]", removedDataValue);
                return;
            }

            while (_last._next._next != _firstNode)
                _last = _last._next;

            removedDataValue = _last._next._data;
            _last._next = _firstNode;
            _lastNode = _last._next;

            Console.WriteLine("Deleted at end and data [ {0} ]", removedDataValue);
        }


        public void DeletePosition(int position)
        {
            if (position < 0)
            {
                Console.WriteLine("Position must be greater then 0.");
                return;
            }


            if (_firstNode == null)
            {
                Console.WriteLine("Linked list is empty");
                return;
            }

            if (position == 1)
            {
                DeleteBeginning();
                return;
            }


            int nodeTraceCount = 1;
            Node traceNode = _firstNode;
            Node previousNode = null;
            Node nextNode = null;
            bool isPositionFound = false;
            int removedDataValue = 0;

            while (traceNode._next != _firstNode)
            {
                previousNode = traceNode;
                nextNode = traceNode._next;
                traceNode = traceNode._next;
                removedDataValue = traceNode._data;
                if (nodeTraceCount == position - 1)
                {
                    isPositionFound = true;
                    break;
                }
                nodeTraceCount++;
            }

            if (!isPositionFound)
            {
                Console.WriteLine("Not found the position of the linked list.");
                return;
            }

            previousNode._next = nextNode._next;
            Console.WriteLine("Deleted at end and data [ {0} ]", removedDataValue);
        }


        public void PrintLinkedList()
        {
            string arrow = string.Empty;
            Node _traverse = _firstNode;
            while (_traverse._next != _firstNode)
            {
                arrow = _traverse._next != _firstNode ? " -> " : string.Empty;
                Console.Write("{0}{1}", _traverse._data, arrow);
                _traverse = _traverse._next;
            }
            Console.Write("{0}", _traverse._data);
        }


        public void PrintLinkedListOperation(Node firstNode)
        {

            if (_isReachedLast)
            {
                _isReachedLast = false;
                return;
            }

            if (firstNode == _lastNode)
                _isReachedLast = true;

            PrintLinkedListOperation(firstNode._next);

            string arrow = string.Empty;
            Node _traverse = firstNode;
            arrow = _traverse != _firstNode ? " <- " : string.Empty;
            Console.Write("{0}{1}", _traverse._data, arrow);

        }

        public void PrintLinkedListReverse()
        {
            if (_firstNode is not null)
                PrintLinkedListOperation(_firstNode);
            else
                Console.WriteLine("Linked list is empty");
        }

        public void SortedLinkedList()
        {
            Node CurrentNode = _firstNode;
            Node IndexNode = null;
            int temp = 0;

            if (CurrentNode is null)
            {
                Console.WriteLine("Linked list is empty");
                return;
            }

            while (CurrentNode._next != _firstNode)
            {
                IndexNode = CurrentNode._next;

                while (IndexNode != _firstNode)
                {
                    if (CurrentNode._data > IndexNode._data)
                    {
                        temp = CurrentNode._data;
                        CurrentNode._data = IndexNode._data;
                        IndexNode._data = temp;
                    }
                    IndexNode = IndexNode._next;
                }

                CurrentNode = CurrentNode._next;
            }

            PrintLinkedList();
        }
    }
}
