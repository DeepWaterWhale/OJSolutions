using Shared.Utils;

namespace LeetCode.TODOs.Weekly385
{
    internal class Problem3044
    {
        public class Solution
        {
            private readonly (int, int)[] Directions = new (int, int)[]
            { 
                (-1, -1), (-1, 0), (-1, 1), 
                (0, 1), (0, -1),
                (1, -1), (1, 0), (1, 1), 
            };

            private readonly HashSet<int> primes = new HashSet<int>();

            public int MostFrequentPrime(int[][] mat)
            {
                this.GetAllPrimes(999999);
                Dictionary<int, int> nums = new Dictionary<int, int>();
                int width = mat.Length;
                int height = mat[0].Length;
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        foreach (var num in this.GetNumbers(mat, width, height, i, j))
                        {
                            if (nums.ContainsKey(num))
                            {
                                nums[num]++;
                            }
                            else
                            {
                                nums[num] = 1;
                            }
                        }
                    }
                }
            
                foreach (var kv in nums.ToList().OrderByDescending(kv => kv.Value))
                {
                    int num = kv.Key;
                    if (num > 10 && this.primes.Contains(num))
                    {
                        return num;
                    }
                }

                return -1;
            }

            private void GetAllPrimes(int max)
            {
                bool[] flags = ArrayUtils.MakeArray(max + 1, true);
                
                for (int num = 2; num <= max; num++)
                {
                    if (flags[num])
                    {
                        this.primes.Add(num);
                        int now = num + num;
                        while (now <= max)
                        {
                            flags[now] = false;
                            now += num;
                        }
                    }
                }
            }

            private IEnumerable<int> GetNumbers(int[][] mat, int width, int height, int i, int j)
            {
                foreach (var (x, y) in this.Directions)
                {
                    int now = mat[i][j];
                    while (i + x >= 0 && i + x < width &&
                        j + y >= 0 && j + y < height)
                    {
                        i += x;
                        j += y;
                        now = now * 10 + mat[i][j];
                    }

                    yield return now;
                }
            }
        }
    }
}
