# Fast Exponentiation

A fast algorithm to calculate `a^b` in $O(logb)$ time. It's easy to understand, just refer the code of fast exponentiation of matrix below.

```C#
public static long[,] FastExponential(long[,] matrix, long exp)
{
    int height = matrix.GetLength(0), width = matrix.GetLength(1);

    long[,] ans = new long[height, width];
    for (int i = 0; i < height; i++)
    {
        for (int j = 0; j < width; j++)
        {
            ans[i, j] = 0;
        }

        ans[i, i] = 1;
    }

    while (exp > 0)
    {
        if (exp % 2 == 1)
        {
            ans = Multiple(ans, matrix);
        }

        matrix = Multiple(matrix, matrix);
        exp /= 2;
    }

    return ans;
}
```
