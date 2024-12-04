using AdventOfCode2024.DayOne;
using AdventOfCode2024.DayTwo;

namespace AdventOfCode2024
{
    public static class Program
    {
        public static void Main()
        {
            One.PopulateInput();
            Console.WriteLine("Day One");
            Console.WriteLine("Part One: " + One.CalculatePartOne());
            Console.WriteLine("Part Two: " + One.CalculatePartTwo());
            Two.PopulateInput();
            Console.WriteLine("Day Two");
            Console.WriteLine("Part One: " + Two.CalculatePartOne());
            Console.WriteLine("Part Two: " + Two.CalculatePartTwo());
        }
    }
}