// See https://aka.ms/new-console-template for more information
using Code;

Console.WriteLine("Hello, Day 2!");

var input = File.ReadAllLines("input.txt");

var day2 = new Code.Day2();

Console.WriteLine($"Part1={day2.Part1(input)}");

Console.WriteLine($"Part2={day2.Part2(input)}");    