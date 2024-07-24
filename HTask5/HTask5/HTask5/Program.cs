using HTask5;
using System.Collections.Generic;


class Programm
{
    #region
    //private static int CalculateList(List<int> list, Func<int, int, int> func, Predicate<int> pr, Action<int> res) 
    //{
    //    int sum = 0;
    //    foreach (var item in list) {
    //        if (pr(item))
    //        {
    //            sum = func(item, sum);
    //            res(sum);
    //        }
    //    }
    //    return sum;
    //}
    #endregion

    private static void Calculator_GetResult(object sendler, EventArgs eventArgs)
    {
        Console.WriteLine($"\nResult = {((Calculator)sendler).temp}");
    }

    static void Main(string[] args)
    {
        ICalculate calculate = new Calculator();
        calculate.GetResult += Calculator_GetResult;


        bool isExit = false;
        string? strValue = "";
        

        while (!isExit)
        {
            Console.WriteLine("Enter value");
            ConsoleKeyInfo ch = Console.ReadKey();

            if (ch.Key == ConsoleKey.Escape)
            {
                isExit = true;
            }
            else
            {
                if (char.IsDigit(ch.KeyChar)) strValue = ch.KeyChar.ToString();
                strValue += Console.ReadLine();
            }

            if (string.IsNullOrWhiteSpace(strValue))
            {
                isExit = true;
            }
            else
            {
                int value = Convert.ToInt32(strValue);
                ConsoleKeyInfo action;
                Console.WriteLine("\nEnter the mathematical action (+, - , * or /)");
                action = Console.ReadKey();
                if (action.Key == ConsoleKey.Escape || action.Key == ConsoleKey.Spacebar || action.KeyChar == null) isExit = true;
                switch (action.Key)
                {
                    case ConsoleKey.Add:
                        calculate.Sum(value);
                        break;
                    case ConsoleKey.Subtract:
                        calculate.Substract(value);
                        break;
                    case ConsoleKey.Multiply:
                        calculate.Multiply(value);
                        break;
                    case ConsoleKey.Divide:
                        calculate.Divide(value);
                        break;
                    default: break;
                }
            }
        }
        Environment.Exit(0);
        //calculate.Sum(11);
        //calculate.Divide(24);
        //calculate.Substract(7);
        //calculate.Multiply(12);
        //calculate.CancelLast();

        #region
        //List<int> numbers = new List<int>() { 1,2,3,4,5,6,7,8,9,10};
        //int result = CalculateList(numbers, (x, y) => x + y, x => x % 2 == 0, Console.WriteLine);
        #endregion
    }
}
