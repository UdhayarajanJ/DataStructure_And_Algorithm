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
                    Queues queues= new Queues(sizeOftheQueue);
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



                default:
                    Console.WriteLine("Invalid Option.");
                    break;
            }
        }
    }
}
