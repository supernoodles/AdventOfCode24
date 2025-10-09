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

        var middle = 0;

        foreach (var order in pageOrders)
        {
            bool isValid = true;

            for (int i = 0; i < order.Count - 1; ++i)
            {
                for (int j = i + 1; j < order.Count; ++j)
                {
                    if (!orderingRules.TryGetValue(order[i], out _) || !orderingRules[order[i]].Contains(order[j]))
                    {
                        isValid = false;
                        continue;
                    }
                }
            }

            middle += isValid ? int.Parse(order[order.Count / 2]) : 0;
        }

        return middle;
    }
}