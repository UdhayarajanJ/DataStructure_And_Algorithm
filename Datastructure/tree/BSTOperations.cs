using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_And_Algorithm.Datastructure.tree
{
    public class BSTOperations
    {
        private TreeNode rootNode;
        public BSTOperations()
        {
            rootNode = null;
        }

        private void InsertKey(int key)
        {
            rootNode = InsertKey(rootNode, key);
        }

        private TreeNode InsertKey(TreeNode root, int key)
        {
            if (root == null)
            {
                root = new TreeNode(key);
                return root;
            }

            if (key < root.itemValue)
                root.leftNode = InsertKey(root.leftNode, key);
            else
                root.rightNode = InsertKey(root.rightNode, key);

            return root;

        }

        private void InOrderTraversal() => InOrderTraversal(rootNode);
        private void InOrderTraversal(TreeNode root)
        {
            if (root == null)
                return;

            InOrderTraversal(root.leftNode);
            Console.Write("{0} -> ",root.itemValue);
            InOrderTraversal(root.rightNode);
        }

        private void DeleteKey(int key)
        {
            rootNode = DeleteKey(rootNode, key);
        }

        private TreeNode DeleteKey(TreeNode root, int key)
        {
            if (root == null)
                return root;

            if (key < root.itemValue)
                root.leftNode = DeleteKey(root.leftNode, key);
            else if(key>root.itemValue)
                root.rightNode = DeleteKey(root.rightNode, key);
            else
            {
                if (root.leftNode == null)
                    return root.rightNode;

                if (root.rightNode == null)
                    return root.leftNode;

                // If the node has two children
                // Place the inorder successor in position of the node to be deleted
                root.itemValue = MinimumValue(root.rightNode);

                root.rightNode = DeleteKey(root.rightNode, root.itemValue);


            }

            return root;

        }

        private int MinimumValue(TreeNode root)
        {
            int minimumRootKey = root.itemValue;
            while (root != null)
            {
                minimumRootKey = root.leftNode.itemValue;
                root = root.leftNode;
            }
            return minimumRootKey;
        }

        public void BinarySearchTreeOperations()
        {

            InsertKey(8);
            InsertKey(3);
            InsertKey(1);
            InsertKey(6);
            InsertKey(7);
            InsertKey(10);
            InsertKey(14);
            InsertKey(4);

            Console.WriteLine("In-Order-Traversal:\n");
            InOrderTraversal();

            Console.WriteLine("\nAfter Deleting 10.\n");
            DeleteKey(10);
            
            Console.WriteLine("In-Order-Traversal:\n");
            InOrderTraversal();
        }
    }
}
