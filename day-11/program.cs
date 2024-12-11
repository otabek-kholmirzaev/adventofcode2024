using System.Numerics;

var path = "input.txt";
var input = File.ReadAllText(path);

void PartOne()
{
    var arr = input.Split().ToArray();
    long ans = 0;
    foreach (var num in arr)
    {
        ans += Go(num.ToString(), 25);
    }

    Console.WriteLine(ans);

    int Go(string num, int times)
    {
        Queue<string> queue = new();
        queue.Enqueue(num);
        for (int i = 1; i <= times; i++)
        {
            int count = queue.Count;
            for (int j = 0; j < count; j++)
            {
                var cur = queue.Dequeue();
                if (cur == "0")
                {
                    queue.Enqueue("1");
                }
                else if(cur.ToString().Length % 2 == 0)
                {
                    queue.Enqueue(BigInteger.Parse(cur[0..(cur.Length / 2)]).ToString());
                    queue.Enqueue(BigInteger.Parse(cur[(cur.Length / 2)..]).ToString());
                }
                else
                {
                    BigInteger result = BigInteger.Parse(cur) * 2024;
                    queue.Enqueue(result.ToString());
                }
            }
        }

        return queue.Count;
    }
}

void PartTwo()
{
    var arr = input.Split().ToArray();
    long ans = 0;
    Dictionary<(string, int), long> memo = new();

    foreach (var num in arr)
    {
        ans += Go(num, 75);
    }

    Console.WriteLine(ans);

    long Go(string cur, int times)
    {
        if (memo.ContainsKey((cur, times)))
        {
            return memo[(cur, times)];
        }

        if (times == 0) 
        {
            return 1;
        }

        long result = 0;
        if (cur == "0")
        {
            result = Go("1", times - 1);
        } 
        else if (cur.Length % 2 == 0)
        {
            var left = BigInteger.Parse(cur[0..(cur.Length / 2)]).ToString();
            var right = BigInteger.Parse(cur[(cur.Length / 2)..]).ToString();
            result = Go(left, times - 1) + Go(right, times - 1);
        }
        else
        {
            result = Go((BigInteger.Parse(cur) * 2024).ToString(), times - 1);
        }

        memo[(cur, times)] = result;
        return result;
    }
}

PartOne();
PartTwo();