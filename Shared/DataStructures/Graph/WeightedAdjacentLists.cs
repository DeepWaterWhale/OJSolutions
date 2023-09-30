namespace Shared.DataStructures.Graph
{
    public class WeightedAdjacentLists : IWeightedAdjacentLists
    {
        private readonly bool directed;
        private readonly Dictionary<int, Dictionary<int, int>> adjacentLists;

        public WeightedAdjacentLists() : this(null)
        {
        }

        public WeightedAdjacentLists(int[][] edges, bool directed = false)
        {
            this.directed = directed;

            this.adjacentLists = new Dictionary<int, Dictionary<int, int>>();
            foreach (var edge in edges)
            {
                this.AddAdjacent(edge[0], edge[1], edge[2]);
            }
        }

        public void AddAdjacent(int vertex1, int vertex2, int weight)
        {
            this.AddDirectedAdjacent(vertex1, vertex2, weight);

            if (!this.directed)
            {
                this.AddDirectedAdjacent(vertex2, vertex1, weight);
            }
        }

        public void AddAdjacent(int vertex1, int vertex2)
        {
            this.AddDirectedAdjacent(vertex1, vertex2, 0);
        }

        public IEnumerable<int> GetAdjacentVertexes(int vertex)
        {
            if (this.adjacentLists.ContainsKey(vertex))
            {
                return this.adjacentLists[vertex].Keys;
            }

            return Enumerable.Empty<int>();
        }

        public int GetWeight(int vertex1, int vertex2)
        {
            if (this.adjacentLists.TryGetValue(vertex1, out var dict))
            {
                if (dict.TryGetValue(vertex2, out int weight))
                {
                    return weight;
                }
            }

            return -1;
        }

        private void AddDirectedAdjacent(int vertex1, int vertex2, int weight)
        {
            if (!this.adjacentLists.ContainsKey(vertex1))
            {
                this.adjacentLists[vertex1] = new Dictionary<int, int>();
            }

            this.adjacentLists[vertex1][vertex2] = weight;
        }
    }
}
