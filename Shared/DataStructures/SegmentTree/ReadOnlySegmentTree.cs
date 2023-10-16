namespace Shared.DataStructures.SegmentTree
{
    using System;

    public class ReadOnlySegmentTree<TElement, TQueryResult>
    {
        private readonly IList<TElement> elements;
        private readonly Func<TElement, TQueryResult> calFunc;
        private readonly Func<TQueryResult, TQueryResult, TQueryResult> mergeFunc;
        private readonly Node root;

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

        private TQueryResult Query(Node now, int left, int right)
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

        private Node BuildSegmentTree(int left, int right)
        {
            if (left == right)
            {
                return new Node(this.calFunc(this.elements[left]), left, right);
            }

            int middle = (left + right) / 2;
            var lc = this.BuildSegmentTree(left, middle);
            var rc = this.BuildSegmentTree(middle + 1, right);
            return new Node(this.mergeFunc(lc.Result, rc.Result), left, right, lc, rc);
        }

        private class Node
        {
            public int Left { get; set; }
            public Node LeftChild { get; set; }

            public int Right { get; set; }
            public Node RightChild { get; set; }

            public TQueryResult Result { get; set; }

            public Node(
                TQueryResult result,
                int left,
                int right,
                Node leftChlid = null,
                Node rightChild = null)
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
