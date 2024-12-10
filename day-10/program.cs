var path = "input.txt";
var grid = File.ReadAllLines(path);
int m = grid.Length;
int n = grid[0].Length;

int[][] dirs = [[0, 1], [0, -1], [1, 0], [-1, 0]];

void PartOne()
{
    int ans = 0;
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++) 
        {
            if (grid[i][j] != '0') continue;
            Queue<(int x, int y)> q = new();
            q.Enqueue((i, j));
            for (int k = 1; k <= 9; k++) 
            {
                int count = q.Count;
                for (int l = 0; l < count; l++)
                {
                    var (x, y) = q.Dequeue();
                    foreach (var dir in dirs)
                    {
                        int nx = x + dir[0], ny = y + dir[1];
                        if (!IsValid(nx, ny)) continue;
                        if (grid[nx][ny] == grid[x][y] + 1)
                        {
                            q.Enqueue((nx, ny));
                        }
                    }
                }
            }

            ans += q.ToHashSet().Count;
        }
    }

    Console.WriteLine(ans);
}

void PartTwo()
{
    int ans = 0;
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            if (grid[i][j] != '0') continue;
            Queue<(int x, int y)> q = new();
            q.Enqueue((i, j));
            for (int k = 1; k <= 9; k++)
            {
                int count = q.Count;
                for (int l = 0; l < count; l++)
                {
                    var (x, y) = q.Dequeue();
                    foreach (var dir in dirs)
                    {
                        int nx = x + dir[0], ny = y + dir[1];
                        if (!IsValid(nx, ny)) continue;
                        if (grid[nx][ny] == grid[x][y] + 1)
                        {
                            q.Enqueue((nx, ny));
                        }
                    }
                }
            }

            ans += q.Count;
        }
    }

    Console.WriteLine(ans);
}



bool IsValid(int i, int j) => i >= 0 && i < m && j >= 0 && j < n;

PartOne();
PartTwo();