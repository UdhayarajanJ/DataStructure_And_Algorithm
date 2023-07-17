using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_And_Algorithm.Datastructure
{
    class DoublelyCircularLinkedListOperation
    {
        bool _isReachedLast = false;
        DoubleLinkedListNode _firstNode;
        DoubleLinkedListNode _lastNode;

        public void InsertBeginning(int data)
        {
            DoubleLinkedListNode newNode = new DoubleLinkedListNode(data);

            if (_lastNode == null || _firstNode == null)
            {
                _lastNode = newNode;
                _firstNode = newNode;

                _firstNode._prev = _lastNode;
                _lastNode._next = _firstNode;
            }
            else
            {
                newNode._next = _firstNode;
                newNode._prev = _lastNode;

                _lastNode._next = newNode;
                _firstNode = newNode;

            }
            Console.WriteLine("Inserted at beginning and data [ {0} ]", data);
        }

        public void InsertEnd(int data)
        {
            DoubleLinkedListNode newNode = new DoubleLinkedListNode(data);

            if (_lastNode == null || _firstNode == null)
            {
                _lastNode = newNode;
                _firstNode = newNode;

                _firstNode._prev = _lastNode;
                _lastNode._next = _firstNode;
                return;
            }

            DoubleLinkedListNode lastNode = _lastNode;

            newNode._prev = _lastNode;
            newNode._next = _firstNode;

            _lastNode._next = newNode;
            _firstNode._prev = newNode;

            _lastNode = newNode;

            Console.WriteLine("Inserted at end and data [ {0} ]", data);
        }

        public void InsertPosition(int data, int position)
        {
            if (position <= 0)
            {
                Console.WriteLine("Position must be greater then 0.");
                return;
            }

            DoubleLinkedListNode newNode = new DoubleLinkedListNode(data);

            if (_lastNode == null || _firstNode == null)
            {
                _lastNode = newNode;
                _firstNode = newNode;

                _firstNode._prev = _lastNode;
                _lastNode._next = _firstNode;
                return;
            }

            if (position == 1)
            {
                InsertBeginning(data);
                return;
            }

            int traceNodeCount = 1;

            DoubleLinkedListNode traceNodes = _firstNode;
            DoubleLinkedListNode previousNode = null;
            DoubleLinkedListNode nextNode = null;

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


        public void PrintLinkedList()
        {
            string arrow = string.Empty;
            DoubleLinkedListNode _traverse = _firstNode;
            while (!_isReachedLast)
            {
                arrow = _traverse._next != _firstNode ? " <=> " : string.Empty;
                Console.Write("{0}{1}", _traverse._data, arrow);
                _traverse = _traverse._next;
                if (_lastNode._next == _traverse)
                    _isReachedLast = true;
            }
            _isReachedLast = false;
        }


        public void DeleteBeginning()
        {
            if (_firstNode == null)
            {
                Console.WriteLine("Linked list is empty");
                return;
            }

            int removedData = _firstNode._data;

            if (_firstNode._next == _firstNode)
            {
                removedData = _firstNode._data;
                _firstNode = null;
                Console.WriteLine("Deleted at end and data [ {0} ]", removedData);
                return;
            }

            _firstNode = _firstNode._next;
            _firstNode._prev = _lastNode;
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

            DoubleLinkedListNode _last = _firstNode;
            int removedDataValue = 0;

            if (_last._next == _firstNode)
            {
                removedDataValue = _last._data;
                _firstNode = null;
                Console.WriteLine("Deleted at end and data [ {0} ]", removedDataValue);
                return;
            }

            while (_last._next._next != _firstNode)
                _last = _last._next;

            removedDataValue = _last._next._data;

            //_last._next = _firstNode;

            _lastNode = _last;

            _lastNode._next = _firstNode;
            _firstNode._prev = _lastNode;


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
            DoubleLinkedListNode traceNode = _firstNode;
            DoubleLinkedListNode previousNode = null;
            DoubleLinkedListNode nextNode = null;
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

        public void PrintLinkedListOperation(DoubleLinkedListNode firstNode)
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
            DoubleLinkedListNode _traverse = firstNode;
            arrow = _traverse != _firstNode ? " <=> " : string.Empty;
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
            DoubleLinkedListNode CurrentNode = _firstNode;
            DoubleLinkedListNode IndexNode = null;
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
