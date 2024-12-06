// https://adventofcode.com/2024/day/6

var path = "C:\\Users\\otabe\\source\\repos\\AdventOfCode2024\\AdventOfCode2024\\input.txt";
var grid = File.ReadAllLines(path);
int m = grid.Length;
int n = grid[0].Length;

var dirs = new Dictionary<char, int[]>
{
    { '^', new int[] { -1, 0 } },
    { 'v', new int[] { 1, 0 } },
    { '<', new int[] { 0, -1 } },
    { '>', new int[] { 0, 1 } }
};

var map = new Dictionary<char, char>
{
    { '^', '>' },
    { '>', 'v' },
    { 'v', '<' },
    { '<', '^' }
};

(int x, int y) FindStart()
{
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            if (grid[i][j] == '^') return (i, j);
        }
    }

    throw new ArgumentException();
}

bool IsValid(int x, int y) => x >= 0 && x < m && y >= 0 && y < n;

void PartOne()
{
    var (x, y) = FindStart();
    HashSet<(int x, int y)> set = [(x, y)];
    char cur = '^';
    while (true)
    {
        int nx = x + dirs[cur][0], ny = y + dirs[cur][1];
        if (!IsValid(nx, ny)) break;
        if (grid[nx][ny] == '#')
        {
            cur = map[cur];
        }
        else
        {
            x = nx; y = ny;
            set.Add((x, y));
        }
    }

    Console.WriteLine(set.Count);
}

void PartTwo()
{
    var (sx, sy) = FindStart();
    

    char[][] arr = new char[m][];
    for (int i = 0; i < m; i++)
    {
        arr[i] = grid[i].ToCharArray();
    }

    int count = 0;
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            if (arr[i][j] == '.')
            {
                var (x, y) = (sx, sy);

                arr[i][j] = '#';

                HashSet<(int x, int y, char ch)> moves = new();
                char cur = '^';
                moves.Add((x, y, cur));

                bool isLoop = false;
                while (true)
                {
                    int nx = x + dirs[cur][0], ny = y + dirs[cur][1];
                    if (!IsValid(nx, ny))
                    {
                        isLoop = false;
                        break;
                    }

                    if (arr[nx][ny] == '#')
                    {
                        cur = map[cur];
                        
                        if (moves.Contains((x, y, cur)))
                        {
                            isLoop = true;
                            break;
                        }

                        moves.Add((x, y, cur));
                    }
                    else
                    {
                        x = nx; y = ny;

                        if (moves.Contains((x, y, cur)))
                        {
                            isLoop = true;
                            break;
                        }

                        moves.Add((x, y, cur));
                    }
                }

                if (isLoop)
                {
                    count++;
                }

                arr[i][j] = '.';
            }
        }
    }

    Console.WriteLine(count);
}

PartOne();
PartTwo();