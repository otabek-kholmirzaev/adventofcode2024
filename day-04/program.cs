var path = "input.txt";
var grid = File.ReadAllLines(path);
int m = grid.Length;
int n = grid[0].Length;

bool Check(int i, int j) => i >= 0 && i < m && j >= 0 && j < n;

void PartOne()
{
    var dirs = new int[8][][]
    {
        [[0, 0], [-1, 0], [-2, 0], [-3, 0]],
        [[0, 0], [+1, 0], [+2, 0], [+3, 0]],
        [[0, 0], [0, -1], [0, -2], [0, -3]],
        [[0, 0], [0, +1], [0, +2], [0, +3]],
        [[0, 0], [-1, -1], [-2, -2], [-3, -3]],
        [[0, 0], [+1, +1], [+2, +2], [+3, +3]],
        [[0, 0], [-1, +1], [-2, +2], [-3, +3]],
        [[0, 0], [+1, -1], [+2, -2], [+3, -3]],
    };

    string search_word = "XMAS";
    int count = 0;
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            foreach (var dir in dirs)
            {
                bool found = true;
                for (int k = 0; k < 4; k++)
                {
                    int x = i + dir[k][0], y = j + dir[k][1];
                    if (!Check(x, y) || grid[x][y] != search_word[k]) found = false; 
                }

                if (found) count++;
            }
        }
    }

    Console.WriteLine(count);
}

void PartTwo()
{
    int count = 0;
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            if (Check(i-1, j-1) && Check(i+1, j+1) && Check(i-1, j+1) && Check(i+1, j-1))
            {
                string s1 = "" + grid[i-1][j-1] + grid[i][j] + grid[i+1][j+1];
                string s2 = "" + grid[i-1][j+1] + grid[i][j] + grid[i+1][j-1];
                if ((s1 == "MAS" || s1 == "SAM") && (s2 == "MAS" || s2 == "SAM")) count++;
            }
        }
    }

    Console.WriteLine(count);
}

//PartOne();
//PartTwo();