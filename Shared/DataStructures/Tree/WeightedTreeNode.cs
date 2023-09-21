namespace Shared.DataStructures.Tree
{
    public class WeightedTreeNode : ITreeNode<WeightedTreeNode>, ITreeNode
    {
        public int Weight { get; set; }

        public int Value { get; private set; }

        public List<WeightedTreeNode> Children { get; private set; }

        public WeightedTreeNode(int val)
        {
            this.Value = val;
            this.Children = new List<WeightedTreeNode>();
        }

        public void AddChild(WeightedTreeNode child, int pathWeight)
        {
            this.Children.Add(child);
            child.Weight = pathWeight;
        }

        public IEnumerable<WeightedTreeNode> GetChildren()
        {
            return this.Children;
        }

        IEnumerable<ITreeNode> ITreeNode.GetChildren()
        {
            return this.Children;
        }
    }
}
