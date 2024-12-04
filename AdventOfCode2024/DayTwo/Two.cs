
namespace AdventOfCode2024.DayTwo
{
    public class Two
    {
        private static List<int[]> Data = [];
        private static readonly char[] separator = [' '];

        public static void PopulateInput()
        {
            var data = File.ReadAllLines(@"./DayTwo/Input/Input.txt");
            var split = data.Select(x => x.Split(separator, StringSplitOptions.RemoveEmptyEntries).ToArray());
            Data = split.Select(x => Array.ConvertAll(x, int.Parse)).ToList();
        }

        public static int CalculatePartOne()
        {
            var count = 0;

            foreach (var line in Data)
                if (ValidateIncrementation(line, false)) count++;

            return count;
        }
        public static int CalculatePartTwo()
        {
            var count = 0;

            foreach (var line in Data)
                if (ValidateIncrementation(line, true)) count++;

            return count;
        }

        private static bool ValidateIncrementation(int[] arr, bool shouldRetry)
        {
            bool? shouldBeAsc = null;
            for (int i = 0; i < arr.Length; i++)
            {
                if (i == 0)
                    continue;

                var difference = arr[i] - arr[i - 1];

                switch (shouldBeAsc)
                {
                    case null:
                        shouldBeAsc = difference > 0;
                        break;
                    case true:
                        if (difference < 0)
                            return shouldRetry && TrimLevelAndRetry(arr);
                        break;
                    case false:
                        if (difference > 0)
                            return shouldRetry && TrimLevelAndRetry(arr);
                        break;
                }

                var abs = Math.Abs(difference);
                if (abs < 1 || abs > 3)
                    return shouldRetry && TrimLevelAndRetry(arr);
            }
            return true;
        }

        private static bool TrimLevelAndRetry(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                var trimmedArr = arr.Where((x, y) => y != i).ToArray();

                if (ValidateIncrementation(trimmedArr, false) == true)
                    return true;
            }
            return false;
        }
    }
}
