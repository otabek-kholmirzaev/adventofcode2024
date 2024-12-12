var path = "input.txt";
var grid = File.ReadAllLines(path);
int m = grid.Length, n = grid[0].Length;
int[][] dirs = [[1, 0], [0, 1], [-1, 0], [0, -1]];

bool IsValid(int x, int y) => x >= 0 && x < m && y >= 0 && y < n;

void Dfs(int x, int y, HashSet<(int, int)> set, HashSet<(int , int)> visited)
{
    foreach (var dir in dirs)
    {
        int nx = x + dir[0], ny = y + dir[1];
        if (IsValid(nx, ny) && set.Contains((nx, ny)) == false && grid[nx][ny] == grid[x][y])
        {
            set.Add((nx, ny));
            visited.Add((nx, ny)); 
            Dfs(nx, ny, set, visited);
        }
    }
}

void PartOne()
{
    long ans = 0;
    var visited = new HashSet<(int, int)>();
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            if (visited.Contains((i, j)) == false)
            {
                var set = new HashSet<(int, int)>
                {
                    (i, j)
                };
                visited.Add((i, j));
                Dfs(i, j, set, visited);

                int area = set.Count;
                int perimeter = 0;
                foreach (var (x, y) in set)
                {
                    foreach (var dir in dirs)
                    {
                        int nx = x + dir[0], ny = y + dir[1];
                        if (IsValid(nx, ny) == false || grid[x][y] != grid[nx][ny])
                        {
                            perimeter++;
                        }
                    }
                }

                ans += area * perimeter;
            }
        }

    }

    Console.WriteLine(ans);
}

void PartTwo()
{
    long ans = 0;
    var visited = new HashSet<(int, int)>();
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            if (visited.Contains((i, j)) == false)
            {
                var set = new HashSet<(int, int)>{ (i, j) };
                visited.Add((i, j));
                Dfs(i, j, set, visited);

                Dictionary<int, HashSet<int>> left = new();
                Dictionary<int, HashSet<int>> right = new();
                Dictionary<int, HashSet<int>> up = new();
                Dictionary<int, HashSet<int>> bottom = new();

                foreach (var (x, y) in set)
                {
                    if (Check(x, y, x, y - 1))
                    {
                        AddItem(y, x, left);
                    }

                    if (Check(x, y, x, y + 1))
                    {
                        AddItem(y + 1, x, right);
                    }

                    if (Check(x, y, x - 1, y))
                    {
                        AddItem(x, y, up);
                    }

                    if (Check(x, y, x + 1, y))
                    {
                        AddItem(x + 1, y, bottom);
                    }
                }

                bool Check(int x, int y, int nx, int ny)
                {
                    return IsValid(nx, ny) == false || grid[x][y] != grid[nx][ny];
                }

                void AddItem(int key, int value, Dictionary<int, HashSet<int>> dict)
                {
                    if (dict.ContainsKey(key)) dict[key].Add(value); else dict[key] = new HashSet<int> { value };
                }

                int Calc(Dictionary<int, HashSet<int>> dict)
                {
                    int cnt = 0;
                    foreach (var item in dict)
                    {
                        var list = item.Value.ToList();
                        list.Add(int.MaxValue);
                        list.Sort();
                        for (int l = 1; l < list.Count; l++)
                        {
                            if (list[l] - list[l - 1] > 1)
                            {
                                cnt++;
                            }
                        }
                    }

                    return cnt;
                }


                int area = set.Count;
                int sides = 0;

                foreach (var item in new[] {left, right, up, bottom})
                {
                    sides += Calc(item);
                }

                ans += area * sides;
            }
        }

    }

    Console.WriteLine(ans);
}

PartOne();
PartTwo();