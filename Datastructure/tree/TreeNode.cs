using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_And_Algorithm.Datastructure.tree
{
    public class TreeNode
    {
        public int itemValue { get; set; }
        public TreeNode leftNode { get; set; }
        public TreeNode rightNode { get; set; }
        public TreeNode(int item)
        {
            itemValue = item;
            leftNode = rightNode = null;
        }
    }
}
