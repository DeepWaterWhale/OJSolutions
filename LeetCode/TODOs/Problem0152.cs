namespace LeetCode.TODOs
{
    using System;

    internal class Problem0152
    {
        public class Solution
        {
            public int MaxProduct(int[] nums)
            {
                int ans = nums[0];
                int index = 0;
                while (index < nums.Length)
                {
                    while (index < nums.Length && nums[index] == 0)
                    {
                        index++;
                    }

                    if (index == nums.Length) break;

                    int leftProd = 1;
                    int prod = 1;
                    while (index < nums.Length && nums[index] != 0)
                    {
                        if (prod > 0)
                        {
                            leftProd *= nums[index];
                            ans = Math.Max(ans, leftProd);
                        }

                        prod *= nums[index];
                        index++;
                    }

                    if (prod > 0)
                    {
                        ans = Math.Max(ans, prod);
                    }
                    else
                    {
                        ans = Math.Max(ans, prod / leftProd);
                    }
                }

                return ans;
            }
        }
    }
}
