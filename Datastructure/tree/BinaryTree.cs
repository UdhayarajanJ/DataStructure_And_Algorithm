using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_And_Algorithm.Datastructure.tree
{
    public class BinaryTree
    {
        private TreeNode rootNode;
        public BinaryTree()
        {
            rootNode = null;
        }

        private void PreOrder(TreeNode root)
        {
            if (root != null)
            {
                Console.Write("{0} -> ",root.itemValue);
                PreOrder(root.leftNode);
                PreOrder(root.rightNode);
            }
        }

        private void InOrder(TreeNode root)
        {
            if (root != null)
            {
                InOrder(root.leftNode);
                Console.Write("{0} -> ",root.itemValue);
                InOrder(root.rightNode);
            }
        } 

        private void PostOrder(TreeNode root)
        {
            if (root != null)
            {
                PostOrder(root.leftNode);
                PostOrder(root.rightNode);
                Console.Write("{0} -> ",root.itemValue);
            }
        }

        public void BinaryTreeOperations()
        {
            rootNode = new TreeNode(1);
            rootNode.leftNode = new TreeNode(5);
            rootNode.rightNode = new TreeNode(7);
            rootNode.leftNode.leftNode = new TreeNode(11);


            Console.WriteLine("\nPre-Order Traversal :");
            PreOrder(rootNode);

            Console.WriteLine("\nIn-Order Traversal :");
            InOrder(rootNode);

            Console.WriteLine("\nPost-Order Traversal :");
            PostOrder(rootNode);
        }
    }
}
