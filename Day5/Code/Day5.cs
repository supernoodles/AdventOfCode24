namespace Code;

public class Day5
{
    public int Part1(string[] input)
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

        return pageOrders.Select(order => Enumerable.Range(0, order.Count - 1)
                .All(i => orderingRules.TryGetValue(order[i], out _) && orderingRules[order[i]].Contains(order[i + 1]))
                    ? int.Parse(order[order.Count / 2])
                    : 0)
                .Sum();
    }
}