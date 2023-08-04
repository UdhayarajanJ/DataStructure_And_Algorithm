using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_And_Algorithm.Datastructure.tree
{
    public class FullBinaryTree
    {
        private TreeNode rootNode;
        public FullBinaryTree()
        {
            rootNode = null;
        }

        private bool IsFullBinaryTree(TreeNode rootNode)
        {
            // Checking tree emptiness
            if (rootNode == null)
                return true;

            // Checking the children
            if (rootNode.leftNode == null && rootNode.rightNode == null)
                return true;

            if ((rootNode.leftNode != null) && (rootNode.rightNode != null))
                return (IsFullBinaryTree(rootNode.leftNode) && IsFullBinaryTree(rootNode.rightNode));

            return false;
        }

        public void FullBinaryTreeOperations()
        {
            rootNode = new TreeNode(1);
            rootNode.leftNode = new TreeNode(5);
            rootNode.rightNode = new TreeNode(7);
            rootNode.leftNode.leftNode = new TreeNode(11);
            rootNode.leftNode.rightNode = new TreeNode(12);      
            rootNode.rightNode.leftNode = new TreeNode(15);
            //rootNode.rightNode.rightNode = new TreeNode(67);

            
            if(IsFullBinaryTree(rootNode))
                Console.WriteLine("Is a full binary tree.");
            else
                Console.WriteLine("Is not a full binary tree.");

         
        }
    }
}
