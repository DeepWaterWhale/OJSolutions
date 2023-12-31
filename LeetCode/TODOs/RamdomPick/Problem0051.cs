﻿namespace LeetCode.TODOs.RamdomPick
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class Problem0051
    {
        public class Solution
        {
            private readonly IList<IList<string>> result = new List<IList<string>>();
            private int BoardSize;
            public IList<IList<string>> SolveNQueens(int n)
            {
                BoardSize = n;
                int[] board = new int[BoardSize];

                BackTracing(0, board);

                return result;
            }

            private void BackTracing(int line, int[] board)
            {
                if (line == BoardSize)
                {
                    AddToResult(board);
                }

                for (int i = 0; i < BoardSize; ++i)
                {
                    if (IsValid(line, i, board))
                    {
                        board[line] = i;
                        BackTracing(line + 1, board);
                    }
                }
            }

            private void AddToResult(int[] position)
            {
                List<string> ans = new List<string>();
                StringBuilder sb = new StringBuilder(BoardSize);
                for (int i = 0; i < BoardSize; ++i)
                {
                    sb.Append('.');
                }

                for (int i = 0; i < BoardSize; ++i)
                {
                    sb[position[i]] = 'Q';
                    ans.Add(sb.ToString());
                    sb[position[i]] = '.';
                }

                result.Add(ans);
            }

            /// <summary>
            /// Is valid to put the queen at k-th position in k-th line
            /// </summary>
            private bool IsValid(int line, int position, int[] board)
            {
                for (int i = 0; i < line; ++i)
                {
                    if (board[i] == position || Math.Abs(board[i] - position) == Math.Abs(i - line))
                    {
                        return false;
                    }
                }

                return true;
            }
        }
    }
}
