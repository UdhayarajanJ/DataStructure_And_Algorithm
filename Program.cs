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



                default:
                    Console.WriteLine("Invalid Option.");
                    break;
            }
        }
    }
}
