namespace LeetCode.TODOs.RamdomPick
{
    using System.Collections.Generic;

    internal class Problem0722
    {
        public class Solution
        {
            private int index = 0;
            private string[] input;

            public IList<string> RemoveComments(string[] source)
            {
                input = source;
                List<string> result = new List<string>();

                while (index < input.Length)
                {
                    string next = RemoveCommentsNotInBlockComment();
                    if (!string.IsNullOrEmpty(next))
                    {
                        result.Add(next);
                    }
                }

                return result;
            }

            private string RemoveCommentsNotInBlockComment()
            {
                if (index < input.Length)
                {
                    string result;
                    int startIndexOfLineComment = input[index].IndexOf("//");
                    int startIndexOfBlockComment = input[index].IndexOf("/*");

                    if (startIndexOfLineComment == -1 && startIndexOfBlockComment == -1)
                    {
                        result = input[index];
                        index++;
                        return result;
                    }

                    if (startIndexOfBlockComment == -1 ||
                        startIndexOfLineComment != -1 && startIndexOfLineComment < startIndexOfBlockComment)
                    {
                        result = input[index].Substring(0, startIndexOfLineComment);
                        index++;
                        return result;
                    }

                    result = input[index].Substring(0, startIndexOfBlockComment);
                    input[index] = input[index].Substring(startIndexOfBlockComment + 2);
                    result += RemoveCommentInBlockComment();
                    return result;
                }

                return string.Empty;
            }

            private string RemoveCommentInBlockComment()
            {
                while (index < input.Length)
                {
                    int endIndexOfEndComment = input[index].IndexOf("*/");
                    if (endIndexOfEndComment != -1)
                    {
                        input[index] = input[index].Substring(endIndexOfEndComment + 2);
                        return RemoveCommentsNotInBlockComment();
                    }

                    index++;
                }

                return string.Empty;
            }
        }
    }
}
