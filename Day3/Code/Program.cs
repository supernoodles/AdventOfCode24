// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, Day3!");

var input = File.ReadAllText("input.txt");

var day3 = new Code.Day3();

Console.WriteLine($"Part1 = {day3.Part1(input)}");
