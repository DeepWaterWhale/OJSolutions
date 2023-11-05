namespace LeetCode.TODOs.RamdomPick
{
    internal class Problem0715
    {
        public class RangeModule
        {
            private readonly SegmentTreeNode Root = new SegmentTreeNode(0, 1000000000);
            public RangeModule()
            {
            }

            public void AddRange(int left, int right)
            {
                Root.AddRange(left, right);
            }

            public bool QueryRange(int left, int right)
            {
                return Root.QueryRange(left, right);
            }

            public void RemoveRange(int left, int right)
            {
                Root.RemoveRange(left, right);
            }

            private class SegmentTreeNode
            {
                // If we have 1 segment, it means some numbers exist in the interval
                private readonly int _minValue;
                private readonly int _maxValue;
                private SegmentTreeNode _leftChild;
                private SegmentTreeNode _rightChild;
                private bool _allExist;

                public SegmentTreeNode(int minValue, int maxValue)
                {
                    _minValue = minValue;
                    _maxValue = maxValue;
                    _leftChild = null;
                    _rightChild = null;
                    _allExist = false;
                }

                public void AddRange(int left, int right)
                {
                    if (left <= _minValue && _maxValue <= right)
                    {
                        _allExist = true;
                        _leftChild = null;
                        _rightChild = null;
                        return;
                    }

                    int middle = (_minValue + _maxValue) / 2;
                    if (left < middle)
                    {
                        // Add [left, middle) into left subtree
                        if (_leftChild == null)
                        {
                            _leftChild = new SegmentTreeNode(_minValue, middle);
                        }

                        _leftChild.AddRange(left, middle);
                    }

                    if (right > middle)
                    {
                        // Add [middle, right) into right subtree
                        if (_rightChild == null)
                        {
                            _rightChild = new SegmentTreeNode(middle, _maxValue);
                        }

                        _rightChild.AddRange(middle, right);
                    }
                }

                public bool QueryRange(int left, int right)
                {
                    if (_minValue <= left && _maxValue >= right && _allExist)
                    {
                        return true;
                    }

                    int middle = (_minValue + _maxValue) / 2;
                    if (left < middle)
                    {
                        // Check [left, middle) all exist in left subtree
                        if (_leftChild == null)
                        {
                            return false;
                        }

                        if (!_leftChild.QueryRange(left, middle))
                        {
                            return false;
                        }
                    }

                    if (right > middle)
                    {
                        // Check [middle, right) all exists in right subtree
                        if (_rightChild == null)
                        {
                            return false;
                        }

                        if (!_rightChild.QueryRange(middle, right))
                        {
                            return false;
                        }
                    }

                    return true;
                }

                public void RemoveRange(int left, int right)
                {
                    if (left <= _minValue && _maxValue <= right)
                    {
                        _allExist = false;
                        _leftChild = null;
                        _rightChild = null;
                        return;
                    }

                    int middle = (_minValue + _maxValue) / 2;
                    if (left < middle)
                    {
                        // Remove [left, middle) into left subtree
                        _leftChild?.RemoveRange(left, middle);
                    }

                    if (right > middle)
                    {
                        // Remove [middle, right) into right subtree
                        _rightChild?.RemoveRange(left, middle);
                    }
                }
            }
        }
    }
}
