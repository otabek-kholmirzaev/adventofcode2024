void PartOne()
{
    var path = "input.txt";
    var lines = File.ReadAllLines(path);

    int n = lines.Length;
    int[] left = lines.Select(x => int.Parse(x.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0])).ToArray();
    int[] right = lines.Select(x => int.Parse(x.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1])).ToArray();
    Array.Sort(left);
    Array.Sort(right);

    int ans = 0;
    for (int i = 0; i < n; i++)
    {
        ans += Math.Abs(left[i] - right[i]);
    }

    Console.WriteLine(ans);
}

void PartTwo()
{
    var path = "input.txt";
    var lines = File.ReadAllLines(path);

    int n = lines.Length;
    int[] left = lines.Select(x => int.Parse(x.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0])).ToArray();
    int[] right = lines.Select(x => int.Parse(x.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1])).ToArray();

    long ans = 0;
    for (int i = 0; i < n; i++)
    {
        ans += (long)left[i] * right.Count(x => x == left[i]);
    }

    Console.WriteLine(ans);
}

PartTwo();