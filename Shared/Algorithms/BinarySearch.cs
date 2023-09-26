namespace Shared.Algorithms
{
    public class BinarySearch
    {
        public static int SearchInt(int left, int right, Func<int, bool> predicate)
        {
            while (left < right)
            {
                int middle = (right + left) / 2;
                if (predicate(middle))
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
            }

            if (predicate(left))
            {
                return left;
            }

            return left - 1;
        }

        public static long SearchLong(long left, long right, Func<long, bool> predicate)
        {
            while (left < right)
            {
                long middle = (right + left) / 2;
                if (predicate(middle))
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
            }

            if (predicate(left))
            {
                return left;
            }

            return left - 1;
        }
    }
}
