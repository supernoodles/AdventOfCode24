namespace Code;

public class Day5
{
    public int Part1(string[] input)
    {
        var (orderingRules, pageOrders) = Parse(input);

        return pageOrders
            .Select(order => Enumerable.Range(0, order.Count - 1)
                .All(i => orderingRules.TryGetValue(order[i], out _) && orderingRules[order[i]].Contains(order[i + 1]))
                    ? int.Parse(order[order.Count / 2])
                    : 0)
            .Sum();
    }

    public int Part2(string[] input)
    {
        var (orderingRules, pageOrders) = Parse(input);

        var middle = 0;

        foreach (var order in pageOrders)
        {
            if (isCorrect(order))
            {
                continue;
            }

            var wrong = true;

            while (wrong)
            {
                wrong = false;

                for (int i = 0; i < order.Count - 1; ++i)
                {
                    if (!orderingRules.TryGetValue(order[i], out _) || !orderingRules[order[i]].Contains(order[i + 1]))
                    {
                        (order[i + 1], order[i]) = (order[i], order[i + 1]);
                        wrong = true;
                    }
                }
            }

            middle += int.Parse(order[order.Count / 2]);
        }

        return middle;

        bool isCorrect(List<string> pageOrder) =>
            Enumerable.Range(0, pageOrder.Count - 1)
                .All(i => orderingRules.TryGetValue(pageOrder[i], out _) &&
                    orderingRules[pageOrder[i]].Contains(pageOrder[i + 1]));
    }

    private static (Dictionary<string, List<string>> orderingRules, List<List<string>> pageOrders) Parse(string[] input)
    {
        Dictionary<string, List<string>> orderingRules = [];
        List<List<string>> pageOrders = [];

        foreach (var entry in input)
        {
            var items = entry?.Split('|');
            if (items != null && items.Length == 2)
            {
                if (orderingRules.TryGetValue(items[0], out var orderList))
                {
                    orderingRules[items[0]].Add(items[1]);

                    continue;
                }

                orderingRules.Add(items[0], [items[1]]);

                continue;
            }

            var updates = entry?.Split(',');
            if (updates != null && updates.Length > 1)
            {
                pageOrders.Add([.. updates]);
            }
        }

        return (orderingRules, pageOrders);
    }
}