using HTask5;
using System.Text;
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

    private static void PrintResult(object sendler, EventArgs eventArgs)
    {
        Console.WriteLine($"\nResult = {((Calculator)sendler).resultValue}");
    }

    private static string ReadLineOrEsc(ICalculate calculate)
    {  
        ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
        StringBuilder sb = new StringBuilder();
        int index = 0;
        Console.WriteLine("Enter value :");
        while (keyInfo.Key != ConsoleKey.Enter)
        {
            keyInfo = Console.ReadKey(true);

            if (keyInfo.Key == ConsoleKey.Escape)
            {
                return null;
            }
            //Удаление символа из строки
            if (keyInfo.Key == ConsoleKey.Backspace)
            {
                if (index > 0)
                {
                    Console.CursorLeft = index - 1;

                    sb.Remove(index - 1, 1);

                    Console.Write(" \b");

                    index--;
                }
            }
            //Возврат предыдущего значения 
            if(keyInfo.Key == ConsoleKey.Delete)
            {
                ((Calculator)calculate).CancelLast();
                string lastValue = ((Calculator)calculate).resultValue.ToString();
                index = lastValue.Length;
                sb.Append(lastValue);
                Console.Write(sb);
            } 

            if (keyInfo.KeyChar > 31 && keyInfo.KeyChar < 127)
            {
                index++;
                Console.Write(keyInfo.KeyChar);
                sb.Append(keyInfo.KeyChar);
            }
        }
        return sb.ToString();
    }

    public static char ChoiceMathAction()
    {  
        ConsoleKeyInfo action = new ConsoleKeyInfo();
        Console.WriteLine("\nEnter the mathematical action (+, - , * or /) on the numeric keypad");
        action = Console.ReadKey(true);
        if (action.Key == ConsoleKey.Escape || action.Key == ConsoleKey.Spacebar || action.Key == ConsoleKey.None) return ' ';
        switch (action.Key)
        {
            case ConsoleKey.Add:
                return '+';
            case ConsoleKey.Subtract:
                return '-';;
            case ConsoleKey.Multiply:
                return '*';  
            case ConsoleKey.Divide:
                return '/';
            default: return ' ';
        }

    }
    static void Main(string[] args)
    {
        ICalculate calculate = new Calculator();
        calculate.PrintResult += PrintResult;

        bool isExit = false;
        string? value = "";

        while (!isExit)
        {
            value = ReadLineOrEsc(calculate); 
            if (string.IsNullOrWhiteSpace(value)) isExit = true;
            else
            {    
                int num = Convert.ToInt32(value);            
                char action = ChoiceMathAction();
                if (action.Equals(' ')) isExit = true;
                else {
                    try
                    {
                        calculate.ChoiceAction(num, action); 
                    }
                    catch (CalculatorDivideZeroException e)
                    {
                        Console.WriteLine(e);
                    }
                    catch (CalculateOperationCauseOverflowException e)
                    {
                        Console.WriteLine(e);
                    }
                }               
            }
        }        
        Environment.Exit(0);

        #region
        //List<int> numbers = new List<int>() { 1,2,3,4,5,6,7,8,9,10};
        //int result = CalculateList(numbers, (x, y) => x + y, x => x % 2 == 0, Console.WriteLine);
        #endregion
    }
}
