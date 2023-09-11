using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_And_Algorithm.Datastructure.tree
{
    public class BTreeNode
    {
        public int n { get; set; }
        public int[] key { get; set; }
        public BTreeNode[] childNode { get; set; }
        public bool leaf { get; set; }

        public BTreeNode(int T)
        {
            key = new int[2 * T - 1];
            childNode = new BTreeNode[2 * T];
            leaf = true;
        }

        public int FindElement(int number)
        {
            for (int i = 0; i < this.n; i++)
                if (this.key[i] == number)
                    return i;
            return -1;
        }


    }
    public class BTree_1
    {
        private int T;
        private BTreeNode root;

        public BTree_1()
        {

        }

        public void InitializeTheTree(int T)
        {
            this.T = T;
            root = new BTreeNode(this.T);
            root.n = 0;
            root.leaf = true;
        }

        public void InsertKey(int key)
        {
            BTreeNode root = this.root;
            if (root.n == 2 * T - 1)
            {
                BTreeNode newNode = new BTreeNode(this.T);
                this.root = newNode;
                newNode.leaf = false;
                newNode.n = 0;
                newNode.childNode[0] = root;
                SplitNode(newNode, 0, root);
                InsertNode(newNode, key);
            }
            else
                InsertNode(root, key);
        }

        public void InsertNode(BTreeNode newNode,int keyValue)
        {
            if (newNode.leaf)
            {
                int i = 0;

                for (i = newNode.n - 1; i >= 0 && keyValue<newNode.key[i]; i--)
                    newNode.key[i + 1] = newNode.key[i];

                newNode.key[i + 1] = keyValue;
                newNode.n = newNode.n + 1;
            }
            else
            {

                int i = 0;

                for (i = newNode.n - 1; i >= 0 && keyValue < newNode.key[i]; i--) { }

                i++;

                BTreeNode tempNode = newNode.childNode[i];
                if (tempNode.n == 2 * this.T - 1)
                {
                    SplitNode(newNode, i, tempNode);
                    if (keyValue > newNode.key[i])
                        i++;
                }
                InsertNode(newNode.childNode[i], keyValue);
            }
        }

        public void SplitNode(BTreeNode newNode,int position,BTreeNode rootNode)
        {
            BTreeNode tempNewNode = new BTreeNode(this.T);
            tempNewNode.leaf = rootNode.leaf;
            tempNewNode.n = this.T - 1;

            for (int i = 0; i < this.T - 1; i++)
                tempNewNode.key[i] = rootNode.key[i + this.T];

            if (!rootNode.leaf)
            {
                for (int i = 0; i < this.T; i++)
                    tempNewNode.childNode[i] = rootNode.childNode[i + this.T];
            }

            rootNode.n = this.T - 1;

            for (int i = newNode.n; i >= position+1; i--)
                newNode.childNode[i+1] = newNode.childNode[i];

            newNode.childNode[position + 1] = tempNewNode;

            for (int i = newNode.n-1; i >= position; i--)
                newNode.key[i + 1] = newNode.key[i];

            newNode.key[position] = rootNode.key[this.T-1];
            newNode.n = newNode.n + 1;
        }

        private void DisplayNode()
        {

        }

        private void DisplayNode(BTreeNode rootNode)
        {
            for(int i=0;i<rootNode.n;i++)
                Console.Write(rootNode.key[i]+" ");

            if (!rootNode.leaf)
                for (int i = 0; i < rootNode.n + 1; i++)
                    DisplayNode(rootNode.childNode[i]);
        }

        public void BTreeOperation_1()
        {
            BTree_1 b = new BTree_1();
            b.InitializeTheTree(3);
            b.InsertKey(8);
            b.InsertKey(9);
            b.InsertKey(10);
            b.InsertKey(11);
            b.InsertKey(15);
            b.InsertKey(20);
            b.InsertKey(17);
            b.DisplayNode();
        }
    }
}
