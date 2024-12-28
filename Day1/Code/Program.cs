// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, Day1!");

var input = File.ReadAllLines("input.txt");

var day1 = new Day1.Day1();

Console.WriteLine($"Part1={day1.Part1(input)}");

Console.WriteLine($"Part2={day1.Part2(input)}");
