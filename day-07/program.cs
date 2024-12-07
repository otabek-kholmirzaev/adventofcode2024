//https://adventofcode.com/2024/day/7

var path = "input.txt";
var grid = File.ReadAllLines(path);

Dictionary<string, Func<string, string, string>> operators_map =new()
{
    { "+",  (a, b) => (long.Parse(a) + long.Parse(b)).ToString() },
    { "*",  (a, b) => (long.Parse(a) * lo   ng.Parse(b)).ToString() },
    { "||", (a, b) => a + b }
};

void Solve(List<string> operators)
{
    long ans = 0;
    foreach (var line in grid)
    {
        long result = long.Parse(line.Split(':')[0]);
        string[] nums = line.Split(':')[1].Trim().Split();
        
        List<List<string>> expressions = [[nums[0]]];
        for (int i = 1; i < nums.Length; i++)
        {
            var temp = new List<List<string>>();
            foreach (var exp in expressions)
            {
                foreach (var op in operators)
                {
                    temp.Add([.. exp, op, nums[i]]);
                }
            }

            expressions = temp;
        }

        if (expressions.Any(x => CalculateExpression(x) == result))
        {
            ans += result;
        }
    }

    Console.WriteLine(ans);

    long CalculateExpression(List<string> exp)
    {
        var stack = new Stack<string>();
        foreach (var item in exp)
        {
            if (stack.Count > 0 && operators_map.ContainsKey(stack.Peek()))
            {
                string a = item;
                string op = stack.Pop();
                string b = stack.Pop();

                stack.Push(operators_map[op](a, b));
            }
            else
            {
                stack.Push(item);
            }
        }

        var result = stack.Pop();

        return long.Parse(result);
    }
}

void PartOne() => Solve(["+", "*"]);

void PartTwo() => Solve(["+", "*", "||"]);

PartOne();
PartTwo();  