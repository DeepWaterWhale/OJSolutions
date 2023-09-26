namespace LeetCode.ByWeeklyContest.BWC104
{
    internal class Problem2680
    {
        public class Solution
        {
            private const long One = 1;
            public long MaximumOr(int[] nums, int k)
            {
                int[] bitsCount = new int[64];
                for (int i = 0; i < 64; ++i)
                {
                    bitsCount[i] = 0;
                }

                foreach (int num in nums)
                {
                    int tmp = num;
                    int index = 0;
                    while (tmp > 0)
                    {
                        if ((tmp & 1) == 1)
                        {
                            bitsCount[index]++;
                        }

                        index++;
                        tmp >>= 1;
                    }
                }

                // Console.WriteLine(string.Join(", ", bitsCount));
                long ans = 0;
                foreach (int num in nums)
                {
                    ans = Math.Max(ans, this.GetResult(num, k, bitsCount));
                    // Console.WriteLine($"num = {num}, ans = {ans}, tmp = {this.GetResult(num, k, bitsCount)}");
                }

                return ans;
            }

            public long GetResult(int num, int k, int[] bitsCount)
            {
                int tmp = num;
                int index = 0;
                while (tmp > 0)
                {
                    if ((tmp & 1) == 1)
                    {
                        bitsCount[index]--;
                        bitsCount[index + k]++;
                    }

                    index++;
                    tmp >>= 1;
                }

                long ans = this.Getlong(bitsCount);

                tmp = num;
                index = 0;
                while (tmp > 0)
                {
                    if ((tmp & 1) == 1)
                    {
                        bitsCount[index]++;
                        bitsCount[index + k]--;
                    }

                    index++;
                    tmp >>= 1;
                }

                return ans;
            }

            public long Getlong(int[] bitsCount)
            {
                long ans = 0;
                for (int i = 0; i < 64; ++i)
                {
                    if (bitsCount[i] > 0)
                    {
                        ans += (One << i);
                    }
                }

                return ans;
            }
        }
    }
}
