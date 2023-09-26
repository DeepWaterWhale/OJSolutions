namespace LeetCode.WeeklyContest.WC351
{
    internal class Problem2751
    {
        public class Solution
        {
            private class Robot
            {
                public int Index { get; set; }
                public int Position { get; set; }
                public int Health { get; set; }
                public bool ToRight { get; set; }
                public bool WouldSurvive { get; set; }

                public Robot(int index, int position, int health, char direction)
                {
                    this.Index = index;
                    this.Position = position;
                    this.Health = health;
                    this.ToRight = direction == 'R';
                    this.WouldSurvive = true;
                }
            }

            public IList<int> SurvivedRobotsHealths(int[] positions, int[] healths, string directions)
            {
                List<Robot> robots = new List<Robot>();
                for (int i = 0; i < positions.Length; ++i)
                {
                    robots.Add(new Robot(i + 1, positions[i], healths[i], directions[i]));
                }

                robots.Sort((a, b) => 
                {
                    return a.Position - b.Position;
                });

                // Console.WriteLine(string.Join(", ", robots.Select(r => $"{r.Position}|{r.Health}|{r.ToRight}")));

                Stack<Robot> toRightRobots = new Stack<Robot>();
                foreach (Robot current in robots)
                {
                    if (current.ToRight)
                    {
                        // Move to right
                        toRightRobots.Push(current);
                    }
                    else
                    {
                        // Move to left, potentially collide with all robots in the stack
                        while (toRightRobots.Count > 0)
                        {
                            Robot r = toRightRobots.Peek();
                            if (r.Health == current.Health)
                            {
                                r.WouldSurvive = false;
                                current.WouldSurvive = false;
                                toRightRobots.Pop();
                                break;
                            }
                            else if (r.Health > current.Health)
                            {
                                r.Health--;
                                current.WouldSurvive = false;
                                break;
                            }
                            else
                            {
                                r.WouldSurvive = false;
                                toRightRobots.Pop();
                                current.Health--;
                            }
                        }
                    }
                }

                return robots.Where(r => r.WouldSurvive).OrderBy(r => r.Index).Select(r => r.Health).ToList();
            }
        }
    }
}
