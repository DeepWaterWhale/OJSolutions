namespace Shared.DataStructures.SegmentTree
{
    using System;

    public class ReadOnlySegmentTree<TElement, TQueryResult>
    {
        private readonly IList<TElement> elements;
        private readonly Func<TElement, TQueryResult> calFunc;
        private readonly Func<TQueryResult, TQueryResult, TQueryResult> mergeFunc;

        /// <summary>
        /// segments[0] is not used so that we can easily get its children
        /// 
        /// Assume segments[i] = query(l, r) is the QueryResult for the elements[l - 1: r - 1]
        /// --> segments[i * 2] = query(l, (l + r) / 2)
        /// --> segments[i * 2 + 1] = query((l + r) / 2 + 1, r)
        /// are the children of segments[i]
        /// 
        /// query(i, i) = calFunc(elements[i - 1]) is the leaf of segment tree.
        /// </summary>
        private readonly TQueryResult[] segments;

        public ReadOnlySegmentTree(
            IList<TElement> elements,
            Func<TElement, TQueryResult> calFunc,
            Func<TQueryResult, TQueryResult, TQueryResult> mergeFunc)
        {
            this.elements = elements;
            this.calFunc = calFunc;
            this.mergeFunc = mergeFunc;
            this.segments = new TQueryResult[(elements.Count * 2) + 1];

            // Root node is 1 for segment tree
            this.BuildSegmentTree(1, 1, elements.Count);
        }

        public TQueryResult Query(int left, int right)
        {
            return this.Query(1, 1, this.elements.Count, left + 1, right + 1);
        }

        private TQueryResult Query(int sgNodeIndex, int sgNodeLeft, int sgNodeRight, int left, int right)
        {
            if (left <= sgNodeLeft && sgNodeRight <= right)
            {
                return this.segments[sgNodeIndex];
            }

            int middle = (sgNodeLeft + sgNodeRight) / 2;

            if (middle >= right)
            {
                // Query left child
                return this.Query(sgNodeIndex * 2, sgNodeLeft, middle, left, right);
            }
            else if (middle < left)
            {
                // Query right child
                return this.Query((sgNodeIndex * 2) + 1, middle + 1, sgNodeRight, left, right);
            }
            else
            {
                return this.mergeFunc(
                    this.Query(sgNodeIndex * 2, sgNodeLeft, middle, left, middle),
                    this.Query((sgNodeIndex * 2) + 1, middle + 1, sgNodeRight, middle + 1, right));
            }
        }

        private void BuildSegmentTree(int sgNodeIndex, int left, int right)
        {
            if (left == right)
            {
                this.segments[sgNodeIndex] = this.calFunc(this.elements[left - 1]);
                return;
            }

            this.BuildSegmentTree(sgNodeIndex * 2, left, (left + right) / 2);
            this.BuildSegmentTree((sgNodeIndex * 2) + 1, ((left + right) / 2) + 1, right);
            this.segments[sgNodeIndex] = this.mergeFunc(this.segments[sgNodeIndex * 2], this.segments[(sgNodeIndex * 2) + 1]);
        }
    }
}
