namespace Code;

public class Day11
{
    public int Part1(string input)
    {
        IEnumerable<string> sequence = input.Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        var count = 0;

        do
        {
            var nextSequence = sequence.SelectMany(stone =>
            {
                var list = new List<string>();

                if (stone == "0")
                {
                    list.Add("1");
                }
                else if (stone.Length > 1 && stone.Length % 2 == 0)
                {
                    list.Add(stone[..(stone.Length / 2)]);
                    list.Add($"{long.Parse(stone[(stone.Length / 2)..])}");
                }
                else
                {
                    list.Add($"{2024 * long.Parse(stone)}");
                }

                return list;
            }).ToList();

            sequence = nextSequence;

            ++count;

            Console.WriteLine(count);
        } while (count < 25);

        return sequence.Count();
    }

    public long Part2(string input)
    {
        Dictionary<(long, int), long> memo = [];
        
        IEnumerable<int> sequence = input.Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Select(number => int.Parse(number));

        return sequence.Select(number => Recurse(number, 75, memo)).Sum();
    }

    private long Recurse(long number, int steps, Dictionary<(long, int), long> memo)
    {
        if (memo.TryGetValue((number, steps), out long result))
        {
            return result;
        }

        if (steps == 0)
        {
            return 1;
        }

        var res = 0L;

        var numberAsString = $"{number}";

        if (number == 0)
        {
            res = Recurse(1, steps - 1, memo);
        }
        else if (numberAsString.Length > 1 && numberAsString.Length % 2 == 0)
        {
            res = Recurse(int.Parse(numberAsString[..(numberAsString.Length / 2)]), steps - 1, memo)
                + Recurse(int.Parse($"{long.Parse(numberAsString[(numberAsString.Length / 2)..])}"), steps - 1, memo);
        }
        else
        {
            res = Recurse(number * 2024L, steps - 1, memo);
        }

        memo.Add((number, steps), res);

        return res;
    }
}