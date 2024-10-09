namespace HTask5
{
    internal class CalculatorException : Exception
    {
        public Stack<CalculatorActionLog> ActionLogs { get; set; }

        public CalculatorException(string? message, Stack<CalculatorActionLog> actionLogs) : base(message)
        {
            ActionLogs = actionLogs;
        }

        public CalculatorException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        public override string ToString()
        {
            return Message + " : " + string.Join("\n", ActionLogs.Select(x => $"{x.CalcAction} : {x.CalcArgument}"));
        }
    }

    internal class CalculatorDivideZeroException : CalculatorException
    {
        public CalculatorDivideZeroException(string message, Stack<CalculatorActionLog> actionLogs) : base(message, actionLogs)
        {
        }

        public CalculatorDivideZeroException(string? message, Exception e) : base(message, e)
        {
        }
    }

    internal class CalculateOperationCauseOverflowException : CalculatorException
    {
        public CalculateOperationCauseOverflowException(string? message, Stack<CalculatorActionLog> actionLogs) : base(message, actionLogs)
        {
        }

        public CalculateOperationCauseOverflowException(string? message, Exception e) : base(message, e)
        {
        }
    }

}
