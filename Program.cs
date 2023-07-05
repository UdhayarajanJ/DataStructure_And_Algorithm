using DataStructure_And_Algorithm.Datastructure;
using System;

namespace DataStructure_And_Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            int mainMenuChoice = 0;
            do
            {
                dataStructureOptions();
                executeOptions(chooseOption());
                mainMenuChoice = toYouWantContinueMenu(1);
            } while (mainMenuChoice == 1);

            Console.Read();
        }

        public static void dataStructureOptions()
        {
            Console.WriteLine("\nData Structure And Algorithms.\n\n");

            Console.WriteLine("DataStructures.\n");
            Console.WriteLine("1.Stack");
            Console.WriteLine("2.Queue");
            Console.WriteLine("3.Circular Queue");
            Console.WriteLine("4.Priority Queue");
            Console.WriteLine("5.Deque Queue");
            Console.WriteLine("6.Linked List");
            Console.WriteLine("7.Linked List Operations");
            Console.WriteLine("8.Double Linked List");
            Console.WriteLine("9.Double Linked List Operations");
            Console.WriteLine("10.Circular Linked List");
        }

        public static int numberInputValidate(string number) => int.TryParse(number, out int result) ? result : 0;

        public static int chooseOption()
        {
            Console.Write("\nEnter the option : ");
            string option = Console.ReadLine();
            return numberInputValidate(option);
        }

        public static int toYouWantContinueMenu(int pressValue)
        {
            Console.Write("\nTo you want to continue then. [ press - {0} ].", pressValue);
            string choice = Console.ReadLine();
            return numberInputValidate(choice);
        }

        public static void executeOptions(int options)
        {
            int subMenuChoice = 0;
            int optionsSubMenu = 0;
            switch (options)
            {
                //Stack Operation
                case 1:
                    Console.Write("\nEnter the size of the stack :");
                    int stackOptions = numberInputValidate(Console.ReadLine());
                    Stack stack = new Stack(stackOptions);
                    do
                    {
                        Console.WriteLine("\n1.Push");
                        Console.WriteLine("2.Pop");
                        Console.WriteLine("3.Peek");
                        Console.WriteLine("4.Print Stack Element");
                        optionsSubMenu = chooseOption();
                        switch (optionsSubMenu)
                        {
                            case 1:
                                Console.Write("\nEnter the element :");
                                int element = numberInputValidate(Console.ReadLine());
                                stack.push(element);
                                break;
                            case 2:
                                stack.pop();
                                break;
                            case 3:
                                stack.peek();
                                break;
                            case 4:
                                stack.printStackElement();
                                break;
                            default:
                                Console.WriteLine("Invalid Option.");
                                break;
                        }
                        subMenuChoice = toYouWantContinueMenu(2);
                    } while (subMenuChoice == 2);
                    break;

                //Queue Operation
                case 2:
                    Console.Write("\nEnter the size of the Queue :");
                    int sizeOftheQueue = numberInputValidate(Console.ReadLine());
                    Queues queues = new Queues(sizeOftheQueue);
                    do
                    {
                        Console.WriteLine("\n1.Enqueue");
                        Console.WriteLine("2.Dequeue");
                        Console.WriteLine("3.Peek");
                        Console.WriteLine("4.Print Queue Element");
                        optionsSubMenu = chooseOption();
                        switch (optionsSubMenu)
                        {
                            case 1:
                                Console.Write("\nEnter the element :");
                                int element = numberInputValidate(Console.ReadLine());
                                queues.enqueue(element);
                                break;
                            case 2:
                                queues.dequeue();
                                break;
                            case 3:
                                queues.peek();
                                break;
                            case 4:
                                queues.printQueueItem();
                                break;
                            default:
                                Console.WriteLine("Invalid Option.");
                                break;
                        }
                        subMenuChoice = toYouWantContinueMenu(2);
                    } while (subMenuChoice == 2);
                    break;

                //Circular Queue Operation
                case 3:
                    Console.Write("\nEnter the size of the Circular queue :");
                    int sizeOftheCircularQueue = numberInputValidate(Console.ReadLine());
                    CircularQueue circularQueue = new CircularQueue(sizeOftheCircularQueue);
                    do
                    {
                        Console.WriteLine("\n1.Enqueue");
                        Console.WriteLine("2.Dequeue");
                        Console.WriteLine("3.Front Element");
                        Console.WriteLine("4.Rear Element");
                        Console.WriteLine("5.Print Circular Queue Element");
                        optionsSubMenu = chooseOption();
                        switch (optionsSubMenu)
                        {
                            case 1:
                                Console.Write("\nEnter the element :");
                                int element = numberInputValidate(Console.ReadLine());
                                circularQueue.enqueue(element);
                                break;
                            case 2:
                                circularQueue.dequeue();
                                break;
                            case 3:
                                circularQueue.frontElement();
                                break;
                            case 4:
                                circularQueue.rearElement();
                                break;
                            case 5:
                                circularQueue.printQueueItem();
                                break;
                            default:
                                Console.WriteLine("Invalid Option.");
                                break;
                        }
                        subMenuChoice = toYouWantContinueMenu(2);
                    } while (subMenuChoice == 2);
                    break;



                //Priority Queue Operation
                case 4:

                    PriorityQueue priorityQueue = new PriorityQueue();
                    do
                    {
                        Console.WriteLine("\n1.Enqueue");
                        Console.WriteLine("2.Dequeue");
                        Console.WriteLine("3.Print Priority Queue Element");
                        optionsSubMenu = chooseOption();
                        switch (optionsSubMenu)
                        {
                            case 1:
                                Console.Write("\nEnter the element :");
                                int enQueueElement = numberInputValidate(Console.ReadLine());
                                priorityQueue.enqueue(enQueueElement);
                                break;
                            case 2:
                                Console.Write("\nEnter the element :");
                                int deQueueElement = numberInputValidate(Console.ReadLine());
                                priorityQueue.dequeue(deQueueElement);
                                break;
                            case 3:
                                priorityQueue.printPriorityQueue();
                                break;
                            default:
                                Console.WriteLine("Invalid Option.");
                                break;
                        }
                        subMenuChoice = toYouWantContinueMenu(2);
                    } while (subMenuChoice == 2);
                    break;


                //Dequeue Queue Operation
                case 5:
                    Console.Write("\nEnter the size of the Double ended queue :");
                    int sizeOftheDeQueue = numberInputValidate(Console.ReadLine());
                    Dequeue dequeue = new Dequeue(sizeOftheDeQueue);
                    do
                    {
                        Console.WriteLine("\n1.Insert Front");
                        Console.WriteLine("2.Insert Rear");
                        Console.WriteLine("3.Delete Front");
                        Console.WriteLine("4.Delete Rear");
                        Console.WriteLine("5.Get Front");
                        Console.WriteLine("6.Get Rear");
                        optionsSubMenu = chooseOption();
                        switch (optionsSubMenu)
                        {
                            case 1:
                                Console.Write("\nEnter the element :");
                                int enQueueElement = numberInputValidate(Console.ReadLine());
                                dequeue.InsertFront(enQueueElement);
                                break;
                            case 2:
                                Console.Write("\nEnter the element :");
                                int deQueueElement = numberInputValidate(Console.ReadLine());
                                dequeue.InsertRear(deQueueElement);
                                break;
                            case 3:
                                dequeue.DeleteFront();
                                break;
                            case 4:
                                dequeue.DeleteRear();
                                break;
                            case 5:
                                dequeue.GetFront();
                                break;
                            case 6:
                                dequeue.GetRear();
                                break;
                            default:
                                Console.WriteLine("Invalid Option.");
                                break;
                        }
                        subMenuChoice = toYouWantContinueMenu(2);
                    } while (subMenuChoice == 2);
                    break;


                //Linked List
                case 6:
                    LinkedList linkedList = new LinkedList();
                    linkedList.Add3Nodes();
                    break;


                //Linked List Operation
                case 7:

                    LinkedListOperations linkedListOperations = new LinkedListOperations();
                    do
                    {
                        Console.WriteLine("\n1.Insert Beginning");
                        Console.WriteLine("2.Insert Position");
                        Console.WriteLine("3.Insert End");
                        Console.WriteLine("4.Delete Beginning");
                        Console.WriteLine("5.Delete Position");
                        Console.WriteLine("6.Delete End");
                        Console.WriteLine("7.Traverse Linked List");
                        Console.WriteLine("8.Reverse Traverse Linked List");
                        Console.WriteLine("9.Sorted Linked List");
                        optionsSubMenu = chooseOption();
                        int elementData = 0;
                        switch (optionsSubMenu)
                        {
                            case 1:
                                Console.Write("\nEnter the data :");
                                elementData = numberInputValidate(Console.ReadLine());
                                linkedListOperations.InsertBeginning(elementData);
                                break;
                            case 2:
                                Console.Write("\nEnter the data :");
                                elementData = numberInputValidate(Console.ReadLine());
                                Console.Write("\nEnter the position :");
                                int position = numberInputValidate(Console.ReadLine());
                                linkedListOperations.InsertAtPosition(elementData, position);
                                break;
                            case 3:
                                Console.Write("\nEnter the data :");
                                elementData = numberInputValidate(Console.ReadLine());
                                linkedListOperations.InsertEnd(elementData);
                                break;
                            case 4:
                                linkedListOperations.DeleteBeginning();
                                break;
                            case 5:
                                Console.Write("\nEnter the position :");
                                int positionDelete = numberInputValidate(Console.ReadLine());
                                linkedListOperations.DeletePosition(positionDelete);
                                break;
                            case 6:
                                linkedListOperations.DeleteEnd();
                                break;
                            case 7:
                                linkedListOperations.PrintLinkedList();
                                break;
                            case 8:
                                linkedListOperations.PrintLinkedListReverse();
                                break;
                            case 9:
                                linkedListOperations.SortedLinkedList();
                                break;
                            default:
                                Console.WriteLine("Invalid Option.");
                                break;
                        }
                        subMenuChoice = toYouWantContinueMenu(2);
                    } while (subMenuChoice == 2);
                    break;
                //Double Linked List
                case 8:
                    DoublelyLinkedList doublelyLinkedList = new DoublelyLinkedList();
                    doublelyLinkedList.Add3Nodes();
                    break;
                //Double Linked List Operation
                case 9:

                    DoublelyLinkedListOperation doublelyLinkedListOperation = new DoublelyLinkedListOperation();
                    do
                    {
                        Console.WriteLine("\n1.Insert Beginning");
                        Console.WriteLine("2.Insert Position");
                        Console.WriteLine("3.Insert End");
                        Console.WriteLine("4.Delete Beginning");
                        Console.WriteLine("5.Delete Position");
                        Console.WriteLine("6.Delete End");
                        Console.WriteLine("7.Traverse Linked List");
                        Console.WriteLine("8.Reverse Traverse Linked List");
                        Console.WriteLine("9.Sorted Linked List");
                        optionsSubMenu = chooseOption();
                        int elementData = 0;
                        switch (optionsSubMenu)
                        {
                            case 1:
                                Console.Write("\nEnter the data :");
                                elementData = numberInputValidate(Console.ReadLine());
                                doublelyLinkedListOperation.InsertBeginning(elementData);
                                break;
                            case 2:
                                Console.Write("\nEnter the data :");
                                elementData = numberInputValidate(Console.ReadLine());
                                Console.Write("\nEnter the position :");
                                int position = numberInputValidate(Console.ReadLine());
                                doublelyLinkedListOperation.InsertAtPosition(elementData, position);
                                break;
                            case 3:
                                Console.Write("\nEnter the data :");
                                elementData = numberInputValidate(Console.ReadLine());
                                doublelyLinkedListOperation.InsertEnd(elementData);
                                break;
                            case 4:
                                doublelyLinkedListOperation.DeleteBeginning();
                                break;
                            case 5:
                                Console.Write("\nEnter the position :");
                                int positionDelete = numberInputValidate(Console.ReadLine());
                                doublelyLinkedListOperation.DeletePosition(positionDelete);
                                break;
                            case 6:
                                doublelyLinkedListOperation.DeleteEnd();
                                break;
                            case 7:
                                doublelyLinkedListOperation.PrintLinkedList();
                                break;
                            case 8:
                                doublelyLinkedListOperation.PrintLinkedListReverse();
                                break;
                            case 9:
                                doublelyLinkedListOperation.SortedLinkedList();
                                break;
                            default:
                                Console.WriteLine("Invalid Option.");
                                break;
                        }
                        subMenuChoice = toYouWantContinueMenu(2);
                    } while (subMenuChoice == 2);
                    break;
                //Circular Linked List
                case 10:
                    CircularLinkedList circularLinkedList = new CircularLinkedList();
                    circularLinkedList.Add3Nodes();
                    break;
                default:
                    Console.WriteLine("Invalid Option.");
                    break;
            }
        }
    }
}
