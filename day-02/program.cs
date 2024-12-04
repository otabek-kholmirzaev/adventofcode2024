var path = "input.txt";
var grid = File.ReadAllLines(path);

void PartOne()
{
    int count = 0;
    foreach (var line in grid)
    {
        var nums = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
        if (Check(nums)) count++;
    }

    Console.WriteLine(count);
}

void PartTwo()
{
    int count = 0;
    foreach (var line in grid)
    {
        var nums = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
        if (Check(nums.ToList()))
        {
            count++;
            continue;
        }

        for (int i = 0; i < nums.Count; i++)
        {
            int temp = nums[i];
            nums.RemoveAt(i);

            if (Check(nums))
            {
                count++;
                break;
            }
            else
            {
                nums.Insert(i, temp);
            }
        }
    }

    Console.WriteLine(count);
}

bool Check(List<int> nums)
{
    bool increasing = true, decreasing = true, ok = true;
    for (int i = 0; i < nums.Count - 1; i++)
    {
        if (nums[i] > nums[i + 1]) increasing = false;
        if (nums[i] < nums[i + 1]) decreasing = false;

        int diff = Math.Abs(nums[i] - nums[i + 1]);
        if (diff < 1 || diff > 3) ok = false;
    }

    return (increasing || decreasing) && ok;
}

//PartOne();
//PartTwo();