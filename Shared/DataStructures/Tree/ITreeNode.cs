namespace Shared.DataStructures.Tree
{
    public interface ITreeNode
    {
        int Value { get; }

        IEnumerable<ITreeNode> GetChildren();
    }
}
