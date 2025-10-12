// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, Day 5!");

var testInput = """
47|53
97|13
97|61
97|47
75|29
61|13
75|53
29|13
97|29
53|29
61|53
97|53
61|29
47|13
75|47
97|75
47|61
75|61
47|29
75|13
53|13

75,47,61,53,29
97,61,53,29,13
75,29,13
75,97,47,61,53
61,13,29
97,13,75,29,47
""";

// 97,13,75,29,47
// 97,75,13,29,47
// 97,75,29,13,47
// 97,75,29,47,13
// 97,75,47,29,13

// 97,75,47,29,13.

var day5 = new Code.Day5();

var input = File.ReadAllLines("input.txt");

Console.WriteLine($"Part1={day5.Part1(testInput.Split("\n"))}");

Console.WriteLine($"Part1={day5.Part1(input)}");

Console.WriteLine($"Part1={day5.Part2(input)}");