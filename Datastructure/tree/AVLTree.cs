using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_And_Algorithm.Datastructure.tree
{
   internal class AVLTreeNode
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

        // Get Balance factor of node N
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
            /* 1. Perform the normal BST insertion */
            if (root == null)
                return new AVLTreeNode(value);

            if (value < root.value)
                root.leftNode = InsertNode(root.leftNode, value);
            else if (value > root.value)
                root.rightNode = InsertNode(root.rightNode, value);
            else
                return root; // Duplicate keys not allowed

            /* 2. Update height of this ancestor node */

            root.height = 1 + MaximumHeight(Height(root.leftNode), Height(root.rightNode));

            /* 3. Get the balance factor of this ancestor
            node to check whether this node became
            unbalanced */

            int balance = GetBalanceFactor(root);

            // If this node becomes unbalanced, then there
            // are 4 cases Left Left Case

            if (balance > 1 && value < root.leftNode.value)
                return RightRotate(root);

            // Right Right Case
            if (balance < -1 && value > root.rightNode.value)
                return LeftRotate(root);

            // Left Right Case
            if (balance > 1 && value > root.leftNode.value)
            {
                root.leftNode = LeftRotate(root.leftNode);
                return RightRotate(root);
            }

            // Right Left Case
            if (balance < -1 && value < root.rightNode.value)
            {
                root.rightNode = RightRotate(root.rightNode);
                return LeftRotate(root);
            }
            return root;

            //if (balance > 1)
            //{
            //    if (value < root.leftNode.value)
            //        return RightRotate(root);
            //    else if (value > root.leftNode.value)
            //    {
            //        root.leftNode = LeftRotate(root.leftNode);
            //        return RightRotate(root);
            //    }
            //}


            //if (balance < -1)
            //{
            //    if (value > root.rightNode.value)
            //        return LeftRotate(root);
            //    else if (value < root.rightNode.value)
            //    {
            //        root.rightNode = RightRotate(root.rightNode);
            //        return RightRotate(root);
            //    }
            //}

            //return root;
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
            // STEP 1: PERFORM STANDARD BST DELETE
            if (root == null)
                return root;

            // If the key to be deleted is smaller than
            // the root's key, then it lies in left subtree
            if (value < root.value)
                root.leftNode = DeleteNode(root.leftNode, value);

            // If the key to be deleted is greater than the
            // root's key, then it lies in right subtree
            else if (value > root.value)
                root.rightNode = DeleteNode(root.rightNode, value);

            // if key is same as root's key, then this is the node
            // to be deleted
            else
            {
                // node with only one child or no child
                if ((root.leftNode == null) || (root.rightNode == null))
                {
                    AVLTreeNode tempNode = null;
                    if (tempNode == root.leftNode)
                        tempNode = root.rightNode;
                    else
                        tempNode = root.leftNode;

                    // No child case
                    if (tempNode == null)
                    {
                        tempNode = root;
                        root = null;
                    }
                    else // One child case
                        root = tempNode; // Copy the contents of the non-empty child
                }
                else
                {
                    // node with two children: Get the inorder
                    // successor (smallest in the right subtree)

                    AVLTreeNode tempRightNode = NodeWithMinimumValue(root.rightNode);

                    // Copy the inorder successor's data to this node
                    root.value = tempRightNode.value;

                    // Delete the inorder successor
                    root.rightNode = DeleteNode(root.rightNode, tempRightNode.value);
                }
            }

            // If the tree had only one node then return
            if (root == null)
                return root;

            // STEP 2: UPDATE HEIGHT OF THE CURRENT NODE

            root.height = 1 + MaximumHeight(Height(root.leftNode), Height(root.rightNode));

            // STEP 3: GET THE BALANCE FACTOR
            // OF THIS NODE (to check whether
            // this node became unbalanced)

            int balance = GetBalanceFactor(root);

            // If this node becomes unbalanced, then there
            // are 4 cases Left Left Case

            if (balance > 1 && value < root.leftNode.value)
                return RightRotate(root);

            // Right Right Case
            if (balance < -1 && value > root.rightNode.value)
                return LeftRotate(root);

            // Left Right Case
            if (balance > 1 && value > root.leftNode.value)
            {
                root.leftNode = LeftRotate(root.leftNode);
                return RightRotate(root);
            }

            // Right Left Case
            if (balance < -1 && value < root.rightNode.value)
            {
                root.rightNode = RightRotate(root.rightNode);
                return LeftRotate(root);
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
            tree.preOrder(tree._rootNode);
        }
    }
}
