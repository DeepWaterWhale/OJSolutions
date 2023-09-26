namespace OjProblems.LeetCode
{
    using System.Collections.Generic;

    internal class Problem0526
    {
        public class Solution
        {
            // currentPerm is like [0, a1, a2, a3, 0, ..., 0], ai must not be 0 and can't be same
            //     - First 0 is like a place holder
            //     - 
            private readonly List<bool> used = new List<bool>();
            private int permCount = 0;
            private int maxNumber;

            public int CountArrangement(int n)
            {
                this.maxNumber = n;
                for (int i = 0; i <= n; ++i)
                {
                    this.used.Add(false);
                }

                this.BackTracing(1);
                return this.permCount;
            }

            private void BackTracing(int index)
            {
                if (index == this.maxNumber + 1)
                {
                    // No this.currentPerm is a valid perm
                    this.permCount++;
                    return;
                }

                for (int num = 1; num <= this.maxNumber; ++num)
                {
                    if (!this.used[num] && (index % num == 0 || num % index == 0))
                    {
                        this.used[num] = true;
                        this.BackTracing(index + 1);
                        this.used[num] = false;
                    }
                }
            }
        }
    }
}
