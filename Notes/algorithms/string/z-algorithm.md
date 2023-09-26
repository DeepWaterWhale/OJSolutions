# Z Algorithm

Z-Algorithm is an efficient algorithm to search a `pattern` in a given `text` string. The main idea is to maintain a Z-Array of `str = pattern + text` calculated by Z-Function described in [Z Function](#z-function).

After getting Z-Array, we just need to find the index where `index > pattern.Length && z[index] >= pattern.Length` to get the index that the pattern exists in the text.

## Z Function

Given a string `str` with length `n`, we can define a function `z[i] = max{len where str.substring(i, len) == str.substring(0, len)}` and an array `z-array = {z[0], z[1], ..., z[str.Length - 1]}`.

### Trivial algorithm to calculate `z[i]`

```C#
int ans = 0;
while (i + ans < str.Length && str[i + ans] == str[ans])
{
    ans++;
}

return ans;
```

### Efficient algorithm to calculate `z[i]`

Calculate `z-array` from left to right. And it's easy to know that `z[0] = str.Length`.

Assume we already know `z[0], z[1], ..., z[i - 1]`.
Then we know the `index` with maximum `index + z[index]` where `index <= i - 1`.

Let `left = index, right = left + z[left]`.

**Case 1**: `i >= right`. we have no knowledge about the substring starting from `i`, use the trivial way to get `z[i]` and update `left, right`.

**Case 2**: `i < right`.

`str[left: right) == str[0, right - left)` ==> `str[i: right) == str[i - left : right - left)`.

Let `i0 = i - left`, then we have `str[i: right) == str[i0 : right - left)`

From z function definition, `str[i0: i0 + z[i0]) == str[0, z[i0]]` is a prefix substring of str.

Now we have 2 sub-cases:

- Case 2.1: `str[i: right)` is not a prefix substring, which means `right - left > i0 + z[i0]`, then `z[i] = z[i0]`.
- Case 2.1: `str[i: right)` is a prefix substring of str, which means `right - left <= i0 + z[i0]`, then use the trivial way to get `z[i]` by comparing `str[right] == str[z[i0]]` and update `left \ right` if needed.

See the implementation in [ZAlgorithm.cs](../../../LeetCodeUtils/Algorithms/ZAlgorithm.cs).