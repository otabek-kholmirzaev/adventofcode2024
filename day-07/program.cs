//https://adventofcode.com/2024/day/7

var path = "input.txt";
var grid = File.ReadAllLines(path);

Dictionary<string, Func<string, string, string>> operators_map = new()
{
    { "+", (a, b) => (long.Parse(a) + long.Parse(b)).ToString() },
    { "*", (a, b) => (long.Parse(a) * long.Parse(b)).ToString() },
    { "||", (a, b) => a + b }
};

long SolvePuzzle(List<string> operators)
{
    long totalSum = 0;
    
    foreach (var line in grid)
    {
        var parts = line.Split(':');
        long targetResult = long.Parse(parts[0]);
        string[] numbers = parts[1].Trim().Split();
        
        if (HasValidExpression(numbers, operators, targetResult))
        {
            totalSum += targetResult;
        }
    }
    
    return totalSum;
}

bool HasValidExpression(string[] numbers, List<string> operators, long targetResult)
{
    List<List<string>> expressions = [[numbers[0]]];
    
    for (int i = 1; i < numbers.Length; i++)
    {
        expressions = expressions
            .SelectMany(exp => operators
                .Select(op => [.. exp, op, numbers[i]]))
            .ToList();
    }

    return expressions.Any(exp => EvaluateExpression(exp) == targetResult);
}

long EvaluateExpression(List<string> expression)
{
    var stack = new Stack<string>();
    
    foreach (var token in expression)
    {
        if (stack.Count > 0 && operators_map.ContainsKey(stack.Peek()))
        {
            var operand = token;
            var operation = stack.Pop();
            var previousOperand = stack.Pop();
            
            stack.Push(operators_map[operation](operand, previousOperand));
        }
        else
        {
            stack.Push(token);
        }
    }
    
    return long.Parse(stack.Pop());
}

void SolvePartOne()
{
    var result = SolvePuzzle(["+", "*"]);
    Console.WriteLine(result);
}

void SolvePartTwo()
{
    var result = SolvePuzzle(["+", "*", "||"]);
    Console.WriteLine(result);
}

SolvePartOne();
SolvePartTwo();