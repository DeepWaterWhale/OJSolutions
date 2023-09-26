namespace OjProblems.LeetCode
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    internal class Problem1096
    {
        public class Solution
        {
            private readonly Dictionary<int, int> braces = new Dictionary<int, int>();

            public IList<string> BraceExpansionII(string expression)
            {
                Stack<int> s = new Stack<int>();
                for (int i = 0; i < expression.Length; ++i)
                {
                    if (expression[i] == '{')
                    {
                        s.Push(i);
                    }

                    if (expression[i] == '}')
                    {
                        this.braces[s.Pop()] = i;
                    }
                }

                var ans = this.BraceExpansion(expression, 0, expression.Length).ToList();
                ans.Sort();
                return ans;
            }

            private IList<string> BraceExpansion(string expression, int start, int end)
            {
                if (start >= end || start >= expression.Length)
                {
                    return null;
                }

                if (expression[start] == '{')
                {
                    if (end > this.braces[start])
                    {
                        // expression.Substring(start, end - start) == "{a, {b, c}, d}efg"
                        var left = this.BraceExpansion(expression, start, this.braces[start]); // "{a, {b, c}, d}"
                        var right = this.BraceExpansion(expression, this.braces[start] + 1, end); // "efg"
                        return this.Concatenation(left, right);
                    }

                    if (end != this.braces[start])
                    {
                        throw new Exception();
                    }

                    // expression.Substring(start, end - start) == "{a, {b, c}, d}"
                    HashSet<string> hs = new HashSet<string>();
                    int now = start + 1;
                    int previous = now;
                    while (now < end && now < expression.Length)
                    {
                        if (expression[now] == ',')
                        {
                            this.Union(hs, this.BraceExpansion(expression, previous, now));
                            now++;
                            previous = now;
                        }
                        else if (expression[now] == '{')
                        {
                            now = this.braces[now] + 1;
                            previous = now;
                        }
                        else
                        {
                            now++;
                        }
                    }

                    this.Union(hs, this.BraceExpansion(expression, previous, now));
                    return hs.ToList();
                }

                int index = expression.IndexOf('{', start);
                if (index == -1 || index >= end)
                {
                    // expression.Substring(start, end - start) == "aaaa"
                    return new List<string>() { expression.Substring(start, end - start) };
                }
                else
                {
                    // expression.Substring(start, end - start) == "aaaa{b, c}def"
                    string prefix = expression.Substring(start, index - start);
                    var right = this.BraceExpansion(expression, index, end);

                    return right.Select(str => prefix + str).ToList();
                }
            }

            private IList<string> Concatenation(IList<string> left, IList<string> right)
            {
                if (left == null)
                {
                    return right;
                }

                if (right == null)
                {
                    return left;
                }

                List<string> ans = new List<string>(left.Count * right.Count);
                foreach (string s in left)
                {
                    foreach (string s1 in right)
                    {
                        ans.Add(s + s1);
                    }
                }

                return ans;
            }

            private HashSet<string> Union(HashSet<string> hs, IList<string> l)
            {
                if (l == null)
                {
                    return hs;
                }

                foreach (string s in l)
                {
                    hs.Add(s);
                }

                return hs;
            }
        }
    }
}
