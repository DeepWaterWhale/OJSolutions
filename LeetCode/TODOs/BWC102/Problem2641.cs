namespace LeetCode.TODOs.BWC102
{
    using System.Collections.Generic;

    internal class Problem2641
    {
        public class Solution
        {
            private readonly Dictionary<int, int> levelSum = new Dictionary<int, int>();
            private readonly Dictionary<TreeNode, int> childrenSum = new Dictionary<TreeNode, int>();

            public TreeNode ReplaceValueInTree(TreeNode root)
            {
                this.Visit(root, 0);
                this.Update(root, 0);
                return root;
            }

            private void Visit(TreeNode node, int level)
            {
                if (!this.levelSum.ContainsKey(level))
                {
                    this.levelSum[level] = 0;
                }

                if (!this.childrenSum.ContainsKey(node))
                {
                    this.childrenSum[node] = 0;
                }

                this.levelSum[level] += node.val;

                if (node.left != null)
                {
                    this.Visit(node.left, level + 1);
                    this.childrenSum[node] += node.left.val;
                }

                if (node.right != null)
                {
                    this.Visit(node.right, level + 1);
                    this.childrenSum[node] += node.right.val;
                }
            }

            private void Update(TreeNode node, int level)
            {
                if (node == null)
                {
                    return;
                }

                if (level == 0)
                {
                    node.val = 0;
                }

                if (node.left != null)
                {
                    node.left.val = this.levelSum[level + 1] - this.childrenSum[node];
                }

                if (node.right != null)
                {
                    node.right.val = this.levelSum[level + 1] - this.childrenSum[node];
                }

                this.Update(node.left, level + 1);
                this.Update(node.right, level + 1);
            }
        }
    }
}
