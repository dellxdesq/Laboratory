class Program
{
    public static void Main()
    {
        Second();
    }
    public static void Second()
    {
        string input = "";
        while (true)
        {
            input = Console.ReadLine();
            if (!CheckInput(input))
            {
                Console.WriteLine("Invalid input - input must be integer number.");
                Console.ReadKey();
                break;
            }
            Console.WriteLine(FindSumOfDigitsInNumber(input));
        }
    }

    public static int FindSumOfDigitsInNumber(string input)
    {
        int extraNumbers = 48;
        int answer = 0;
        DeleteMinus(ref input);
        foreach (var ch in input)
        {
            answer += ch - extraNumbers;
        }
        return answer;
    }
    
    public static void DeleteMinus(ref string input)
    {
        if (input.Contains("-"))
        {
            int index = input.IndexOf('-');
            input = input.Remove(index, 1);
        }
    }

    public static bool CheckInput(string input)
    {
        return input.Length > 0 && CheckForWrongChars(input);
    }

    
    public static bool CheckForWrongChars(string input)
    {
        var listChars = new List<char>() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '-' }; //допустимые элементы
        var stringList = input.ToList();
        return stringList.TrueForAll(ch => listChars.Contains(ch)); 
    }
}
