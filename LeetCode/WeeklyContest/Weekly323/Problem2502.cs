namespace LeetCode.WeeklyContest.Weekly323
{
    internal class Problem2502
    {
        public class Allocator
        {
            private readonly LinkedList<MemoryBlock> blocks = new LinkedList<MemoryBlock>();

            public Allocator(int n)
            {
                this.blocks.AddLast(new MemoryBlock(-1, 0, n));
            }

            public int Allocate(int size, int mID)
            {
                var node = this.blocks.First;
                while (node != null)
                {
                    var block = node.Value;
                    if (block.Id == -1 && block.Size >= size)
                    {
                        // Find a free block
                        if (block.Size > size)
                        {
                            // Insert a new free block
                            this.blocks.AddAfter(node, new MemoryBlock(-1, block.StartIndex + size, block.Size - size));
                        }

                        // Update current block
                        block.Id = mID;
                        block.Size = size;
                        return block.StartIndex;
                    }

                    node = node.Next;
                }

                return -1;
            }

            public int Free(int mID)
            {
                var ans = 0;
                var node = this.blocks.First;

                while (node != null)
                {
                    var block = node.Value;
                    if (block.Id == mID)
                    {
                        ans += block.Size;
                        block.Id = -1;
                    }

                    node = node.Next;
                }

                // Merge empty blocks
                node = this.blocks.First;
                while (node != null)
                {
                    var block = node.Value;
                    if (block.Id == -1)
                    {
                        var next = node.Next;
                        while (next != null && next.Value.Id == -1)
                        {
                            block.Size += next.Value.Size;
                            next = next.Next;
                        }

                        while (node.Next != next)
                        {
                            this.blocks.Remove(node.Next);
                        }
                    }

                    node = node.Next;
                }

                return ans;
            }

            private class MemoryBlock
            {
                public int Id { get; set; }
                public int StartIndex { get; set; }
                public int Size { get; set; }

                public MemoryBlock(int id, int startIndex, int length)
                {
                    this.Id = id;
                    this.StartIndex = startIndex;
                    this.Size = length;
                }
            }
        }
    }
}
