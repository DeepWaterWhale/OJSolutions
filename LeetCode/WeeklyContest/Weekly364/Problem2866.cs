namespace LeetCode.WeeklyContest.Weekly364
{
    internal class Problem2866
    {
        public class Solution
        {
            // right_sum[i] = the max height sum of the right part when i is the Peak (including i)
            // Use the Monotonic Stack to get left_sum / right_sum in linear time 
            public long MaximumSumOfHeights(IList<int> maxHeights)
            {
                // Assume left_sum[i] == the max height sum of the left part when i is the Peak (including i)
                long[] leftSums = new long[maxHeights.Count];

                // A stack of indexes which maintains the left part of the mountain
                // consider the stack is {i0, i1, ..., ik } (From bottom to top)
                // Then the left part is 
                // tmpSum = maxHeights[i0] * (i0 + 1) + maxHeights[i1] * (i1 - i0) + ...
                Stack<int> stack = new Stack<int>();

                long tmpSum = 0;
                for (int i = 0; i < maxHeights.Count; i++)
                {
                    while (stack.Count > 0 && maxHeights[stack.Peek()] >= maxHeights[i])
                    {
                        int p = stack.Peek();
                        stack.Pop();

                        int pp = stack.Count > 0 ? stack.Peek() : -1;
                        // Need to convert to long or you may get overflow
                        tmpSum -= Math.Abs((long)p - pp) * maxHeights[p];
                    }

                    int tmp = stack.Count > 0 ? stack.Peek() : -1;
                    tmpSum += maxHeights[i] * Math.Abs((long)i - tmp);
                    stack.Push(i);
                    leftSums[i] = tmpSum;
                }

                stack.Clear();
                tmpSum = 0;

                long[] rightSum = new long[maxHeights.Count];
                for (int i = maxHeights.Count - 1; i >= 0; i--)
                {
                    while (stack.Count > 0 && maxHeights[stack.Peek()] >= maxHeights[i])
                    {
                        int p = stack.Peek();
                        stack.Pop();

                        int pp = stack.Count > 0 ? stack.Peek() : maxHeights.Count;
                        tmpSum -= Math.Abs((long)p - pp) * maxHeights[p];
                    }

                    int tmp = stack.Count > 0 ? stack.Peek() : maxHeights.Count;
                    tmpSum += maxHeights[i] * Math.Abs((long)i - tmp);
                    stack.Push(i);
                    rightSum[i] = tmpSum;
                }

                tmpSum = 0;
                for (int i = 0; i < maxHeights.Count; i++)
                {
                    tmpSum = Math.Max(tmpSum, leftSums[i] + rightSum[i] - maxHeights[i]);
                }

                return tmpSum;
            }
        }
    }
}
