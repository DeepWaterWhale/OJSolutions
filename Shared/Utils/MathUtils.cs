namespace Shared.Utils
{
    public static class MathUtils
    {
        public static long Permutation(int n, int r)
        {
            long ans = 1;
            for (int i = 0; i < r; i++)
            {
                ans *= n - i;
            }

            return ans;
        }


        public static long Permutation(int n, int r, int MOD)
        {
            long ans = 1;
            for (int i = 0; i < r; i++)
            {
                ans *= n - i;
                ans %= MOD;
            }

            return ans;
        }

        public static long Combination(int n, int r)
        {
            long ans = 1;
            for (int i = 0; i < r; i++)
            {
                ans = ans * (n - i) / (i + 1);
            }

            return ans;
        }

        public static long Factorial(int n)
        {
            long ans = 1;
            while (n > 0)
            {
                ans *= n;
                n -= 1;
            }

            return ans;
        }

        public static long Factorial(int n, int MOD)
        {
            long ans = 1;
            while (n > 0)
            {
                ans *= n;
                ans %= MOD;
                n -= 1;
            }

            return ans;
        }

        public static HashSet<int> GetAllPrimes(int max)
        {
            HashSet<int> result = new HashSet<int>();
            var list = ArrayUtils.MakeArray(max + 1, false);
            for (int i = 2; i <= max; ++i)
            {
                if (!list[i])
                {
                    result.Add(i);
                    for (int k = i; k <= max; k += i)
                    {
                        list[k] = true;
                    }
                }
            }

            return result;
        }
    }
}
