namespace HTask5
{
    internal class Calculator : ICalculate
    {
        public event EventHandler<EventArgs> PrintResult;

        private Stack<double> _result = new Stack<double>();

        private Stack<CalculatorActionLog> _stackAction = new Stack<CalculatorActionLog>();

        public double resultValue = 0;

        public void Divide(double value)
        {
            if (value == 0)
            {
                _stackAction.Push(new CalculatorActionLog(CalcAction.Divide, value));
                throw new CalculatorDivideZeroException("It cannot be divided by 0", _stackAction);
            }
            else
            {
                AddValueToStack(resultValue);
                resultValue = resultValue / value;
                RaiseEvent();
            }
        }

        public void Multiply(double value)
        {
            
            if (Double.IsPositiveInfinity(resultValue * value))
            {
                _stackAction.Push(new CalculatorActionLog(CalcAction.Multiply, value));
                throw new CalculateOperationCauseOverflowException("Over max value", _stackAction);
            }
            else
            {
                AddValueToStack(resultValue);
                resultValue = resultValue * value;
                RaiseEvent();
            }
        }
        public void Substract(double value)
        {
            
            if (Double.IsNegativeInfinity(resultValue - value))
            {
                _stackAction.Push(new CalculatorActionLog(CalcAction.Substract, value));
                throw new CalculateOperationCauseOverflowException("Over min value", _stackAction);
            }
            else
            {
                AddValueToStack(resultValue);
                resultValue = resultValue - value;
                RaiseEvent();
            }
        }

        public void Sum(double value)
        {
            if (Double.IsPositiveInfinity(resultValue + value))
            {
                _stackAction.Push(new CalculatorActionLog(CalcAction.Sum, value));
                throw new CalculateOperationCauseOverflowException("Over max value", _stackAction);
            }
            else
            {
                AddValueToStack(resultValue);
                resultValue = resultValue + value;
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

        private void AddValueToStack(double value)
        {
            _result.Push(value);
        }
    }
}
