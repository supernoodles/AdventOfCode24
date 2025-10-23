// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, Day10!");

var input = File.ReadAllLines("input.txt");

var day10 = new Code.Day10();

Console.WriteLine($"Part1 = {Code.Day10.Part1(input)}");

Console.WriteLine($"Part2 = {Code.Day10.Part2(input)}");

