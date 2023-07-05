using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_And_Algorithm.Datastructure
{
    class DoublelyLinkedListOperation
    {
        public DoubleLinkedListNode _head;
        public void InsertBeginning(int data)
        {
            DoubleLinkedListNode newNode = new DoubleLinkedListNode(data);

            newNode._prev = null;
            newNode._next = _head;

            _head = newNode;

            Console.WriteLine("Inserted at beginning and data [ {0} ]", data);
        }

        public void InsertEnd(int data)
        {
            DoubleLinkedListNode newNode = new DoubleLinkedListNode(data);

            if (_head == null)
            {
                _head = newNode;
                return;
            }

            newNode._next = null;

            DoubleLinkedListNode _last = _head;
            while (_last._next != null)
                _last = _last._next;

            newNode._prev = _last;
            _last._next = newNode;

            Console.WriteLine("Inserted at end and data [ {0} ]", data);
        }


        public void InsertAtPosition(int data, int position)
        {

            if (position < 0)
            {
                Console.WriteLine("Position must be greater then 0.");
                return;
            }


            DoubleLinkedListNode newNode = new DoubleLinkedListNode(data);

            if (_head == null)
            {
                _head = newNode;
                return;
            }

            if (position == 0)
            {
                InsertBeginning(data);
                return;
            }



            int traceNodeCount = 0;

            DoubleLinkedListNode traceNodes = _head;
            DoubleLinkedListNode previousNode = null;
            DoubleLinkedListNode nextNode = null;

            bool isPositionFound = false;

            while (traceNodes._next != null)
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

            newNode._prev = previousNode;
            newNode._next = nextNode;

            nextNode._prev = newNode;
            Console.WriteLine("Inserted at position [ {0} ] || Inserted at data [ {1} ]", position, data);
        }

        public void DeleteBeginning()
        {
            if (_head == null)
            {
                Console.WriteLine("Linked list is empty");
                return;
            }

            int removedData = _head._data;

            _head = _head._next;
            _head._prev = null;

            Console.WriteLine("Deleted at beginning and data [ {0} ]", removedData);
        }

        public void DeleteEnd()
        {
            if (_head == null)
            {
                Console.WriteLine("Linked list is empty");
                return;
            }

            DoubleLinkedListNode _last = _head;
            int removedDataValue = 0;

            if (_last._next == null)
            {
                removedDataValue = _last._data;
                _head = null;
                Console.WriteLine("Deleted at end and data [ {0} ]", removedDataValue);
                return;
            }

            while (_last._next._next != null)
                _last = _last._next;

            removedDataValue = _last._next._data;
            _last._next = null;

            Console.WriteLine("Deleted at end and data [ {0} ]", removedDataValue);
        }


        public void DeletePosition(int position)
        {
            if (position < 0)
            {
                Console.WriteLine("Position must be greater then 0.");
                return;
            }


            if (_head == null)
            {
                Console.WriteLine("Linked list is empty");
                return;
            }

            if (position == 0)
            {
                DeleteBeginning();
                return;
            }


            int nodeTraceCount = 0;
            DoubleLinkedListNode traceNode = _head;
            DoubleLinkedListNode previousNode = null;
            DoubleLinkedListNode nextNode = null;
            bool isPositionFound = false;
            int removedDataValue = 0;

            while (traceNode._next != null)
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
            nextNode._prev = previousNode;
            Console.WriteLine("Deleted at end and data [ {0} ]", removedDataValue);
        }

        public void PrintLinkedList()
        {
            string arrow = string.Empty;
            DoubleLinkedListNode _traverse = _head;
            while (_traverse != null)
            {
                arrow = _traverse._next is not null ? " <--> " : string.Empty;
                Console.Write("{0}{1}", _traverse._data, arrow);
                _traverse = _traverse._next;
            }
        }

        public void PrintLinkedListOperation(DoubleLinkedListNode head)
        {
            if (head == null)
                return;

            PrintLinkedListOperation(head._next);

            string arrow = string.Empty;
            DoubleLinkedListNode _traverse = head;
            arrow = _traverse != _head ? " <--> " : string.Empty;
            Console.Write("{0}{1}", _traverse._data, arrow);
        }

        public void PrintLinkedListReverse()
        {
            if (_head is not null)
                PrintLinkedListOperation(_head);
            else
                Console.WriteLine("Linked list is empty");
        }

        public void SortedLinkedList()
        {
            DoubleLinkedListNode CurrentNode = _head;
            DoubleLinkedListNode IndexNode = null;
            int temp = 0;

            if (CurrentNode is null)
            {
                Console.WriteLine("Linked list is empty");
                return;
            }

            while (CurrentNode != null)
            {
                IndexNode = CurrentNode._next;

                while (IndexNode != null)
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
