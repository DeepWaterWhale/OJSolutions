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
    }
}
