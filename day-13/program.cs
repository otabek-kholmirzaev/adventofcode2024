var path = "input.txt";
var grid = File.ReadAllLines(path);
int m = grid.Length, n = grid[0].Length;

void PartOne()
{
    long ans = 0;

    for (int i = 0; i < m; i++)
    {
        if (grid[i].Contains('A'))
        {
            var (ax, ay) = Extract(grid[i]);
            var (bx, by) = Extract(grid[i + 1]);
            var (px, py) = Extract(grid[i + 2]);

            for (int j = 0; j <= 100; j++)
            {
                for (int k = 0; k <= 100; k++)
                {
                    int total_x = j * ax + k * bx;
                    int total_y = j * ay + k * by;
                    if (total_x == px && total_y == py)
                    {
                        ans += j * 3 + k;
                        break;
                    }
                }
            }

            (int x, int y) Extract(string s)
            {
                var right = s.Split(':')[1].Trim();
                var part1 = right.Split(',')[0];
                var part2 = right.Split(',')[1].Trim();

                int x = int.Parse(part1[2..]);
                int y = int.Parse(part2[2..]);

                return (x, y);
            }
        }
    }

    Console.WriteLine(ans);
}

void PartTwo()
{
    long ans = 0;

    for (int i = 0; i < m; i++)
    {
        if (grid[i].Contains('A'))
        {
            (long x, long y) Extract(string s)
            {
                var right = s.Split(':')[1].Trim();
                var part1 = right.Split(',')[0];
                var part2 = right.Split(',')[1].Trim();

                var x = long.Parse(part1[2..]);
                var y = long.Parse(part2[2..]);

                return (x, y);
            }

            var (x1, y1) = Extract(grid[i]);
            var (x2, y2) = Extract(grid[i + 1]);
            var (x, y) = Extract(grid[i + 2]);
            
            x += 10000000000000;
            y += 10000000000000;

            long p = (y2 * x - x2 * y) / (x1 * y2 - x2 * y1);
            long q = (x1 * y - x * y1) / (x1 * y2 - x2 * y1);

            if (p*x1 + q*x2 == x && p*y1 + q*y2 == y)
            {
                ans += p * 3 + q;
            }
        }
    }

    Console.WriteLine(ans);
}

PartOne();
PartTwo();