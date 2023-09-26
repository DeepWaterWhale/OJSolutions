namespace LeetCode.TODOs.WC346
{
    internal class Problem2698
    {
        public class Solution
        {
            private static readonly List<int> nums = new List<int>();

            static Solution()
            {
                for (int i = 1; i <= 1000; i++)
                {
                    if (CanSplitAndAddTo(i * i, i))
                    {
                        nums.Add(i);
                    }
                }
            }

            // Consider the last splited part of num % exp;
            // Then need to split num / exp and add them to target - num % exp;
            private static bool CanSplitAndAddTo(int num, int target)
            {
                if (num == target)
                {
                    return true;
                }

                if (num < target || target < 0)
                {
                    return false;
                }

                int exp = 10;
                while (exp < num)
                {
                    if (CanSplitAndAddTo(num / exp, target - (num % exp)))
                    {
                        return true;
                    }

                    exp *= 10;
                }

                return false;
            }

            public int PunishmentNumber(int n)
            {
                // Console.WriteLine(string.Join(", ", nums));
                int ans = 0;
                foreach (int num in nums)
                {
                    if (num <= n)
                    {
                        ans += num * num;
                    }
                    else
                    {
                        break;
                    }
                }

                return ans;
            }
        }
    }
}
