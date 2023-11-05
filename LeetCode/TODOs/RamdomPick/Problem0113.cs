﻿namespace LeetCode.TODOs.RamdomPick
{
    using System.Collections.Generic;
    using System.Linq;

    internal class Problem0113
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public class Solution
        {
            public IList<IList<int>> PathSum(TreeNode root, int targetSum)
            {
                if (root == null)
                {
                    return new List<IList<int>>();
                }

                if (root.left == null && root.right == null && root.val == targetSum)
                {
                    return new List<IList<int>>()
                    {
                        new List<int>() { targetSum }
                    };
                }

                List<IList<int>> left = PathSum(root.left, targetSum - root.val).ToList();
                left.AddRange(PathSum(root.right, targetSum - root.val));

                List<IList<int>> ans = new List<IList<int>>();
                foreach (IList<int> list in left)
                {
                    List<int> tmp = new List<int> { root.val };
                    tmp.AddRange(list);
                    ans.Add(tmp);
                }

                return ans;
            }
        }
    }
}
