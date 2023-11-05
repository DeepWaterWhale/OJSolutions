namespace LeetCode.TODOs.RamdomPick
{
    using System.Collections.Generic;
    using LeetCode;

    internal class Problem0105
    {
        public class Solution
        {
            private int[] preOrder;
            private Dictionary<int, int> inOrderIndex;
            public TreeNode BuildTree(int[] preorder, int[] inorder)
            {
                preOrder = preorder;
                inOrderIndex = new Dictionary<int, int>();
                for (int i = 0; i < inorder.Length; ++i)
                {
                    inOrderIndex[inorder[i]] = i;
                }

                return BuildTree(0, preorder.Length, 0, preorder.Length);
            }

            private TreeNode BuildTree(int s1, int e1, int s2, int e2)
            {
                if (s1 >= e1 || s1 >= preOrder.Length)
                {
                    return null;
                }

                int rootVal = preOrder[s1];
                TreeNode root = new TreeNode(rootVal);
                int leftCnt = inOrderIndex[rootVal] - s2;

                root.left = BuildTree(s1 + 1, s1 + leftCnt + 1, s2, s2 + leftCnt);
                root.right = BuildTree(s1 + leftCnt + 1, e1, s2 + leftCnt + 1, e2);
                return root;
            }
        }
    }
}
