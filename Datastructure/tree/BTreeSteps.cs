using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_And_Algorithm.Datastructure.tree
{
    public class BTreeNode
    {
        public int n;
        public int[] keys;
        public BTreeNode[] child;
        public bool leafs;
    }
    public class BTree
    {
        public int degree;
        public BTreeNode rootNode;

        public BTree(int degree)
        {
            this.degree = degree;
            rootNode = CreateNode();
        }
        // Create a new node
        private BTreeNode CreateNode()
        {
            BTreeNode bTreeNode = new BTreeNode();
            bTreeNode.keys = new int[2 * degree - 1];
            bTreeNode.child = new BTreeNode[2 * degree];
            bTreeNode.leafs = true;
            bTreeNode.n = 0;
            return bTreeNode;
        }

        // Insert the Key
        public void InsertTheKey(int key)
        {
            BTreeNode tempRoot = rootNode;
            if (tempRoot.n == 2 * degree - 1)
            {
                BTreeNode newNode = CreateNode();
                rootNode = newNode;
                newNode.leafs = false;
                newNode.n = 0;
                newNode.child[0] = tempRoot;
                SplitNode(newNode, 0, tempRoot);
                InsertTheNode(newNode, key);
            }
            else
            {
                InsertTheNode(tempRoot, key);
            }
        }

        //Split The Node

        private void SplitNode(BTreeNode newNode, int position, BTreeNode tempRootNode)
        {
            BTreeNode tempNewNode = CreateNode();
            tempNewNode.leafs = tempRootNode.leafs;
            tempNewNode.n = degree - 1;

            for (int j = 0; j < degree - 1; j++)
            {
                tempNewNode.keys[j] = tempRootNode.keys[j + degree];
            }

            if (!tempRootNode.leafs)
            {
                for (int j = 0; j < degree; j++)
                {
                    tempNewNode.child[j] = tempRootNode.child[j + degree];
                }
            }

            tempRootNode.n = degree - 1;

            for (int j = newNode.n; j >= position + 1; j--)
            {
                newNode.child[j + 1] = newNode.child[j];
            }

            newNode.child[position + 1] = tempNewNode;

            for (int j = newNode.n - 1; j >= position; j--)
            {
                newNode.keys[j + 1] = newNode.keys[j];
            }

            newNode.keys[position] = tempRootNode.keys[degree - 1];
            newNode.n = newNode.n + 1;
        }

        //Insert the Node
        private void InsertTheNode(BTreeNode node, int key)
        {
            if (node.leafs)
            {
                int i = 0;
                for (i = node.n - 1; i >= 0 && key < node.keys[i]; i--)
                    node.keys[i + 1] = node.keys[i];

                node.keys[i + 1] = key;
                node.n = node.n + 1;
            }

            else
            {
                int i = 0;
                
                for (i = node.n - 1; i >= 0 && key < node.keys[i]; i--) { }
                
                i += 1;

                BTreeNode tempChildNode = node.child[i];

                if (tempChildNode.n == (2 * degree - 1))
                {
                    SplitNode(node, i, tempChildNode);
                    if (key > node.keys[i])
                        i += 1;
                }

                InsertTheNode(node.child[i], key);
            }
        }

        //Display The Node

        private void DisplayNode()
        {
            DisplayNode(this.rootNode);
        }

        private void DisplayNode(BTreeNode rootNode)
        {
            for (int i = 0; i < rootNode.n; i++)
                Console.Write(rootNode.keys[i] + " ");

            if (!rootNode.leafs)
                for (int i = 0; i < rootNode.n + 1; i++)
                    DisplayNode(rootNode.child[i]);
        }

        public void BTreeOperation_1()
        {
            BTree b = new BTree(3);
            //b.InitializeTheTree(3);
            b.InsertTheKey(8);
            b.InsertTheKey(9);
            b.InsertTheKey(10);
            b.InsertTheKey(11);
            b.InsertTheKey(15);
            b.InsertTheKey(20);
            b.InsertTheKey(17);
            b.DisplayNode();
        }




    }
}
