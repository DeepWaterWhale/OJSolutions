namespace Shared.DataStructures.Tree
{
    public interface ITreeNode
    {
        int Value { get; set; }

        IEnumerable<ITreeNode> GetChildren();
    }
}
