using System;
using System.Globalization;

class Program
{
  

    public static void Main()
    {
        Console.WriteLine("Введите массив ебаный свет!");
        while (true)
        {
            string inputArrStr = Console.ReadLine() ?? string.Empty;
            var inputArr = new List<string>(inputArrStr.Split(' '));
            var outputArr = OperateInputArray(inputArr);
            outputArr.ForEach(Console.WriteLine);
        }
    }


    public static List<string> OperateInputArray(List<string> inputArr)
    {
        var outputArr = new List<string>();
        foreach (var num in inputArr)
        {
            if (IsInt(num) && !IsNegative(num))
            {
                long res = Fact(long.Parse(num));
                outputArr.Add(res.ToString());
            }
            else if (IsFloat(num))
            {
                string res = RoundAndCut(num, 2);
                outputArr.Add(res);
            }
            else
            {
                outputArr.Add(num);
            }
        }
        return outputArr;
    }
    public static bool IsInt(string input)
    {
        return int.TryParse(input, out var number);
    }

    public static bool IsFloat(string input)
    {
        return float.TryParse(input, out var number);
    }

    public static bool IsNegative(string number)
    {
        bool answer = number[0] == '-';
        return answer;
    }
    public static string RoundAndCut(string number, int midPointCut)
    {
        number = Cut(Round(number, midPointCut));
        return number;
    }

    public static string Cut(string number)
    {
        string cutNumber;

        number = DeleteZero(number);
        int pointIndex = number.IndexOf(',');
        cutNumber = number.Substring(pointIndex + 1, number.Length - pointIndex - 1).TrimStart('0');
        if (string.IsNullOrEmpty(cutNumber))
            cutNumber = "0";
        return cutNumber;
    }

    public static string DeleteZero(string wrongString)
    {
        return string.Join("", wrongString.Split("\0"));
    }

    public static string Round(string number, int midPointRounding)
    {
        string roundedNumber;
        int pointIndex = number.IndexOf(',');
        char[] safeNumberArr = new char[number.Length + midPointRounding];
        for (int i = 0; i < number.Length; ++i)
            safeNumberArr[i] = number[i];

        if (safeNumberArr[pointIndex + midPointRounding + 1] >= '5')
        {
            safeNumberArr[pointIndex + midPointRounding] += (char)('1' - '0');
        }
        roundedNumber = new string(safeNumberArr).Substring(0, pointIndex + midPointRounding + 1);
        return roundedNumber;
    }

    public static long Fact(long n)
    {
        if (n == 0)
            return 1;
        else
            return n * Fact(n - 1);
    }
}
