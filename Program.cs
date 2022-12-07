using System;
using System.Globalization;

class Program
{
    public static void Main()
    {
        Console.WriteLine("Введите массив!");
        while (true)
        {
            string inputArrStr = Console.ReadLine();
            var inputArr = new List<string>(inputArrStr.Split(' '));
            // inputArr => inputArray хотя это не массив, это список
            var outputArr = CocoJambo(inputArr);
            outputArr.ForEach(Print); 
            // не используй LINQ и делегаты, это для вас пока сложно.
            // если можешь мне объяснить как это работает то без проблем.
        }
    }

    public static void Print(long number)
    {
        Console.Write(number + " ");
    }

    public static List<long> CocoJambo(List<string> inputArr)
        // я посмеялся но с этим названием вообще все не так
    {
        var outputArr = new List<long>();
        foreach (string num in inputArr)
        {
            if (IsInt(num) && !IsNegative(num))
            {
                long res = Fact(long.Parse(num));
                outputArr.Add(res);
            }

            else if (IsDouble(num) && num.IndexOf(',') > 0)
                // ты заново парсишь число, если бы ты сохранил метод double.TryParse то можно было 
                // inline-объявить переменную типа double и использовать ее
                
            {
                long res = Round(double.Parse(num));
                outputArr.Add(res);
            }

            else
            {
                outputArr.Add(long.Parse(num));
            }
        }
        return outputArr;
    }
    public static bool IsInt(string input)
        // не надо делать свои алиасы для существующих методов, это сбивает с толку
    {
        return int.TryParse(input, out var number);
    }

    public static bool IsDouble(string input)
        // не надо делать свои алиасы для существующих методов, это сбивает с толку
    {
        return double.TryParse(input, out var number);
    }

    public static bool IsNegative(string number)
        // не надо делать свои алиасы для существующих методов, это сбивает с толку
    {
        bool answer = number[0] == '-';
        // существует метод .StartsWith для строк
        return answer;
        // если ты объявляешь переменную только чтобы вернуть ее то можешь вернуть сразу ее выражение
        // return number.StartsWith('-');
    }
    
    public static long Fact(long n)
    {
        if (n == 0)
            return 1;
        else
            return n * Fact(n - 1);
        // факториал это классический пример рекурсии, однако таким образом он использует намного больше памяти
    }

    public static int Round(double number)
        // это не округление, не стоит вводить в заблуждение
        // можно было просто назвать ProcessDouble
    {
        number = Math.Abs(number);
        double val = Math.Round(number - (int)number, 2) * 100;
        return (int)val;
    }
}
