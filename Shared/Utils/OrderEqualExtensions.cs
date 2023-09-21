namespace Shared.Utils
{
    public static class OrderEqualExtensions
    {
        public static bool OrderEuqal(this IEnumerable<int> l1, IEnumerable<int> l2)
        {
            var e1 = l1.GetEnumerator();
            var e2 = l2.GetEnumerator();
            while (true)
            {
                bool hasEle1 = e1.MoveNext();
                bool hasEle2 = e2.MoveNext();
                if (hasEle1 != hasEle2)
                {
                    return false;
                }

                if (!hasEle1)
                {
                    return true;
                }

                if (e1.Current != e2.Current)
                {
                    return false;
                }
            }
        }
    }
}
