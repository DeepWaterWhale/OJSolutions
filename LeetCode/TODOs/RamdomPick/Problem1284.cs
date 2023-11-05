namespace LeetCode.TODOs.RamdomPick
{
    using System;

    internal class Problem1284
    {
        public class Solution
        {
            private int[][] _board = null;
            private int _boardHeight = 0;
            private int _boardWidth = 0;
            private int _operationCnt = 0;
            private int _result = 10;
            public int MinFlips(int[][] mat)
            {
                _board = mat;
                _boardHeight = mat.Length;
                _boardWidth = mat[0].Length;
                _operationCnt = 0;
                BackTracing(0);

                return _result == 10 ? -1 : _result;
            }

            private void BackTracing(int index)
            {
                if (IsAllZero())
                {
                    _result = _operationCnt;
                    return;
                }

                if (index == _boardWidth * _boardHeight || _result != 10)
                {
                    return;
                }

                // Don't flip this index
                BackTracing(index + 1);
                if (_result != 10)
                {
                    return;
                }

                // Flip this index
                int i = index / _boardWidth;
                int j = index % _boardWidth;
                Flip(i, j);
                _operationCnt++;
                BackTracing(index + 1);
                _operationCnt--;
                Flip(i, j);
            }

            private void Flip(int i, int j)
            {
                FlipSingleBit(i, j);
                FlipSingleBit(i - 1, j);
                FlipSingleBit(i + 1, j);
                FlipSingleBit(i, j - 1);
                FlipSingleBit(i, j + 1);
            }

            private void FlipSingleBit(int i, int j)
            {
                if (i >= 0 && i < _boardHeight && j >= 0 && j < _boardWidth)
                {
                    _board[i][j] = Math.Abs(1 - _board[i][j]);
                }
            }

            private bool IsAllZero()
            {
                for (int i = 0; i < _boardHeight; ++i)
                {
                    for (int j = 0; j < _boardWidth; ++j)
                    {
                        if (_board[i][j] != 0)
                        {
                            return false;
                        }
                    }
                }

                return true;
            }
        }
    }
}
