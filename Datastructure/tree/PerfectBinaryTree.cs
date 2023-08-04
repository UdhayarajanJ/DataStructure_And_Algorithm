using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_And_Algorithm.Datastructure.tree
{
    public class PerfectBinaryTree
    {
        TreeNode rootNode;
        public PerfectBinaryTree()
        {
            rootNode = null;
        }

        private int FindTreeDepth(TreeNode root)
        {
            int depth = 0;

            while (root != null)
            {
                depth++;
                root = root.leftNode;
            }

            return depth;
        }


        private bool IsPerfectBinaryTree(TreeNode root, int depth, int level)
        {
            if (root == null)
                return true;

            if (root.leftNode == null && root.rightNode == null)
                return (depth == level + 1);

            if (root.leftNode == null || root.rightNode == null)
                return false;

            return (IsPerfectBinaryTree(root.leftNode, depth, level + 1) && IsPerfectBinaryTree(root.rightNode, depth, level + 1));

        }

        private bool IsPerfectBinaryTree(TreeNode root)
        {
            int depth = FindTreeDepth(root);
            return IsPerfectBinaryTree(root, depth, 0);
        }


        private TreeNode AddNewNode(int itemValue) => new(itemValue);


        public void PerfectBinaryTreeOperations()
        {
            rootNode = AddNewNode(10);
            rootNode.leftNode = AddNewNode(8);
            rootNode.rightNode = AddNewNode(11);
            rootNode.leftNode.leftNode = AddNewNode(4);
            rootNode.leftNode.rightNode = AddNewNode(3);
            rootNode.rightNode.leftNode = AddNewNode(14);
            rootNode.rightNode.rightNode = AddNewNode(17);

            if (IsPerfectBinaryTree(rootNode))
                Console.WriteLine("Is a perfect binary tree.");
            else
                Console.WriteLine("Is not a perfect binary tree.");


        }
    }
}
