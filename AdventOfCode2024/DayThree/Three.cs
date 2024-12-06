using System.Text.RegularExpressions;

namespace AdventOfCode2024.DayThree
{
    public class Three
    {
        public static void Calculate()
        {
            var data = File.ReadAllText(@"./DayThree/Input/Input.txt");
            var matches = FindPatterns(data);
            var list = matches
                .Select(x => x.Value)
                .ToList();
            Console.WriteLine("Part One :" + CalculatePartOne(list));
            Console.WriteLine("Part Two :" + CalculatePartTwo(data));
        }
        static MatchCollection FindPatterns(string input)
        {
            string pattern = @"mul\(\d{1,3},\d{1,3}\)";
            var regex = new Regex(pattern);
            return regex.Matches(input);
        }

        private static int[] StripChars(string arr)
        {
            var pattern = @"\d+";
            var regex = new Regex(pattern);

            return regex.Matches(arr).
                Select(x => int.Parse(x.Value))
                .ToArray();
        }
        private static int CalculatePartOne(List<string> list)
        {
            var total = 0;
            foreach (var val in list)
            {
                var stripped = StripChars(val);

                total += stripped.First() * stripped.Last();
            }
            return total;
        }

        private static int CalculatePartTwo(string data)
        {
            var total = 0;
            var split = data.Split(@"don't");

            for (int i = 0; i < split.Length; i++)
            {
                var trimmed = split[i].Split("do()").Where((x, y) => y != 0);
                var concat = string.Concat(trimmed);
                var matches = FindPatterns(i == 0 ? split[i] : concat);

                var list = matches
                            .Select(x => StripChars(x.Value))
                            .ToList();

                total += list.Sum(x => x.First() * x.Last());
            }
            return total;
        }
    }
}
