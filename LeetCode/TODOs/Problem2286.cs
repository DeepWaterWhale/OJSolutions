namespace OjProblems.LeetCode
{
    internal class Problem2286
    {
        public class BookMyShow
        {
            private readonly int MaxRow;
            private readonly int MaxSeats;
            private readonly int[] SeatIndexes;
            public BookMyShow(int n, int m)
            {
                this.MaxRow = n;
                this.MaxSeats = m;
                this.SeatIndexes = new int[n];
            }

            public int[] Gather(int k, int maxRow)
            {
                return null;
            }

            public bool Scatter(int k, int maxRow)
            {
                return false;
            }
        }

        /**
         * Your BookMyShow object will be instantiated and called as such:
         * BookMyShow obj = new BookMyShow(n, m);
         * int[] param_1 = obj.Gather(k,maxRow);
         * bool param_2 = obj.Scatter(k,maxRow);
         */
    }
}
