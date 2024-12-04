var path = "input.txt";
var grid = File.ReadAllLines(path);

Dictionary<string, (int a, int b)> dict = new();
for (int a = 0; a < 1000; a++)
{
    for (int b = 0; b < 1000; b++)
    {
        string key = $"mul({a},{b})";
        dict[key] = (a, b);
    }
}

void PartOne()
{
    long ans = 0;
    foreach (var line in grid)
    {
        int n = line.Length;
        for (int i = 0; i < n; i++)
        {
            for (int l = 8; l <= 12; l++)
            {
                if (i + l > n) continue;
                string key = line[i..(i + l)];
                if (dict.ContainsKey(key)) ans += dict[key].a * dict[key].b;
            }
        }
    }

    Console.WriteLine(ans);
}

void PartTwo()
{
    long ans = 0;
    string _do = "do()", _dont = "don't()";
    bool enabled = true;
    foreach (var line in grid)
    {
        int n = line.Length;
        int i = 0;
        while (i < n)
        {
            if (i + _do.Length <= n && line[i..(i+_do.Length)] == _do)
            {
                enabled = true;
                i += _do.Length;
                continue;
            }

            if (i + _dont.Length <= n && line[i..(i + _dont.Length)] == _dont)
            {
                enabled = false;
                i += _dont.Length;
                continue;
            }

            for (int l = 8; l <= 12; l++)
            {
                if (i + l > n) continue;
                string key = line[i..(i + l)];
                if (dict.ContainsKey(key))
                {
                    if (enabled) ans += dict[key].a * dict[key].b;
                    break;
                }
            }

            i++;
        }
    }

    Console.WriteLine(ans);
}

PartOne();
PartTwo();