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
        // название волшебной переменной не дает понятия зачем она нужна. Это ascii-код символа '0', стоило использовать его напрямую.
        int answer = 0;
        DelMinus(ref input);
        foreach (var ch in input)
            // использовать var в foreach и for неуместно. Его стоит использовать только если тип упоминяется где-то еще рядом (хотя лучше вообще избегать)
        {
            answer += ch - extraNumbers;
            // если бы использовался символ '0' то было бы понятнее 
            // answer += ch - '0';
        }
        return answer;
    }
    
    public static void DelMinus(ref string input)
        // названия нельзя так сокращать, можно было назвать напрямую DeleteMinus
        // + нет смысла передавать строку по ref, лучше принимать строку и возвращать строку
        // + в этом методе не очень много смысла, можно было сделать проще через .Replace
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
        // название не дает понятия как метод работает. Можно было назвать:
        // + CheckAllCharsValid
        // + AllCharsValid (для булевских методов допустимо опустить глагол)
        
        // кстати метод посчитает адекватной строку "--"
    {
        var listCorrectChars = new List<char>() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '-' };
        var stringList = input.ToList();
        return stringList.TrueForAll(ch => listCorrectChars.Contains(ch)); 
        // вам не стоит использовать LINQ и лямбда-выражения пока в не разберетесь что это такое. Лучше было сделать цикл.
    }
}
