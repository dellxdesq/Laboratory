using System;
using System.IO.Compression;

class Program
{
    public static void Main()
    {
        First();
    }

    public static void First()
    {
        float comparison1 = float.NaN;
        float comparison2 = float.NaN;
        string input = "";
        int number = 0;
        while (input != "q")
        {
            input = Console.ReadLine();

            if (int.TryParse(input, out number))
            {
                Console.WriteLine((char)number);
            }
            else if (float.TryParse(input, out comparison2))
            {
                if (ComparisonFloats(comparison1, comparison2, (float)0.1))
                    break;
                comparison1 = comparison2;
            }
        }
    }

    public static bool ComparisonFloats(float f1, float f2, float eps)
    {
        return Math.Abs(f1 - f2) <= eps;
    }
}
