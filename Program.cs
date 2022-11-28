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
                Console.WriteLine("Некорректный ввод, число должно быть целочисленное!");
                Console.ReadKey();
                break;
            }
            Console.WriteLine(SumInNumber(input));
        }
    }

    public static int SumInNumber(string input)
    {
        int extraNumbers = 48;
        int answer = 0;
        DelMinus(ref input);
        foreach (var ch in input)
        {
            answer += ch - extraNumbers;
        }
        return answer;
    }
    
    public static void DelMinus(ref string input)
    {
        if (input.Contains("-"))
        {
            int index = input.IndexOf('-');
            input = input.Remove(index, 1);
        }
    }

    public static bool CheckInput(string input)
    {
        return input.Length > 0 && CheckInvalidChars(input);
    }
    
    public static bool CheckInvalidChars(string input)
    {
        var listCorrectChars = new List<char>() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '-' };
        var stringList = input.ToList();
        return stringList.TrueForAll(ch => listCorrectChars.Contains(ch)); 
    }
}
