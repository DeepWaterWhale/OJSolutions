// --------------------------------------------------------------------------------------------------
//  author:       big_chicken
//  problem_link: https://leetcode.com/contest/weekly-contest-340/problems/minimize-the-maximum-difference-of-pairs/
//  note_link:    
//  tags:         binary-search, greedy-algorithm
// --------------------------------------------------------------------------------------------------

namespace OjProblems.LeetCode.Contest.WeeklyContest340
{
    using System.Collections.Generic;
    using System.Linq;

    internal class Problem2616
    {
        public class Solution
        {
            public int MinimizeMax(int[] nums, int p)
            {
                var nl = nums.ToList();
                nl.Sort();

                int l = 0, r = nl[nl.Count - 1] - nl[0];
                while (l < r)
                {
                    int m = (l + r) / 2;
                    if (this.IsPossible(nl, p, m))
                    {
                        r = m;
                    }
                    else
                    {
                        l = m + 1;
                    }
                }

                return l;
            }

            private bool IsPossible(List<int> nl, int p, int diff)
            {
                if (p == 0)
                {
                    return true;
                }

                for (int i = 0; i < nl.Count - 1; ++i)
                {
                    if (nl[i + 1] - nl[i] <= diff)
                    {
                        p--;
                        if (p == 0)
                        {
                            return true;
                        }

                        i++;
                    }
                }

                return false;
            }
        }
    }
}
