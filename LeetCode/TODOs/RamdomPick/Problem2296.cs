using System.Text;

namespace LeetCode.TODOs.RamdomPick
{
    public class Problem2296
    {
        public class TextEditor
        {
            private class CharNode
            {
                public char Char { get; }
                public CharNode Next { get; set; }
                public CharNode Previous { get; set; }

                public CharNode(char c)
                {
                    Char = c;
                }

                public static CharNode AppendChar(CharNode now, char c)
                {
                    if (now == null)
                    {
                        return new CharNode(c);
                    }

                    var next = now.Next;
                    var newNode = new CharNode(c);

                    now.Next = newNode;
                    newNode.Previous = now;

                    newNode.Next = next;
                    if (next != null)
                    {
                        next.Previous = newNode;
                    }

                    return newNode;
                }
            }

            private readonly CharNode _head;
            private CharNode _cursor; // Would never be null

            public TextEditor()
            {
                _head = new CharNode('.');
                _cursor = _head;
            }

            public void AddText(string text)
            {
                foreach (char c in text)
                {
                    _cursor = CharNode.AppendChar(_cursor, c);
                }
            }

            public int DeleteText(int k)
            {
                CharNode next = _cursor.Next;
                int removed = 0;
                while (removed < k && _cursor != _head)
                {
                    _cursor = _cursor.Previous;
                    removed++;
                }

                _cursor.Next = next;
                if (next != null)
                {
                    next.Previous = _cursor;
                }

                return removed;
            }

            public string CursorLeft(int k)
            {
                while (k > 0 && _cursor != _head)
                {
                    _cursor = _cursor.Previous;
                    k--;
                }

                return GetString();
            }

            public string CursorRight(int k)
            {
                while (k > 0 && _cursor.Next != null)
                {
                    _cursor = _cursor.Next;
                    k--;
                }

                return GetString();
            }

            private string GetString()
            {
                List<char> cs = new List<char>();
                var node = _cursor;
                int max = 10;
                while (node != _head && max > 0)
                {
                    cs.Add(node.Char);
                    node = node.Previous;
                    max--;
                }

                cs.Reverse();
                StringBuilder sb = new StringBuilder();
                foreach (var c in cs)
                {
                    sb.Append(c);
                }

                return sb.ToString();
            }
        }

        /**
         * Your TextEditor object will be instantiated and called as such:
         * TextEditor obj = new TextEditor();
         * obj.AddText(text);
         * int param_2 = obj.DeleteText(k);
         * string param_3 = obj.CursorLeft(k);
         * string param_4 = obj.CursorRight(k);
         */
    }
}
