namespace Shared.Algorithms
{
    using Shared.DataStructures.Tree;

    public class DfsAlgorithm
    {
        /// <summary>
        /// DFS Traverse
        /// </summary>
        /// <param name="root">Root node</param>
        /// <param name="whenVisitFromParent">func(parent, now)</param>
        /// <param name="whenVisitFromChild">func(now, child)</param>
        public static void Traverse(
            ITreeNode root,
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
