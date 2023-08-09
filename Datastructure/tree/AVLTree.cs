using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_And_Algorithm.Datastructure.tree
{
    class AVLTreeNode
    {
        public int height;
        public int value;
        public AVLTreeNode leftNode;
        public AVLTreeNode rightNode;
        public AVLTreeNode(int itemValue)
        {
            value = itemValue;
            height = 1;
        }
    }
    public class AVLTree
    {
        private AVLTreeNode _rootNode;
        public AVLTree()
        {
            _rootNode = null;

        }

        int Height(AVLTreeNode node)
        {
            if (node == null)
                return 0;
            return node.height;
        }

        int MaximumHeight(int leftValue, int rightValue) => leftValue > rightValue ? leftValue : rightValue;

        // Get balance factor of a node
        int GetBalanceFactor(AVLTreeNode node)
        {
            if (node == null)
                return 0;
            return Height(node.leftNode) - Height(node.rightNode);
        }

        AVLTreeNode RightRotate(AVLTreeNode node)
        {
            AVLTreeNode tempLeftNode = node.leftNode;
            AVLTreeNode tempRightNode = node.rightNode;

            tempLeftNode.rightNode = node;
            node.leftNode = tempRightNode;

            node.height = 1 + MaximumHeight(Height(node.leftNode), Height(node.rightNode));
            tempLeftNode.height = 1 + MaximumHeight(Height(tempLeftNode.leftNode), Height(tempLeftNode.rightNode));

            return node;
        }

        AVLTreeNode LeftRotate(AVLTreeNode node)
        {
            AVLTreeNode tempLeftNode = node.leftNode;
            AVLTreeNode tempRightNode = node.rightNode;

            tempRightNode.leftNode = node;
            node.rightNode = tempLeftNode;

            node.height = 1 + MaximumHeight(Height(node.leftNode), Height(node.rightNode));
            tempRightNode.height = 1 + MaximumHeight(Height(tempRightNode.leftNode), Height(tempRightNode.rightNode));

            return node;
        }

        // Insert a node
        AVLTreeNode InsertNode(AVLTreeNode root, int value)
        {
            if (root == null)
                return new AVLTreeNode(value);

            if (value < root.value)
                root.leftNode = InsertNode(root.leftNode, value);
            else if (value > root.value)
                root.rightNode = InsertNode(root.rightNode, value);
            else
                return root;

            // Update the balance factor of each node
            // And, balance the tree

            root.height = 1 + MaximumHeight(Height(root.leftNode), Height(root.rightNode));
            int balance = GetBalanceFactor(root);

            if (balance > 1)
            {
                if (value < root.leftNode.value)
                    return RightRotate(root);
                else if (value > root.leftNode.value)
                {
                    root.leftNode = LeftRotate(root.leftNode);
                    return RightRotate(root);
                }
            }


            if (balance < -1)
            {
                if (value > root.rightNode.value)
                    return LeftRotate(root);
                else if (value < root.rightNode.value)
                {
                    root.rightNode = RightRotate(root.rightNode);
                    return RightRotate(root);
                }
            }

            return root;
        }


        AVLTreeNode NodeWithMinimumValue(AVLTreeNode node)
        {
            AVLTreeNode currentNode = node;
            while (currentNode.leftNode != null)
                currentNode = currentNode.leftNode;
            return currentNode;
        }

        AVLTreeNode DeleteNode(AVLTreeNode root, int value)
        {
            if (root == null)
                return root;

            if (value < root.value)
                root.leftNode = DeleteNode(root.leftNode, value);
            else if (value > root.value)
                root.rightNode = DeleteNode(root.rightNode, value);
            else
            {
                if ((root.leftNode == null) || (root.rightNode == null))
                {
                    AVLTreeNode tempNode = null;
                    if (tempNode == root.leftNode)
                        tempNode = root.rightNode;
                    else
                        tempNode = root.leftNode;

                    if (tempNode == null)
                    {
                        tempNode = root;
                        root = null;
                    }
                    else
                        root = tempNode;
                }
                else
                {
                    AVLTreeNode tempRightNode = NodeWithMinimumValue(root.rightNode);
                    root.value = tempRightNode.value;
                    root.rightNode = DeleteNode(root.rightNode, tempRightNode.value);
                }

                if (root == null)
                    return root;
            }

            // Update the balance factor of each node
            // And, balance the tree

            root.height = 1 + MaximumHeight(Height(root.leftNode), Height(root.rightNode));
            int balance = GetBalanceFactor(root);

            if (balance > 1)
            {
                if (GetBalanceFactor(root) >= 0)
                    return RightRotate(root);
                else if (value > root.leftNode.value)
                {
                    root.leftNode = LeftRotate(root.leftNode);
                    return RightRotate(root);
                }
            }


            if (balance < -1)
            {
                if (GetBalanceFactor(root) <= 0)
                    return LeftRotate(root);
                else if (value < root.rightNode.value)
                {
                    root.rightNode = RightRotate(root.rightNode);
                    return RightRotate(root);
                }
            }

            return root;
        }

        void preOrder(AVLTreeNode node)
        {
            if (node != null)
            {
                Console.Write(node.value + " ");
                preOrder(node.leftNode);
                preOrder(node.rightNode);
            }
        }

        private void printTree(AVLTreeNode currPtr, String indent, bool last)
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
                Console.WriteLine(currPtr.value);
                printTree(currPtr.leftNode, indent, false);
                printTree(currPtr.rightNode, indent, true);
            }
        }

        public void AVLTreeOperations()
        {
            AVLTree tree = new AVLTree();
            tree._rootNode = tree.InsertNode(tree._rootNode, 33);
            tree._rootNode = tree.InsertNode(tree._rootNode, 13);
            tree._rootNode = tree.InsertNode(tree._rootNode, 53);
            tree._rootNode = tree.InsertNode(tree._rootNode, 9);
            tree._rootNode = tree.InsertNode(tree._rootNode, 21);
            tree._rootNode = tree.InsertNode(tree._rootNode, 61);
            tree._rootNode = tree.InsertNode(tree._rootNode, 8);
            tree._rootNode = tree.InsertNode(tree._rootNode, 11);
            tree.printTree(tree._rootNode, "", true);
            tree._rootNode = tree.DeleteNode(tree._rootNode, 13);
            Console.WriteLine("After Deletion: ");
            tree.printTree(tree._rootNode, "", true);
        }
    }
}
