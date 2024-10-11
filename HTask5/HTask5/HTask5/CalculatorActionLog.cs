namespace HTask5
{
    internal class CalculatorActionLog()
    {
        public CalcAction CalcAction { get; private set; }
        public double CalcArgument { get; private set; }

        public CalculatorActionLog(CalcAction calcAction, double calcArgumentD) : this()
        {
            CalcAction = calcAction;
            CalcArgument = calcArgumentD;
        }

    }
}
