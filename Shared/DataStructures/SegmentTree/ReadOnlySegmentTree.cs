namespace Shared.DataStructures.SegmentTree
{
    using System;

    public class ReadOnlySegmentTree<TElement, TQueryResult>
    {
        private readonly IList<TElement> elements;
        private readonly Func<TElement, TQueryResult> calFunc;
        private readonly Func<TQueryResult, TQueryResult, TQueryResult> mergeFunc;
        private readonly Interval root;

        public ReadOnlySegmentTree(
            IList<TElement> elements,
            Func<TElement, TQueryResult> calFunc,
            Func<TQueryResult, TQueryResult, TQueryResult> mergeFunc)
        {
            this.elements = elements;
            this.calFunc = calFunc;
            this.mergeFunc = mergeFunc;

            this.root = this.BuildSegmentTree(0, elements.Count - 1);
        }

        /// <summary>
        /// Range query on the original elements[left : right] (both including)
        /// </summary>
        public TQueryResult Query(int left, int right)
        {
            return this.Query(this.root, left, right);
        }

        private TQueryResult Query(Interval now, int left, int right)
        {
            if (left <= now.Left && now.Right <= right)
            {
                return now.Result;
            }

            int middle = (now.Left + now.Right) / 2;
            if (middle >= right)
            {
                // Query left child
                return this.Query(now.LeftChild, left, right);
            }
            else if (middle < left)
            {
                // Query right child
                return this.Query(now.RightChild, left, right);
            }
            else
            {
                return this.mergeFunc(
                    this.Query(now.LeftChild, left, right),
                    this.Query(now.RightChild, left, right));
            }
        }

        private Interval BuildSegmentTree(int left, int right)
        {
            if (left == right)
            {
                return new Interval(this.calFunc(this.elements[left]), left, right);
            }

            int middle = (left + right) / 2;
            var lc = this.BuildSegmentTree(left, middle);
            var rc = this.BuildSegmentTree(middle + 1, right);
            return new Interval(this.mergeFunc(lc.Result, rc.Result), left, right, lc, rc);
        }

        private class Interval
        {
            public int Left { get; set; }
            public Interval LeftChild { get; set; }

            public int Right { get; set; }
            public Interval RightChild { get; set; }

            public TQueryResult Result { get; set; }

            public Interval(
                TQueryResult result,
                int left,
                int right,
                Interval leftChlid = null,
                Interval rightChild = null)
            {
                this.Result = result;
                this.Left = left;
                this.Right = right;
                this.LeftChild = leftChlid;
                this.RightChild = rightChild;
            }
        }
    }
}
