var path = "input.txt";
var grid = File.ReadAllLines(path);

HashSet<string> pairs = new();
List<List<int>> orders = new();

foreach (var line in grid)
{
    if (line.Contains('|'))
    {
        pairs.Add(line);
    }
    else if (line.Contains(','))
    {
        orders.Add(line.Split(',').Select(int.Parse).ToList());
    }
}

void PartOne()
{
    int ans = 0;
    foreach (var order in orders)
    {
        bool ok = true;
        for (int i = 0; i < order.Count; i++)
        {
            for (int j = i + 1; j < order.Count; j++)
            {
                var hash = order[j] + "|" + order[i];
                if (pairs.Contains(hash))
                {
                    ok = false;
                }
            }
        }

        if (ok) ans += order[order.Count / 2];
    }

    Console.WriteLine(ans);
}

void PartTwo()
{
    int ans = 0;
    foreach (var order in orders)
    {
        bool ok = true;
        for (int i = 0; i < order.Count; i++)
        {
            for (int j = i + 1; j < order.Count; j++)
            {
                var hash = order[j] + "|" + order[i];
                if (pairs.Contains(hash))
                {
                    ok = false;
                }
            }
        }

        if (ok)
        {
            continue;
        }

        for (int i = 0; i < order.Count; i++)
        {
            for (int j = i + 1; j < order.Count; j++)
            {
                var hash = order[j] + "|" + order[i];
                if (pairs.Contains(hash))
                {
                    int temp = order[i];
                    order[i] = order[j];
                    order[j] = temp;
                }
            }
        }


        ans += order[order.Count / 2];
    }

    Console.WriteLine(ans);
}

PartOne();
PartTwo();