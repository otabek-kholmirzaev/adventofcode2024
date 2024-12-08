var path = "input.txt";
var grid = File.ReadAllLines(path);
int m = grid.Length;
int n = grid[0].Length;

var visited = new bool[m, n];

void PartOne()
{
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            for (int y = j + 1; y < n; y++)
            {
                if (grid[i][j] != '.' && grid[i][j] == grid[i][y])
                {
                    CreateAntinode(i, j, i, y);
                }
            }

            for (int x = i + 1; x < m; x++)
            {
                for (int y = 0; y < n; y++)
                {
                    if (grid[i][j] != '.' && grid[i][j] == grid[x][y])
                    {
                        CreateAntinode(i, j, x, y);
                    }
                }
            }
        }
    }

    int count = 0;
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            if (visited[i, j])
            {
                count++;
            }
        }
    }

    Console.WriteLine(count);
}

void PartTwo()
{
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            for (int y = j + 1; y < n; y++)
            {
                if (grid[i][j] != '.' && grid[i][j] == grid[i][y])
                {
                    CreateAntinode(i, j, i, y);
                }
            }

            for (int x = i + 1; x < m; x++)
            {
                for (int y = 0; y < n; y++)
                {
                    if (grid[i][j] != '.' && grid[i][j] == grid[x][y])
                    {
                        CreateAntinodePart2(i, j, x, y);
                    }
                }
            }
        }
    }

    int count = 0;
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            if (visited[i, j] || grid[i][j] != '.')
            {
                count++;
            }
        }
    }

    Console.WriteLine(count);
}

bool IsValid(int x, int y) => x >= 0 && x < m && y >= 0 && y < n;

void CreateAntinode(int i, int j, int x, int y)
{
    int ni, nj, nx, ny;
    if (i < x)
    {
        ni = i - (x - i);
        nj = j - (y - j);

        nx = x + (x - i);
        ny = y + (y - j);
    }
    else
    {
        ni = i + (x - i);
        nj = j - (y - j);

        nx = x - (x - i);
        ny = y + (y - j);
    }

    if (IsValid(ni, nj)) visited[ni, nj] = true;
    if (IsValid(nx, ny)) visited[nx, ny] = true;
}

void CreateAntinodePart2(int i, int j, int x, int y)
{
    int ni, nj, nx, ny;
    if (i < x)
    {
        ni = i - (x - i);
        nj = j - (y - j);

        while (IsValid(ni, nj))
        {
            visited[ni, nj] = true;
            ni = ni - (x - i);
            nj = nj - (y - j);
        }
        
        nx = x + (x - i);
        ny = y + (y - j);

        while (IsValid(nx, ny))
        {
            visited[nx, ny] = true;
            nx = nx + (x - i);
            ny = ny + (y - j);
        }
    }
    else
    {
        ni = i + (x - i);
        nj = j - (y - j);

        while (IsValid(ni, nj))
        {
            visited[ni, nj] = true;
            ni = ni + (x - i);
            nj = nj - (y - j);
        }

        nx = x - (x - i);
        ny = y + (y - j);

        while (IsValid(nx, ny))
        {
            visited[nx, ny] = true;
            nx = nx - (x - i);
            ny = ny + (y - j);
        }
    }
}

PartOne();
PartTwo();