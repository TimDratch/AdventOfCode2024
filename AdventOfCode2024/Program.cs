using AdventOfCode2024.DayOne;

namespace AdventOfCode2024
{
    public static class Program
    {
        public static void Main()
        {
            One.PopulateInput();
            Console.WriteLine("Part One: " + One.CalculatePartOne());
            Console.WriteLine("Part Two: " + One.CalculatePartTwo());
        }
    }
}