namespace LeetCode.TODOs.RamdomPick
{
    using System;
    internal class Problem0732
    {
        public class MyCalendarThree
        {

            private readonly LazySegmentTree lst;
            public MyCalendarThree()
            {
                lst = new LazySegmentTree(0, 1000000001);
            }

            public int Book(int start, int end)
            {
                lst.Update(start, end);
                return lst.Query(0, 1000000001);
            }

            public class LazySegmentTree
            {
                private readonly int _left;
                private readonly int _right;
                public LazySegmentTree(int left, int right)
                {
                    _left = left;
                    _right = right;
                    Root = new Node(left, right);
                }

                internal Node Root { get; private set; }

                public int Query(int left, int right)
                {
                    return Query(Root, left, right);
                }

                public void Update(int left, int right)
                {
                    Update(Root, left, right);
                }

                private int Query(Node node, int left, int right)
                {
                    if (node == null || right <= node.Left || node.Right <= left)
                    {
                        return 0;
                    }

                    if (left <= node.Left && node.Right <= right)
                    {
                        return node.Value + node.Lazy;
                    }

                    PushLazyDown(node);
                    return Math.Max(Query(node.LeftChild, left, right), Query(node.RightChild, left, right));
                }

                private void Update(Node node, int left, int right)
                {
                    if (left <= node.Left && node.Right <= right)
                    {
                        // Update whole interval
                        node.Lazy++;
                        return;
                    }

                    if (node.Right <= left || right <= node.Left)
                    {
                        // No intersection, nothing to do
                        return;
                    }

                    // Push the lazy down, will create child node if necessary
                    PushLazyDown(node);
                    if (node.Right - node.Left > 1)
                    {
                        int middle = node.GetMiddle();

                        Update(node.LeftChild, left, right);
                        Update(node.RightChild, left, right);
                        node.Value = Math.Max(Query(node.LeftChild, node.Left, middle), Query(node.RightChild, middle, node.Right));

                    }
                }

                private void PushLazyDown(Node node)
                {
                    if (node.Right - node.Left > 1)
                    {
                        // If need to create child node
                        int middle = node.GetMiddle();
                        if (node.LeftChild == null)
                        {
                            node.LeftChild = new Node(node.Left, middle);
                        }

                        if (node.RightChild == null)
                        {
                            node.RightChild = new Node(middle, node.Right);
                        }

                        node.LeftChild.Lazy += node.Lazy;
                        node.RightChild.Lazy += node.Lazy;
                    }

                    node.Value += node.Lazy;
                    node.Lazy = 0;
                }

                internal class Node
                {
                    public Node(int left, int right)
                    {
                        Left = left;
                        Right = right;
                    }

                    public int Lazy { get; set; }
                    public int Value { get; set; }
                    public int Left { get; }
                    public int Right { get; }
                    public Node LeftChild { get; set; }
                    public Node RightChild { get; set; }

                    public int GetMiddle()
                    {
                        return (Left + Right) / 2;
                    }
                }
            }
        }
    }
}
