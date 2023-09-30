namespace Shared.DataStructures.Graph
{
    public class AdjacentLists : IAdjacentLists
    {
        private readonly bool directed;
        private readonly Dictionary<int, HashSet<int>> adjacentLists;

        public AdjacentLists() : this(null)
        {
        }

        public AdjacentLists(int[][] edges, bool directed = false)
        {
            this.directed = directed;

            this.adjacentLists = new Dictionary<int, HashSet<int>>();
            foreach (var edge in edges)
            {
                this.AddAdjacent(edge[0], edge[1]);
            }
        }

        public void AddAdjacent(int vertex1, int vertex2)
        {
            this.AddDirectedAdjacent(vertex1, vertex2);

            if (!this.directed)
            {
                this.AddDirectedAdjacent(vertex2, vertex1);
            }
        }

        public IEnumerable<int> GetAdjacentVertexes(int vertex)
        {
            if (this.adjacentLists.ContainsKey(vertex))
            {
                return this.adjacentLists[vertex];
            }

            return Enumerable.Empty<int>();
        }

        private void AddDirectedAdjacent(int vertex1, int vertex2)
        {
            if (!this.adjacentLists.ContainsKey(vertex1))
            {
                this.adjacentLists[vertex1] = new HashSet<int>();
            }

            this.adjacentLists[vertex1].Add(vertex2);
        }
    }
}
