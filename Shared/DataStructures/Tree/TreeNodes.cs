namespace Shared.DataStructures.Tree
{
    public class SimpleTreeNode : ITreeNode 
    {
        protected List<ITreeNode> Children { get; set; }

        public int Value { get; private set; }

        public SimpleTreeNode(int val)
        {
            this.Value = val;
            this.Children = new List<ITreeNode>();
        }

        public void AddChild(SimpleTreeNode child)
        {
            this.Children.Add(child);
        }

        public IEnumerable<ITreeNode> GetChildren()
        {
            return this.Children;
        }
    }

    public class WeightedTreeNode : SimpleTreeNode
    {
        public int Weight { get; set; }

        public WeightedTreeNode(int val) : base(val)
        {
        }

        public void AddChild(WeightedTreeNode child, int pathWeight)
        {
            this.Children.Add(child);
            child.Weight = pathWeight;
        }
    }
}
