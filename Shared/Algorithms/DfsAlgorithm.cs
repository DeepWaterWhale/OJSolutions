namespace Shared.Algorithms
{
    using Shared.DataStructures.Tree;

    public class DfsAlgorithm
    {
        public static void Traverse(
            ITreeNode node,
            Action<ITreeNode, ITreeNode> whenVisitFromParent = null,
            Action<ITreeNode, ITreeNode> whenVisitFromChild = null)
        {
            Traverse(null, node, whenVisitFromParent, whenVisitFromChild);
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
