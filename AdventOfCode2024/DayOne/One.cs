
namespace AdventOfCode2024.DayOne
{
    public class One
    {
        private static readonly List<int> ListA = [];
        private static readonly List<int> ListB = [];
        private static int Count = 0;

         public static void PopulateInput()
        {
            var data = File.ReadAllLines(@"./Dayone/Input/Input.txt");
            foreach (var line in data)
            {
                var split = line.Split(' ')
                    .Where(x => x is not null)
                    .ToArray();
                ListA.Add(int.Parse(split.First()));
                ListB.Add(int.Parse(split.Last()));
            }
            Count = ListA.Count;
        }

        public static int CalculatePartOne()
        {
            var sum = 0;

            var orderedA = ListA.OrderBy(x => x).ToArray();
            var orderedB = ListB.OrderBy(x => x).ToArray();
            for (var i = 0; i < Count; i++)
            {
                sum += GetDifference(orderedA[i], orderedB[i]);
            }

            return sum;
        }

        public static int CalculatePartTwo()
        {
            return ListA.Sum(x => x * ListB.Where(y => y == x).Count());
        }

        private static int GetDifference(int a, int b)
        {
            return a > b ? a - b : b - a;
        }

    }
}
