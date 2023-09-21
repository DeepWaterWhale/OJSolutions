namespace Shared.Algorithms
{
    public static class ZAlgorithm
    {
        public static int[] Search(string text, string pattern)
        {
            string str = pattern + text;
            var zarr = ZFunc(str);
            List<int> res = new List<int>();
            for (int i = pattern.Length; i < str.Length; i++)
            {
                if (zarr[i] >= pattern.Length)
                {
                    res.Add(i - pattern.Length);
                }
            }

            return res.ToArray();
        }

        public static int[] ZFunc(string text)
        {
            int[] zarr = new int[text.Length];
            zarr[0] = text.Length;
            int left = 0, right = 0;
            for (int i = 1; i < text.Length; i++)
            {
                zarr[i] = 0;
                if (i > right)
                {
                    while (i + zarr[i] < text.Length && text[i + zarr[i]] == text[zarr[i]])
                    {
                        zarr[i]++;
                    }
                }
                else
                {
                    int i0 = i - left;
                    if (right - left > i0 + zarr[i0])
                    {
                        zarr[i] = zarr[i0];
                    }
                    else
                    {
                        zarr[i] = right - i;
                        while (i + zarr[i] < text.Length && text[i + zarr[i]] == text[zarr[i]])
                        {
                            zarr[i]++;
                        }
                    }
                }

                if (right < i + zarr[i])
                {
                    left = i;
                    right = i + zarr[i];
                }
            }

            return zarr;
        }
    }
}
