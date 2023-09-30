namespace Shared.DataStructures.Tree.Extensions
{
    using Shared.DataStructures.Tree;

    public static class TreeDfsExtension
    {
        /// <summary>
        /// DFS Traverse
        /// </summary>
        /// <param name="root">Root node</param>
        /// <param name="whenVisitFromParent">action(parent, now)</param>
        /// <param name="whenVisitFromChild">action(now, child)</param>
        public static void DfsTraverse(
            this ITreeNode root,
            Action<ITreeNode, ITreeNode> whenVisitFromParent,
            Action<ITreeNode, ITreeNode> whenVisitFromChild)
        {
            Traverse(null, root, whenVisitFromParent, whenVisitFromChild);
        }

        private static void Traverse(
            ITreeNode parent,
            ITreeNode current,
            Action<ITreeNode, ITreeNode> whenVisitFromParent = null,
            Action<ITreeNode, ITreeNode> whenVisitFromChild = null)
        {
            if (current == null)
            {
                return;
            }

            if (whenVisitFromParent != null)
            {
                whenVisitFromParent(parent, current);
            }

            foreach (var child in current.GetChildren())
            {
                Traverse(current, child, whenVisitFromParent, whenVisitFromChild);
                if (whenVisitFromChild != null)
                {
                    whenVisitFromChild(current, child);
                }
            }
        }
    }
}
