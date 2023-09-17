using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_And_Algorithm.Datastructure.tree
{
    public class BTreeNode
    {
        public int height;
        public int[] keys;
        public BTreeNode[] child;
        public bool leafs;

        public int FindKey(int key)
        {
            for (int i = 0; i < this.height; i++)
                if (this.keys[i] == key)
                    return i;
            return -1;
        }
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
            bTreeNode.height = 0;
            return bTreeNode;
        }

        // Insert the Key
        public void InsertTheKey(int key)
        {
            BTreeNode tempRoot = rootNode;
            if (tempRoot.height == 2 * degree - 1)
            {
                BTreeNode newNode = CreateNode();
                rootNode = newNode;
                newNode.leafs = false;
                newNode.height = 0;
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
            tempNewNode.height = degree - 1;

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

            tempRootNode.height = degree - 1;

            for (int j = newNode.height; j >= position + 1; j--)
            {
                newNode.child[j + 1] = newNode.child[j];
            }

            newNode.child[position + 1] = tempNewNode;

            for (int j = newNode.height - 1; j >= position; j--)
            {
                newNode.keys[j + 1] = newNode.keys[j];
            }

            newNode.keys[position] = tempRootNode.keys[degree - 1];
            newNode.height = newNode.height + 1;
        }

        //Insert the Node
        private void InsertTheNode(BTreeNode node, int key)
        {
            if (node.leafs)
            {
                int i = 0;
                for (i = node.height - 1; i >= 0 && key < node.keys[i]; i--)
                    node.keys[i + 1] = node.keys[i];

                node.keys[i + 1] = key;
                node.height = node.height + 1;
            }

            else
            {
                int i = 0;

                for (i = node.height - 1; i >= 0 && key < node.keys[i]; i--) { }

                i += 1;

                BTreeNode tempChildNode = node.child[i];

                if (tempChildNode.height == (2 * degree - 1))
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
            for (int i = 0; i < rootNode.height; i++)
                Console.Write(rootNode.keys[i] + " ");

            if (!rootNode.leafs)
                for (int i = 0; i < rootNode.height + 1; i++)
                    DisplayNode(rootNode.child[i]);
        }

        //Search the key
        private BTreeNode Search(BTreeNode root, int key)
        {
            int i = 0;
            if (root == null)
                return root;
            for (i = 0; i < root.height; i++)
            {
                if (key < root.keys[i])
                {
                    break;
                }
                if (key == root.keys[i])
                {
                    return root;
                }
            }
            if (root.leafs)
            {
                return null;
            }
            else
            {
                return Search(root.child[i], key);
            }
        }

        private void RemoveKeys(int key)
        {
            BTreeNode foundNode = Search(this.rootNode, key);
            if (foundNode == null)
                return;

        }


        //private void RemoveKeys(BTreeNode rootNode, int key)
        //{
        //    int position = rootNode.FindKey(key);

        //    if (position != -1)
        //    {
        //        if (rootNode.leafs)
        //        {
        //            int i = 0;
        //            for (i = 0; i < rootNode.height && rootNode.keys[i] != key; i++) { }

        //            for (; i < rootNode.height; i++)
        //            {
        //                if (i != (2 * degree - 1))
        //                {
        //                    rootNode.keys[i] = rootNode.keys[i + 1];
        //                }
        //            }

        //            rootNode.height--;
        //            return;
        //        }

        //        if (!rootNode.leafs)
        //        {
        //            BTreeNode preNode = rootNode.child[position];
        //            int preNodeKey = 0;
        //            if (preNode.height >= degree)
        //            {
        //                for (; ; )
        //                {
        //                    if (preNode.leafs)
        //                    {
        //                        Console.WriteLine(preNode.height);
        //                        preNodeKey = preNode.keys[preNode.height - 1];
        //                        break;
        //                    }
        //                    else
        //                        preNode = preNode.child[preNode.height];
        //                }

        //                RemoveKeys(preNode, preNodeKey);
        //                rootNode.keys[position] = preNodeKey;
        //                return;
        //            }
        //        }
        //    }
        //}

        public void BTreeOperation_1()
        {
            BTree b = new BTree(2);
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
