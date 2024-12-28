namespace Day1;

public class Day1
{
    public int Part1(string[] input)
    {
        var (left, right) = Parse(input);
        
        var totalDistance = 
            left.OrderBy(_ => _)
            .Zip(right.OrderBy(_ => _), (l, r) => Math.Abs(l - r))
            .Sum();

        return totalDistance;
    }

    public int Part2(string[] input)
    {
        var (left, right) = Parse(input);

        var rightFreq = right.GroupBy(_ => _)
            .ToLookup(_ => _.Key, _ => _.Count());

        return left.Select(_ => _ * rightFreq[_].FirstOrDefault()).Sum();
    }

    private (List<int> left, List<int> right) Parse(string[] input)
    {
        List<int> left = [];
        List<int> right = [];

        var splitOptions = StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries;

        foreach (var line in input.Where(_ => !string.IsNullOrWhiteSpace(_)))
        {
            var parts = line.Split(' ', splitOptions);

            left.Add(int.Parse(parts[0]));
            right.Add(int.Parse(parts[1]));
        }   

        return (left, right);
    }
}