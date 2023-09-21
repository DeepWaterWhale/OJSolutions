namespace Shared.DataStructures
{
    using System;
    using System.Collections.Generic;

    public interface IDisjointSetUnion
    {
        void MakeSet(int x);

        void UnionSets(int x, int y);

        IEnumerable<int> FindSet(int x);

        IEnumerable<IEnumerable<int>> GetSets();
    }

    public class DisjointSetUnion : IDisjointSetUnion
    {
        private readonly Dictionary<int, int> parent = new Dictionary<int, int>();
        private readonly Dictionary<int, HashSet<int>> sets = new Dictionary<int, HashSet<int>>();

        public DisjointSetUnion(IEnumerable<int> nums = null)
        {
            if (nums != null)
            {
                foreach (int x in nums)
                {
                    this.MakeSet(x);
                }
            }
        }

        public IEnumerable<int> FindSet(int x)
        {
            if (this.TryFindRoot(x, out int root))
            {
                return this.sets[root];
            }

            return null;
        }

        public void MakeSet(int num)
        {
            if (!this.parent.ContainsKey(num))
            {
                this.parent[num] = num;
                this.sets[num] = new HashSet<int> { num };
            }
        }

        public void UnionSets(int x, int y)
        {
            int rx, ry;
            if (!this.TryFindRoot(x, out rx) || !this.TryFindRoot(y, out ry))
            {
                throw new InvalidOperationException("x, y must exist in the set");
            }

            this.parent[ry] = rx;
            this.sets[rx].UnionWith(this.sets[ry]);
            foreach (int i in this.sets[rx])
            {
                if (i != rx)
                {
                    this.sets.Remove(i);
                }
            }
        }

        public IEnumerable<IEnumerable<int>> GetSets()
        {
            return this.sets.Values;
        }

        private bool TryFindRoot(int x, out int root)
        {
            root = x;
            if (!this.parent.ContainsKey(x))
            {
                return false;
            }

            while (this.parent[root] != root)
            {
                root = this.parent[root];
            }

            while (this.parent[x] != root)
            {
                int next = this.parent[x];
                this.parent[x] = root;
                x = next;
            }

            return true;
        }
    }
}
