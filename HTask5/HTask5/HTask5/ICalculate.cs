namespace HTask5
{
    internal interface ICalculate
    {
        event EventHandler<EventArgs> PrintResult;

        void Sum(int value);
        void Substract(int value);
        void Multiply(int value);
        void Divide(int value);
        void CancelLast();
        void ChoiceAction(int value, char mathAction);
    }
}
