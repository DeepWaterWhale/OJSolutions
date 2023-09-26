// --------------------------------------------------------------------------------------------------
//  author:       big_chicken
//  problem_link: 
//  note_link:    
//  tags:         
// --------------------------------------------------------------------------------------------------

namespace OjProblems.LeetCode.Contest.WeeklyContest340
{
    public class Problem2614
    {
        public class Solution
        {
            private static readonly HashSet<int> Primes;
            private static readonly int MAX_INT = (int)4e6 + 10;

            static Solution()
            {
                Primes = new HashSet<int>();
                bool[] visited = new bool[MAX_INT];
                for (int i = 0; i < MAX_INT; ++i)
                {
                    visited[i] = false;
                }

                int num = 2;
                while (num < MAX_INT)
                {
                    while (num < MAX_INT && visited[num])
                    {
                        num++;
                    }

                    Primes.Add(num);

                    int tmp = num;
                    while (tmp < MAX_INT)
                    {
                        visited[tmp] = true;
                        tmp += num;
                    }
                }
            }

            public int DiagonalPrime(int[][] nums)
            {
                int size = nums.Length;
                int ans = 0;
                for (int i = 0; i < size; ++i)
                {
                    if (Primes.Contains(nums[i][i]))
                    {
                        ans = Math.Max(ans, nums[i][i]);
                    }

                    if (Primes.Contains(nums[i][size - i - 1]))
                    {
                        ans = Math.Max(ans, nums[i][size - i - 1]);
                    }
                }

                return ans;
            }
        }
    }
}
