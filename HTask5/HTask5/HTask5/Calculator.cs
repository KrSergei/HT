
namespace HTask5
{
    internal class Calculator : ICalculate
    {
        public event EventHandler<EventArgs> PrintResult;

        private Stack<int> _result = new Stack<int>();

        private Stack<CalculatorActionLog> _stackAction = new Stack<CalculatorActionLog>();

        public int resultValue = 0;

        public void ChoiceAction(int value, char whatDoing)
        {

            switch (whatDoing)
            {
                case '+':
                    Sum(value);
                    break;
                case '-':
                    Substract(value);
                    break;
                case '*':
                    Multiply(value);
                    break;
                case '/':
                    Divide(value);
                    break;
                default:
                    break;
            }
        }

        public void Divide(int value)
        {
            if (value == 0)
            {
                _stackAction.Push(new CalculatorActionLog(CalcAction.Divide, value));
                throw new CalculatorDivideZeroException("It cannot be divided by 0", _stackAction);
            }
            AddValueToStack(resultValue);
            resultValue = resultValue / value;
            RaiseEvent();

        }

        public void Multiply(int value)
        {                       
            long v = value * resultValue;
            if(v >= int.MaxValue)
            {
                _stackAction.Push(new CalculatorActionLog(CalcAction.Multiply, value));
                throw new CalculateOperationCauseOverflowException("Over max value", _stackAction);
            }
            AddValueToStack(resultValue);
            resultValue = (int)v;
            RaiseEvent();

        }

        public void Substract(int value)
        {            
            long v = resultValue - value;
            if (v <= int.MinValue)
            {
                _stackAction.Push(new CalculatorActionLog(CalcAction.Substract, value));
                throw new CalculateOperationCauseOverflowException("Over max value", _stackAction);
            }
         
            AddValueToStack(resultValue);
            resultValue = (int)v;
            RaiseEvent();

        }

        public void Sum(int value)
        {            
            long v = resultValue + value;
            Console.WriteLine(resultValue);
            Console.WriteLine("long v : resultValue + value = " + v);
            if (v >= int.MaxValue)  
            {
                Console.WriteLine("Over int.MaxValue = " + v);
                _stackAction.Push(new CalculatorActionLog(CalcAction.Sum, value));
                throw new CalculateOperationCauseOverflowException("Over max value", _stackAction);
            }
            else
            {
                AddValueToStack(resultValue);
                resultValue = (int)v;
                RaiseEvent();
            }
        }

        private void RaiseEvent()
        {
            PrintResult?.Invoke(this, EventArgs.Empty);
        }

        public void CancelLast()
        {
            if (_result.Count > 0) { 
                resultValue = _result.Pop();
            }
            else
            {
                resultValue = 0;
            }
        }

        private void AddValueToStack(int value)
        {
            _result.Push(value);
        }
    }
}
