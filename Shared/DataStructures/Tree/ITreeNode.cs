namespace Shared.DataStructures.Tree
{
    public interface ITreeNode<TNode> where TNode : ITreeNode<TNode>
    {
        int Value { get; }

        IEnumerable<TNode> GetChildren();
    }

    public interface ITreeNode
    {
        int Value { get; }

        IEnumerable<ITreeNode> GetChildren();
    }
}
