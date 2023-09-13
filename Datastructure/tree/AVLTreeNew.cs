using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_And_Algorithm.Datastructure.tree
{
    class AVLNode
    {
        public int height;
        public int data;
        public AVLNode left;
        public AVLNode right;
        public AVLNode(int _data)
        {
            data = _data;
            height = 1;
        }
    }
    public class AVLTreeNew
    {
        private AVLNode root;

        public AVLTreeNew()
        {
            root = null;
        }

        private int GetHeight(AVLNode node)
        {
            if (node == null)
                return 0;
            return node.height;
        }

        private int BalanceFactor(AVLNode node)
        {
            if (node == null)
                return 0;
            return GetHeight(node.left) - GetHeight(node.right);
        }

        private AVLNode InsertNode(AVLNode node, int data)
        {
            if (node == null)
                return new AVLNode(data);

            if (data < node.data)
                node.left = InsertNode(node.left, data);
            else if (data > node.data)
                node.right = InsertNode(node.right, data);
            else
                return node; // Duplicate keys are not allowed

            node.height = 1 + Math.Max(GetHeight(node.left), GetHeight(node.right));

            int balance = BalanceFactor(node);

            //Left Left Case
            if (balance > 1 && data < node.left.data)
                return RotateRight(node);

            //Right Right Case
            if (balance < -1 && data > node.right.data)
                return RotateLeft(node);

            //Left Right Case
            if (balance > 1 && data > node.left.data)
            {
                node.left = RotateLeft(node.left);
                return RotateRight(node);
            }

            //Right Left Case
            if (balance < -1 && data < node.right.data)
            {
                node.right = RotateRight(node.right);
                return RotateLeft(node);
            }

            return node;

        }

        private AVLNode DeleteNode(AVLNode node, int data)
        {
            if (node == null)
                return node;

            if (data < node.data)
                node.left = DeleteNode(node.left, data);
            else if (data > node.data)
                node.right = DeleteNode(node.right, data);
            else
            {
                if (node.left == null || node.right == null)
                {
                    AVLNode temp = node.left ?? node.right;
                    node = temp;
                }
                else
                {
                    AVLNode temp = FindMinNode(node.right);
                    node.data = temp.data;
                    node.right = DeleteNode(node.right, temp.data);
                }
            }

            if (node == null)
                return node;

            node.height = 1 + Math.Max(GetHeight(node.left), GetHeight(node.right));

            int balance = BalanceFactor(node);

            //Left Left Case
            if (balance > 1 && data < node.left.data)
                return RotateRight(node);

            //Right Right Case
            if (balance < -1 && data > node.right.data)
                return RotateLeft(node);

            //Left Right Case
            if (balance > 1 && data > node.left.data)
            {
                node.left = RotateLeft(node.left);
                return RotateRight(node);
            }

            //Right Left Case
            if (balance < -1 && data < node.right.data)
            {
                node.right = RotateRight(node.right);
                return RotateLeft(node);
            }

            return node;

        }

        private AVLNode FindMinNode(AVLNode node)
        {
            while (node.left != null)
                node = node.left;
            return node;
        }

        private AVLNode RotateRight(AVLNode node)
        {
            AVLNode tempNodeleft = node.left;
            AVLNode tempNoderight = tempNodeleft.right;

            tempNodeleft.right = node;
            node.left = tempNoderight;

            node.height = 1 + Math.Max(GetHeight(node.left), GetHeight(node.right));
            tempNodeleft.height = 1 + Math.Max(GetHeight(tempNodeleft.left), GetHeight(tempNodeleft.right));

            return tempNodeleft;
        }

        private AVLNode RotateLeft(AVLNode node)
        {
            AVLNode tempNoderight = node.right;
            AVLNode tempNodeleft = tempNoderight.left;

            tempNoderight.left = node;
            node.right = tempNodeleft;

            node.height = 1 + Math.Max(GetHeight(node.left), GetHeight(node.right));
            tempNoderight.height = 1 + Math.Max(GetHeight(tempNoderight.left), GetHeight(tempNoderight.right));

            return tempNoderight;
        }

        private void printTree(AVLNode currPtr, String indent, bool last)
        {
            if (currPtr != null)
            {
                Console.Write(indent);
                if (last)
                {
                    Console.Write("R----");
                    indent += "   ";
                }
                else
                {
                    Console.Write("L----");
                    indent += "|  ";
                }
                Console.WriteLine(currPtr.data);
                printTree(currPtr.left, indent, false);
                printTree(currPtr.right, indent, true);
            }
        }

        public void AVLTreeOperations()
        {
            AVLTreeNew tree = new AVLTreeNew();
            tree.root = tree.InsertNode(tree.root, 33);
            tree.root = tree.InsertNode(tree.root, 13);
            tree.root = tree.InsertNode(tree.root, 53);
            tree.root = tree.InsertNode(tree.root, 9);
            tree.root = tree.InsertNode(tree.root, 21);
            tree.root = tree.InsertNode(tree.root, 61);
            tree.root = tree.InsertNode(tree.root, 61);
            tree.root = tree.InsertNode(tree.root, 8);
            tree.root = tree.InsertNode(tree.root, 11);
            tree.printTree(tree.root, "", true);
            tree.root = tree.DeleteNode(tree.root, 13);
            Console.WriteLine("After Deletion: ");
            tree.printTree(tree.root,"", true);
        }
    }
}
