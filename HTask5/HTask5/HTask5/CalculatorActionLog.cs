namespace HTask5
{
    internal class CalculatorActionLog()
    {
        public CalcAction CalcAction { get; private set; }
        public int CalcArgument { get; private set; }

        public CalculatorActionLog(CalcAction calcAction, int calcArgument) : this() 
        {
            CalcAction = calcAction;
            CalcArgument = calcArgument;
        }
    }
}
