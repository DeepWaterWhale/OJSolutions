namespace OjProblems.LeetCode
{
    internal class Problem1883
    {
        public class Solution
        {
            private static readonly double eps = .00000000000003;
            private double[] times;
            private double[,] dp;
            public int MinSkips(int[] dists, int speed, int hoursBefore)
            {
                this.times = dists.Select(d => d * 1.0 / speed).ToArray();
                this.dp = new double[dists.Length + 1, dists.Length + 1];
                int ans = 0;
                while (this.Solve(dists.Length - 1, ans) > hoursBefore && ans < dists.Length)
                {
                    if (this.Solve(dists.Length - 1, ans) - hoursBefore <= eps)
                    {
                        return ans;
                    }

                    ans++;
                }

                if (ans == dists.Length)
                {
                    return -1;
                }

                return ans;
            }

            // dp[i, j] = minimal hours needed to reach the i-th destination road with j skipping
            // we need to find minimal j let dp[dist.Length - 1, j] <= hoursBefore
            // 
            // dp[0, x] = times[0]
            // dp[x, 0] = sum(times[0:x])
            //
            // To calculate dp[i, j] When j > 0, consider the last dest to take last skip
            //     - Skip at i - 1, => dp[i, j] = dp[i - 1, j - 1] + times[i]
            //     - Skip before i - 1, => dp[i, j] = cell(dp[i - 1, j]) + times[i]
            // )
            private double Solve(int end, int skipCount)
            {
                if (this.dp[end, skipCount] != 0)
                {
                    return this.dp[end, skipCount];
                }

                if (end == 0)
                {
                    //Console.WriteLine($"end = {end}, skipCount = {skipCount}, time = {this.dp[end, skipCount]}");
                    this.dp[end, skipCount] = this.times[end];
                    return this.dp[end, skipCount];
                }

                if (skipCount == 0)
                {
                    double ans = 0;
                    for (int i = 0; i < end; ++i)
                    {
                        ans += Math.Ceiling(this.times[i]);
                    }

                    this.dp[end, skipCount] = ans + this.times[end];
                    //Console.WriteLine($"end = {end}, skipCount = {skipCount}, time = {this.dp[end, skipCount]}");
                    return this.dp[end, skipCount];
                }

                this.dp[end, skipCount] = Math.Min(
                    Math.Ceiling(this.Solve(end - 1, skipCount)) + this.times[end],
                    this.Solve(end - 1, skipCount - 1) + this.times[end]);

                //Console.WriteLine($"end = {end}, skipCount = {skipCount}, time = {this.dp[end, skipCount]}");
                return this.dp[end, skipCount];
            }
        }
    }
}
