namespace HTask5
{
    internal interface ICalculate
    {
        event EventHandler<EventArgs> PrintResult;

        void Sum(double value);
        void Substract(double value);
        void Multiply(double value);
        void Divide(double value);
        void CancelLast();
    }
}
