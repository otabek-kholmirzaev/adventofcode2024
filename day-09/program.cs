var path = "input.txt";
var input = File.ReadAllText(path);

void PartOne()
{
    int id = 0;
    var list = new List<string>();
    for (int i = 0; i < input.Length; i++)
    {
        int num = input[i] - '0';
        if (i % 2 == 0)
        {
            for (int j = 0; j < num; j++)
            {
                list.Add(id.ToString());
            }

            id++;
        }
        else
        {
            for (int j = 0; j < num; j++)
            {
                list.Add(".");
            }
        }
    }

    int l = 0, r = list.Count - 1;
    while (true)
    {
        while (list[l] != ".")
        {
            l++;
        }

        while (list[r] == ".")
        {
            r--;
        }

        if (l < r)
        {
            (list[l], list[r]) = (list[r], list[l]);
        }
        else
        {
            break;
        }
    }

    long ans = 0;

    for (int i = 0; i < list.Count; i++)
    {
        if (list[i] == ".")
        {
            break;
        }

        ans += long.Parse(list[i]) * i;
    }

    Console.WriteLine(ans);
}

void PartTwo()
{
    int id = 0;
    var list = new List<(string id, int count)>();
    for (int i = 0; i < input.Length; i++)
    {
        int count = input[i] - '0';
        if (i % 2 == 0)
        {
            list.Add((id.ToString(), count));
            id++;
        }
        else
        {
            list.Add((".", count));           
        }
    }

    int n = list.Count;
    for (int i = id - 1; i >= 0; i--)
    {
        var file_idx = list.FindIndex(x => x.id == i.ToString());

        var space_idx = list.FindIndex(x => x.id == "." && x.count >= list[file_idx].count);
        if (space_idx == -1 || space_idx > file_idx)
        {
            continue;
        }

        list.Insert(space_idx, list[file_idx]);
        list[space_idx + 1] = (".", list[space_idx + 1].count - list[file_idx + 1].count);
        list[file_idx + 1] = (".", list[file_idx + 1].count);
    }

    long ans = 0;
    int pos = 0;
    for (int i = 0; i < list.Count; i++)
    {
        if (list[i].id == ".")
        {
            pos += list[i].count;
            continue;
        }

        for (int j = 0; j < list[i].count; j++)
        {
            ans += long.Parse(list[i].id) * pos;
            pos++;
        }
    }

    Console.WriteLine(ans);
}

PartOne();
PartTwo();