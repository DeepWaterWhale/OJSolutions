namespace OjProblems.LeetCode
{
    using System.Collections.Generic;
    using LeetCodeUtils;

    internal class Problem0105
    {
        public class Solution
        {
            private int[] preOrder;
            private Dictionary<int, int> inOrderIndex;
            public TreeNode BuildTree(int[] preorder, int[] inorder)
            {
                this.preOrder = preorder;
                this.inOrderIndex = new Dictionary<int, int>();
                for (int i = 0; i < inorder.Length; ++i)
                {
                    this.inOrderIndex[inorder[i]] = i;
                }

                return this.BuildTree(0, preorder.Length, 0, preorder.Length);
            }

            private TreeNode BuildTree(int s1, int e1, int s2, int e2)
            {
                if (s1 >= e1 || s1 >= this.preOrder.Length)
                {
                    return null;
                }

                int rootVal = this.preOrder[s1];
                TreeNode root = new TreeNode(rootVal);
                int leftCnt = this.inOrderIndex[rootVal] - s2;

                root.left = this.BuildTree(s1 + 1, s1 + leftCnt + 1, s2, s2 + leftCnt);
                root.right = this.BuildTree(s1 + leftCnt + 1, e1, s2 + leftCnt + 1, e2);
                return root;
            }
        }
    }
}
