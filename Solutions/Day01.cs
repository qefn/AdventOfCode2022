namespace AdventOfCode2022.Solutions
{
    public class Day01 : Solution
    {
        public override List<Action> Stages => new List<Action> { Stage1And2 };

        public void Stage1And2()
        {
            List<string> inputs = ReadInputFile("D1");
            List<int> carriedCalories = inputs.Aggregate(new List<int> { 0 }, (List<int> seed, string cur) =>
            {
                if (int.TryParse(cur, out int calories))
                {
                    seed[seed.Count - 1] += calories;
                }
                else
                {
                    seed.Add(0);
                }
                return seed;
            });
            Console.WriteLine($"Stage1: Top calories caries: {carriedCalories.Max()}");
            Console.WriteLine($"Stage1: Top 3 calories caries: {carriedCalories.OrderByDescending(x => x).Take(3).Sum()}");
        }
    }
}