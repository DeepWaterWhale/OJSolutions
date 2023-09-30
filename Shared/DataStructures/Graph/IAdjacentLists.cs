namespace Shared.DataStructures.Graph
{
    public interface IAdjacentLists
    {
        void AddAdjacent(int vertex1, int vertex2);

        IEnumerable<int> GetAdjacentVertexes(int vertex);
    }

    public interface IWeightedAdjacentLists : IAdjacentLists
    {
        void AddAdjacent(int vertex1, int vertex2, int weight);

        int GetWeight(int vertex1, int vertex2);
    }
}
