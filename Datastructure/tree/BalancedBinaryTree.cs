using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_And_Algorithm.Datastructure.tree
{
    public class TreeHeight
    {
        public int height { get; set; } = 0;
    }
    public class BalancedBinaryTree
    {
        private TreeNode rootNode;
        public BalancedBinaryTree()
        {
            rootNode = null;
        }

        private bool IsHeightBalanced(TreeNode root,TreeHeight height)
        {
            if (root == null)
            {
                height.height = 0;
                return true;
            }

            TreeHeight leftHeight = new TreeHeight();
            TreeHeight rightHeight = new TreeHeight();

            bool leftBalanced = IsHeightBalanced(root.leftNode, leftHeight);
            bool rightBalanced = IsHeightBalanced(root.rightNode, leftHeight);

            int leftHeightValue = leftHeight.height;
            int rightHeightValue = rightHeight.height;

            height.height = (leftHeightValue > rightHeightValue ? leftHeightValue : rightHeightValue) + 1;

            if ((leftHeightValue - rightHeightValue) >= 2 || (rightHeightValue - leftHeightValue) >= 2)
                return false;

            else
                return leftBalanced && rightBalanced;

        }

         private TreeNode AddNewNode(int itemValue) => new(itemValue);

        public void BalancedBinaryTreeOperations()
        {
            TreeHeight height = new TreeHeight();

            rootNode = AddNewNode(10);
            rootNode.leftNode = AddNewNode(8);
            rootNode.rightNode = AddNewNode(11);
            rootNode.leftNode.leftNode = AddNewNode(4);
            rootNode.leftNode.rightNode = AddNewNode(3);
            //rootNode.rightNode.leftNode = AddNewNode(14);
            rootNode.rightNode.rightNode = AddNewNode(17);


            if (IsHeightBalanced(rootNode, height))
                Console.WriteLine("Tree is balanced.");
            else
                Console.WriteLine("Tree is not balanced.");


        }
    }
}
