namespace Shared.DataStructures.Graph.Extensions
{
    public static class AdjacentListsDfsExtension
    {
        /// <summary>
        /// DFS on the adjacent lists
        /// </summary>
        /// <param name="adjLists">The adjacent lists</param>
        /// <param name="start">The entry point</param>
        /// <param name="whenFirstVisit">Action(previous, now)</param>
        /// <param name="whenBackFromNext">Action(now, next)</param>
        public static void DfsTraverse(
            this IAdjacentLists adjLists,
            int start,
            Action<int, int> whenFirstVisit,
            Action<int, int> whenBackFromNext)
        {
            HashSet<int> visited = new HashSet<int>();
            DfsTraverse(visited, adjLists, -1, start, whenFirstVisit, whenBackFromNext);
        }

        public static void DfsTraverse(
            HashSet<int> visited,
            IAdjacentLists adjLists,
            int previous,
            int now,
            Action<int, int> whenFirstVisit,
            Action<int, int> whenBackFromNext)
        {
            visited.Add(now);
            if (whenFirstVisit != null)
            {
                whenFirstVisit(previous, now);
            }

            foreach (var next in adjLists.GetAdjacentVertexes(now))
            {
                if (!visited.Contains(next))
                {
                    DfsTraverse(visited, adjLists, now, next, whenFirstVisit, whenBackFromNext);

                    if (whenBackFromNext != null)
                    {
                        whenBackFromNext(now, next);
                    }
                }
            }
        }
    }
}
