namespace Code;


public class Day2
{
    public int Part1(string[] input)
    {
        var reports = Parse(input);

        return reports.Select(_ => CheckReport(_))
            .Count(_ => _);
    }

    public int Part2(string[] input)
    {
        var reports = Parse(input);

        return reports.Select(_ => CheckDampenedReport(_))
            .Count(_ => _);
    }

    private bool CheckDampenedReport(List<int> report)
    {
        var size = report.Count;

        return 
            CheckReport(report) ||
                Enumerable.Range(0, size)
                    .Select(index => 
                        report.Take(index)
                            .Concat(report.Skip(1 + index).Take(size - index - 1))
                            .ToList())
                    .ToList()
                    .Any(CheckReport);
    }

    private bool CheckReport(List<int> report)
    {
        var diff = report
            .Skip(1)
            .Select((_,i) => _ - report[i])
            .ToList();

        return diff.All(_ => Math.Abs(_) >= 1 && Math.Abs(_) <= 3)
            && (diff.All(_ => _ > 0) || diff.All(_ => _ < 0));
    }

    private static List<List<int>> Parse(string[] input) =>
        input
            .Select(_ => _.Split(" ").Select(_=>int.Parse(_)).ToList())
            .ToList();
}