namespace LeetCode.TODOs.WC360
{
    internal class Problem2836
    {
        public class Solution
        {
            public long GetMaxFunctionValue(IList<int> receiver, long k)
            {
                // The pass can make a directed graph
                // Each receiver is a node in it, and either it is in a circle
                // Or in a path starting with a receiver who no one passes to it and ends with some circle
                return 0;
            }

            private class PassPath
            {
                private readonly int start_receiver;

                private readonly int circle_entry_receiver;

                /// <summary>
                /// Assume we starting from some ghost, path[0] = (start_receiver, start_receiver)
                /// path[last] is the receiver passing the ball to a circle
                /// </summary>
                private readonly List<(int Receiver, long Value)> path;

                private readonly Circle circle;

                /// Return the MaxValue is the ball starts with someone on the path.
                public long GetMaxValue(long k)
                {
                    long ans = 0;
                    int start = 0;
                    if (k < this.path.Count)
                    {
                        // The ball ends in the path, from path[0] to path[k + 1]
                        int end = (int)k;
                        while (end < this.path.Count)
                        {
                            ans = Math.Max(ans, this.path[end].Value - this.path[start].Value + this.path[start].Receiver);
                            start++;
                            end++;
                        }
                    }

                    // The ball ends in the circle
                    while (start < this.path.Count)
                    {
                        ans = Math.Max(ans,
                            this.path.Last().Value - this.path[start].Value // The value in the path
                            + this.circle.GetMaxValue(this.circle_entry_receiver));
                    }

                    return ans;
                }
            }

            private class Circle
            {
                private readonly long totalValuePerCircle;

                private readonly List<(int Receiver, long Value)> path;

                private readonly Dictionary<int, int> receiver_index;

                /// Return the MaxValue when the ball starts with someone on the circle.
                public long GetMaxValue(long k)
                {
                    if (k % this.path.Count == 0)
                    {
                        return k / this.path.Count * this.totalValuePerCircle;
                    }

                    k %= this.path.Count;
                    long ans = 0;
                    for (int i = 0; i < this.path.Count; ++i)
                    {
                        ans = Math.Max(ans, this.GetValue(k, i));
                    }

                    return ans + (k / this.path.Count * this.totalValuePerCircle);
                }

                /// Return the value when ball with k passes
                internal long GetValue(long k, int start_receiver)
                {
                    var start_index = this.receiver_index[start_receiver];

                    int end = this.GetIndex(start_index, k);
                    if (start_index <= end)
                    {
                        return this.path[end].Value - this.path[start_index].Value + this.path[start_index].Receiver;
                    }

                    int last = this.path.Count - 1;
                    // Value(start -> last -> 0 -> end) = Value(start -> last) + Value(0 -> end)
                    return this.GetValue(last - start_index, start_index) + this.GetValue(end, 0);
                }

                private int GetIndex(int now, long steps)
                {
                    return (int)((now + steps) % this.path.Count);
                }
            }
        }
    }
}
