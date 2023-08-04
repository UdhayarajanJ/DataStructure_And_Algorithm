using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_And_Algorithm.Datastructure.tree
{
    class CompletelyBinaryTree
    {
        private TreeNode rootNode;
        public CompletelyBinaryTree()
        {
            rootNode = null;
        }

        private int CountNodes(TreeNode root)
        {
            if (root == null)
                return 0;

            return (1 + CountNodes(root.leftNode) + CountNodes(root.rightNode));
        }


        private bool IsCompletelyBinaryTree(TreeNode root, int index, int numberOfNode)
        {
            if (root == null)
                return true;

            if (index >= numberOfNode)
                return false;

            return (IsCompletelyBinaryTree(root.leftNode, 2 * index + 1, numberOfNode) && IsCompletelyBinaryTree(root.rightNode, 2 * index + 2, numberOfNode));
        }

        private TreeNode AddNewNode(int itemValue) => new(itemValue);

        public void CompletelyBinaryTreeOperations()
        {
            rootNode = AddNewNode(10);
            rootNode.leftNode = AddNewNode(8);
            rootNode.rightNode = AddNewNode(11);
            rootNode.leftNode.leftNode = AddNewNode(4);
            rootNode.leftNode.rightNode = AddNewNode(3);
            rootNode.rightNode.leftNode = AddNewNode(14);
            rootNode.rightNode.rightNode = AddNewNode(17);

            int totalNodes = CountNodes(rootNode);
            int index = 0;

            if (IsCompletelyBinaryTree(rootNode, index, totalNodes))
                Console.WriteLine("Is a completely binary tree.");
            else
                Console.WriteLine("Is not a completely binary tree.");


        }
    }
}
