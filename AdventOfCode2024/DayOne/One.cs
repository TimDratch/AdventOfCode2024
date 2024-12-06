namespace AdventOfCode2024.DayOne
{
    public class One
    {
        public static void Calculate()
        {
            var data = File.ReadAllLines(@"./Dayone/Input/InputTest.txt");
            var listA = new List<int>();
            var listB = new List<int>();

            foreach (var line in data)
            {
                var split = line.Split(' ')
                    .Where(x => x is not null)
                    .ToArray();
                listA.Add(int.Parse(split.First()));
                listB.Add(int.Parse(split.Last()));
            }
            Console.WriteLine("Part One :" + CalculatePartOne(listA, listB));
            Console.WriteLine("Part Two :" + CalculatePartTwo(listA, listB));
        }

        private static int CalculatePartOne(List<int> listA, List<int> listB)
        {
            var sum = 0;

            var orderedA = listA.OrderBy(x => x).ToArray();
            var orderedB = listB.OrderBy(x => x).ToArray();

            for (var i = 0; i < listA.Count; i++)
                sum += GetDifference(orderedA[i], orderedB[i]);

            return sum;
        }

        private static int CalculatePartTwo(List<int> listA, List<int> listB)
        {
            return listA.Sum(x => x * listB.Where(y => y == x).Count());
        }

        private static int GetDifference(int a, int b)
        {
            return a > b ? a - b : b - a;
        }

    }
}
