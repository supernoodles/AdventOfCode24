namespace code;

public class Day7
{
    public long Part1(string[] input)
    {
        List<Func<long, long, long>> operations = [(a, b) => a + b, (a, b) => a * b];

        return RunCalibration(input, operations);
    }

    public long Part2(string[] input)
    {
        List<Func<long, long, long>> operations = [(a, b) => a + b, (a, b) => a * b, (a, b) => long.Parse($"{a}{b}")];

        return RunCalibration(input, operations);
    }

    private long RunCalibration(string[] input, List<Func<long,long,long>> operations)
    {
        var (testValues, testOperands) = Parse(input);

        long total = Enumerable.Range(0, testValues.Count)
            .Select(index =>
            {
                List<long> results = [];

                Recurse(results, testOperands[index], 1, testOperands[index][0], operations);

                return results.Any(result => result == testValues[index])
                    ? testValues[index]
                    : 0;
            })
            .Sum();

        return total;        
    }

    private void Recurse(List<long> results, List<int> operands, int index, long total, List<Func<long, long, long>> operations)
    {
        if (index == operands.Count)
        {
            results.Add(total);

            return;
        }

        foreach (var operation in operations)
        {
            Recurse(results, operands, index + 1, operation(total, operands[index]), operations);
        }
    }

    private (List<long> testValues, List<List<int>> testOperands) Parse(string[] input)
    {
        List<long> testValues = [];
        List<List<int>> testOperands = [];

        var stringSplitOptions = StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries;

        input.Where(_ => !string.IsNullOrWhiteSpace(_))
            .ToList()
            .ForEach(line =>
            {
                var parts = line.Split(':', stringSplitOptions);
                testValues.Add(long.Parse(parts[0]));
                testOperands.Add([.. parts[1].Split(" ", stringSplitOptions).Select(part => int.Parse(part))]);
            });

        return (testValues, testOperands);
    }
}
