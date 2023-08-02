using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_And_Algorithm.Datastructure.tree
{

    public class TreeTraversal
    {
        TreeNode rootNode;

        private void PreorderTraversal(TreeNode node)
        {
            if (node == null)
                return;

            // Traverse root
            Console.Write(node.itemValue + "->");
            // Traverse left
            PreorderTraversal(node.leftNode);
            // Traverse right
            PreorderTraversal(node.rightNode);
        }
        private void InorderTraversal(TreeNode node)
        {
            if (node == null)
                return;

            // Traverse left
            InorderTraversal(node.leftNode);
            // Traverse root
            Console.Write(node.itemValue + "->");
            // Traverse right
            InorderTraversal(node.rightNode);
        }

        private void PostorderTraversal(TreeNode node)
        {
            if (node == null)
                return;

            // Traverse left
            PostorderTraversal(node.leftNode);
            // Traverse right
            PostorderTraversal(node.rightNode);
            // Traverse root
            Console.Write(node.itemValue + "->");
        }



        public void TreeTraversalMain()
        {
            rootNode = new TreeNode(1);
            rootNode.leftNode = new TreeNode(12);
            rootNode.rightNode = new TreeNode(9);
            rootNode.leftNode.leftNode = new TreeNode(5);
            rootNode.leftNode.rightNode = new TreeNode(6);

            Console.WriteLine("\nPre-Order Traversal :");
            PreorderTraversal(rootNode);

            Console.WriteLine("\nIn-Order Traversal :");
            InorderTraversal(rootNode);

            Console.WriteLine("\nPost-Order Traversal :");
            PostorderTraversal(rootNode);
        }
    }
}
