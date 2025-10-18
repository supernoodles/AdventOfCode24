namespace code;

public class Day7
{
    public int Part1(string[] input)
    {
        var (testValues, testOperands) = Parse(input);

        List<Func<int, int, int>> operations = [(a, b) => a + b, (a, b) => a * b];

        int total = Enumerable.Range(0, testValues.Count)
            .Select(index =>
            {
                List<int> results = [];

                Recurse(results, testOperands[index], 1, testOperands[index][0], operations);

                return results.Any(result => result == testValues[index])
                    ? testValues[index]
                    : 0;
            })
            .Sum();

        return total;
    }

    private void Recurse(List<int> results, List<int> operands, int index, int total, List<Func<int, int, int>> operations)
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

    private (List<int> testValues, List<List<int>> testOperands) Parse(string[] input)
    {
        List<int> testValues = [];
        List<List<int>> testOperands = [];

        var stringSplitOptions = StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries;

        input.Where(_ => !string.IsNullOrWhiteSpace(_))
            .ToList()
            .ForEach(line =>
            {
                var parts = line.Split(':', stringSplitOptions);
                testValues.Add(int.Parse(parts[0]));
                testOperands.Add([.. parts[1].Split(" ", stringSplitOptions).Select(part => int.Parse(part))]);
            });

        return (testValues, testOperands);
    }
}
