using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_And_Algorithm.Datastructure.tree
{
    //public class BTreeNode
    //{
    //    //public int n { get; set; }
    //    //public int[] key { get; set; }
    //    //public BTreeNode[] childNode { get; set; }
    //    //public bool leaf { get; set; }

    //    //public BTreeNode(int T)
    //    //{
    //    //    key = new int[2 * T - 1];
    //    //    childNode = new BTreeNode[2 * T];
    //    //    leaf = true;
    //    //}

    //    //public int FindElement(int number)
    //    //{
    //    //    for (int i = 0; i < this.n; i++)
    //    //        if (this.key[i] == number)
    //    //            return i;
    //    //    return -1;
    //    //}

    //    public List<int> keys { get; set; }
    //    public List<BTreeNode> childrenNode { get; set; }

    //    public bool isLeafs
    //    {
    //        get
    //        {
    //            return childrenNode.Count == 0;
    //        }
    //    }

    //    public BTreeNode()
    //    {
    //        keys = new List<int>();
    //        childrenNode = new List<BTreeNode>();
    //    }


    //}
    //public class BTree_1
    //{
    //    private int degree;
    //    private BTreeNode rootNode;

    //    public BTree_1(int degree)
    //    {
    //        rootNode = new BTreeNode();
    //        this.degree = degree;
    //    }

    //    public void InsertKey(int key)
    //    {
    //        BTreeNode root = rootNode;

    //        if (root.keys.Count() == (2 * degree) - 1)
    //        {
    //            BTreeNode newRoot = new BTreeNode();
    //            newRoot.childrenNode.Add(root);
    //            rootNode = newRoot;
    //            SplitChild(newRoot, 0);
    //            InsertNonFull(newRoot, key);
    //        }
    //        else
    //            InsertNonFull(root, key);

    //    }

    //    public void SplitChild(BTreeNode parentNode,int childIndex)
    //    {
    //        BTreeNode childNode = parentNode.childrenNode[childIndex];

    //        BTreeNode newChildNode = new BTreeNode();

    //        parentNode.keys.Insert(childIndex, childNode.keys[degree - 1]); 

    //        parentNode.childrenNode.Insert(childIndex+1, newChildNode);

    //        newChildNode.keys.AddRange(childNode.keys.GetRange(degree, degree - 1));

    //        childNode.keys.RemoveRange(degree - 1, degree);

    //        if (!childNode.isLeafs)
    //        {
    //            newChildNode.childrenNode.AddRange(childNode.childrenNode.GetRange(degree, degree));
    //            childNode.childrenNode.RemoveRange(degree, degree);
    //        }

    //    }


    //    private void InsertNonFull(BTreeNode node, int key)
    //    {
    //        int i = node.keys.Count - 1;
    //        if (node.isLeafs)
    //        {
    //            node.keys.Add(default(int)); // Add a placeholder
    //            while (i >= 0 && key.CompareTo(node.keys[i]) < 0)
    //            {
    //                node.keys[i + 1] = node.keys[i];
    //                i--;
    //            }
    //            node.keys[i + 1] = key;
    //        }
    //        else
    //        {
    //            while (i >= 0 && key.CompareTo(node.keys[i]) < 0)
    //                i--;

    //            i++;

    //            if (node.childrenNode[i].keys.Count == (2 * degree) - 1)
    //            {
    //                SplitChild(node, i);

    //                if (key.CompareTo(node.keys[i]) > 0)
    //                    i++;
    //            }

    //            InsertNonFull(node.childrenNode[i], key);
    //        }
    //    }

    //    public void Traverse()
    //    {
    //        Traverse(rootNode);
    //    }

    //    private void Traverse(BTreeNode node)
    //    {
    //        if (node != null)
    //        {
    //            for (int i = 0; i < node.keys.Count(); i++)
    //            {
    //                Traverse(node.childrenNode[i]);
    //                Console.Write(node.keys[i] + " ");
    //            }
    //            Traverse(node.childrenNode.Last());
    //        }
    //    }

    //    //public void InitializeTheTree(int T)
    //    //{
    //    //    this.T = T;
    //    //    root = new BTreeNode(this.T);
    //    //    root.n = 0;
    //    //    root.leaf = true;
    //    //}

    //    //public void InsertKey(int key)
    //    //{
    //    //    BTreeNode root = this.root;
    //    //    if (root.n == 2 * T - 1)
    //    //    {
    //    //        BTreeNode newNode = new BTreeNode(this.T);
    //    //        this.root = newNode;
    //    //        newNode.leaf = false;
    //    //        newNode.n = 0;
    //    //        newNode.childNode[0] = root;
    //    //        SplitNode(newNode, 0, root);
    //    //        InsertNode(newNode, key);
    //    //    }
    //    //    else
    //    //        InsertNode(root, key);
    //    //}

    //    //public void InsertNode(BTreeNode newNode, int keyValue)
    //    //{
    //    //    if (newNode.leaf)
    //    //    {
    //    //        int i = 0;

    //    //        for (i = newNode.n - 1; i >= 0 && keyValue < newNode.key[i]; i--)
    //    //            newNode.key[i + 1] = newNode.key[i];

    //    //        newNode.key[i + 1] = keyValue;
    //    //        newNode.n = newNode.n + 1;
    //    //    }
    //    //    else
    //    //    {

    //    //        int i = 0;

    //    //        for (i = newNode.n - 1; i >= 0 && keyValue < newNode.key[i]; i--) { }

    //    //        i++;

    //    //        BTreeNode tempNode = newNode.childNode[i];
    //    //        if (tempNode.n == 2 * this.T - 1)
    //    //        {
    //    //            SplitNode(newNode, i, tempNode);
    //    //            if (keyValue > newNode.key[i])
    //    //                i++;
    //    //        }
    //    //        InsertNode(newNode.childNode[i], keyValue);
    //    //    }
    //    //}

    //    //public void SplitNode(BTreeNode newNode, int position, BTreeNode rootNode)
    //    //{
    //    //    BTreeNode tempNewNode = new BTreeNode(this.T);
    //    //    tempNewNode.leaf = rootNode.leaf;
    //    //    tempNewNode.n = this.T - 1;

    //    //    for (int i = 0; i < this.T - 1; i++)
    //    //        tempNewNode.key[i] = rootNode.key[i + this.T];

    //    //    if (!rootNode.leaf)
    //    //    {
    //    //        for (int i = 0; i < this.T; i++)
    //    //            tempNewNode.childNode[i] = rootNode.childNode[i + this.T];
    //    //    }

    //    //    rootNode.n = this.T - 1;

    //    //    for (int i = newNode.n; i >= position + 1; i--)
    //    //        newNode.childNode[i + 1] = newNode.childNode[i];

    //    //    newNode.childNode[position + 1] = tempNewNode;

    //    //    for (int i = newNode.n - 1; i >= position; i--)
    //    //        newNode.key[i + 1] = newNode.key[i];

    //    //    newNode.key[position] = rootNode.key[this.T - 1];
    //    //    newNode.n = newNode.n + 1;
    //    //}

    //    //private void DisplayNode()
    //    //{
    //    //    DisplayNode(this.root);
    //    //}

    //    //private void DisplayNode(BTreeNode rootNode)
    //    //{
    //    //    for (int i = 0; i < rootNode.n; i++)
    //    //        Console.Write(rootNode.key[i] + " ");

    //    //    if (!rootNode.leaf)
    //    //        for (int i = 0; i < rootNode.n + 1; i++)
    //    //            DisplayNode(rootNode.childNode[i]);
    //    //}

    //    public void BTreeOperation_1()
    //    {
    //        BTree_1 b = new BTree_1(3);
    //        //b.InitializeTheTree(3);
    //        b.InsertKey(8);
    //        b.InsertKey(9);
    //        b.InsertKey(10);
    //        b.InsertKey(11);
    //        b.InsertKey(15);
    //        b.InsertKey(20);
    //        b.InsertKey(17);
    //        b.Traverse();
    //    }
    //}
}
