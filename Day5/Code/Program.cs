// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, Day 5!");

var day5 = new Code.Day5();

var input = File.ReadAllLines("input.txt");

Console.WriteLine($"Part1={day5.Part1(input)}");