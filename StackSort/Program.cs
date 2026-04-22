
class StackSort
{
    public static string[] Solve(int[] A, int[] B, int[] C)
    {
        // turning array into lists, as I need to access elements by their indexes
        var stackA = A.ToList();
        var stackB = B.ToList();
        var stackC = C.ToList();

        var moves = new List<string>();

        // move all values from A to B
        while (stackA.Count > 0)
        {
            int value = stackA[stackA.Count - 1];
            stackA.RemoveAt(stackA.Count - 1);
            stackB.Add(value);

            moves.Add("A B");
        }

        while (stackB.Count > 0 || stackC.Count > 0)
        {
            int maxValue = 0;
            int maxIndex = -1;
            string maxStack = "";

            // search for the largest value in B
            for (int i = stackB.Count - 1; i >= 0; i--)
            {
                if (stackB[i] > maxValue)
                {
                    maxValue = stackB[i];
                    maxIndex = i;
                    maxStack = "B";
                }
            }

            // see if there is a larger value in C than in B
            for (int i = stackC.Count - 1; i >= 0; i--)
            {
                if (stackC[i] > maxValue)
                {
                    maxValue = stackC[i];
                    maxIndex = i;
                    maxStack = "C";
                }
            }

            // if the largest value is in B, move blocking elements into C so the maximum can be accessed from the top
            if (maxStack == "B")
            {
                for (int i = stackB.Count - 1; i > maxIndex; i--)
                {
                    int value = stackB[i]; 
                    stackB.RemoveAt(i);    
                    stackC.Add(value);                    

                    moves.Add("B C");
                }

                int max = stackB[maxIndex];
                stackB.RemoveAt(maxIndex);
                stackA.Add(max);

                moves.Add("B A");
            }

            // same as for B, but for C
            else if (maxStack == "C")
            {
                for (int i = stackC.Count - 1; i > maxIndex; i--)
                {
                    int value = stackC[i];
                    stackC.RemoveAt(i);
                    stackB.Add(value);

                    moves.Add("C B");
                }

                int max = stackC[maxIndex];
                stackC.RemoveAt(maxIndex);
                stackA.Add(max);

                moves.Add("C A");
            }
        }

        return moves.ToArray();
    }

    static void Main()
    {
        RunTest(
            "Test 1 - Simple mixed stacks",
            new List<int> { 2, 3 },
            new List<int> { 4, 5 },
            new List<int> { 6, 7 }
        );

        RunTest(
            "Test 2 - Already sorted in A",
            new List<int> { 7, 6, 5, 4, 3, 2, 1 },
            new List<int>(),
            new List<int>()
        );

        RunTest(
            "Test 3 - All values in C",
            new List<int>(),
            new List<int>(),
            new List<int> { 1, 5, 3, 7, 2 }
        );

        RunTest(
            "Test 4 - Duplicate values",
            new List<int> { 3, 3 },
            new List<int> { 2, 2 },
            new List<int> { 1, 1 }
        );

        RunTest(
            "Test 5 - Single element each",
            new List<int> { 10 },
            new List<int> { 5 },
            new List<int> { 7 }
        );

        RunTest(
            "Test 6 - Empty stacks",
            new List<int>(),
            new List<int>(),
            new List<int>()
        );
    }


    static void RunTest(
        string testName,
        List<int> initialA,
        List<int> initialB,
        List<int> initialC)
    {
        Console.WriteLine($"----- {testName} -----");

        var stacks = new Dictionary<string, List<int>>
    {
        { "A", new List<int>(initialA) },
        { "B", new List<int>(initialB) },
        { "C", new List<int>(initialC) }
    };

        Console.WriteLine("Initial state:");
        PrintStacks(stacks);

        string[] moves = Solve(
            stacks["A"].ToArray(),
            stacks["B"].ToArray(),
            stacks["C"].ToArray()
        );

        foreach (string move in moves)
        {
            string[] parts = move.Split(' ');

            string from = parts[0];
            string to = parts[1];

            int value = stacks[from][stacks[from].Count - 1]; // pop top
            stacks[from].RemoveAt(stacks[from].Count - 1);
            stacks[to].Add(value); // push to destination

            Console.WriteLine($"{from} -> {to} ({value})");
        }

        Console.WriteLine();
        Console.WriteLine("Final state:");
        PrintStacks(stacks);

        Console.WriteLine($"Total moves: {moves.Length}");
        Console.WriteLine();
    }


    static void PrintStacks(Dictionary<string, List<int>> stacks)
    {
        Console.WriteLine($"A: {string.Join(", ", stacks["A"])}");
        Console.WriteLine($"B: {string.Join(", ", stacks["B"])}");
        Console.WriteLine($"C: {string.Join(", ", stacks["C"])}");
    }
}