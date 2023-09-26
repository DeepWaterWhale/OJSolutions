using System.Text;

namespace OjProblems.LeetCode
{
    public class Problem2296
    {
        public class TextEditor
        {
            private class CharNode
            {
                public Char Char { get; }
                public CharNode Next { get; set; }
                public CharNode Previous { get; set; }

                public CharNode(char c)
                {
                    this.Char = c;
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
                this._head = new CharNode('.');
                this._cursor = this._head;
            }

            public void AddText(string text)
            {
                foreach (char c in text)
                {
                    this._cursor = CharNode.AppendChar(this._cursor, c);
                }
            }

            public int DeleteText(int k)
            {
                CharNode next = this._cursor.Next;
                int removed = 0;
                while (removed < k && this._cursor != this._head)
                {
                    this._cursor = this._cursor.Previous;
                    removed++;
                }

                this._cursor.Next = next;
                if (next != null)
                {
                    next.Previous = this._cursor;
                }
                
                return removed;
            }

            public string CursorLeft(int k)
            {
                while (k > 0 && this._cursor != this._head)
                {
                    this._cursor = this._cursor.Previous;
                    k--;
                }

                return this.GetString();
            }

            public string CursorRight(int k)
            {
                while (k > 0 && this._cursor.Next != null)
                {
                    this._cursor = this._cursor.Next;
                    k--;
                }

                return this.GetString();
            }

            private string GetString()
            {
                List<char> cs = new List<char>();
                var node = this._cursor;
                int max = 10;
                while (node != this._head && max > 0)
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
