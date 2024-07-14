class Program
{
    static void Main()
    {
        while (true)
        {
            int X = GetValidatedInput("Enter the value of X (0-1000): ");
            int Y = GetValidatedInput("Enter the value of Y (0-1000): ");

            List<string> paths = new List<string>();

            if (X == 0 && Y == 0)
            {
                Console.WriteLine("1");
            }
            else
            {
                if (X == 0)
                {
                    paths.Add(new string('N', Y));
                }
                else if (Y == 0)
                {
                    paths.Add(new string('E', X));
                }
                else
                {
                    CountingPaths(X, Y, "", 0, 0, ' ', paths);
                }

                Console.WriteLine($"Number of valid paths: {paths.Count}");
                Console.Write("Routes for each valid path: ");
                Console.WriteLine(string.Join(",", paths));
            }

            Console.Write("Would you like one more try? (yes/no): ");
            string answer = Console.ReadLine().Trim().ToLower();

            if (answer != "yes")
            {
                break;
            }
        }
    }

    static int GetValidatedInput(string promptMessage)
    {
        Console.Write(promptMessage);
        int value = Convert.ToInt32(Console.ReadLine());

        if (value < 0 || value > 1000)
        {
            Console.WriteLine("Please enter a valid value between 0 and 1000.");
            return GetValidatedInput(promptMessage);
        }
        return value;
    }

    static void CountingPaths(int X, int Y, string path, int xNorth, int yEast, char lastMove, List<string> paths)
    {
        if (xNorth == X && yEast == Y)
        {
            paths.Add(path);
            return;
        }

        if (xNorth < X && !(lastMove == 'E' && path.EndsWith("EE")))
        {
            CountingPaths(X, Y, path + 'E', xNorth + 1, yEast, 'E', paths);
        }

        if (yEast < Y && !(lastMove == 'N' && path.EndsWith("NN")))
        {
            CountingPaths(X, Y, path + 'N', xNorth, yEast + 1, 'N', paths);
        }
    }
}
