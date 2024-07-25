
namespace HTask5
{
    internal class Calculator : ICalculate
    {
        public event EventHandler<EventArgs> PrintResult;

        private Stack<int> _result = new Stack<int>();

        public int temp = 0;

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
                default: break;
            }
        }

        public void Divide(int value)
        {
            AddValueToStack(temp);
            if (value == 0) {
                temp = 0;
            } else temp = temp / value;
            RaiseEvent();
        }

        public void Multiply(int value)
        {
            AddValueToStack(temp);
            temp *= value;
            RaiseEvent();
        }

        public void Substract(int value)
        {
            AddValueToStack(temp);
            temp -= value;
            RaiseEvent();
        }

        public void Sum(int value)
        {
            AddValueToStack(temp);
            temp += value;
            RaiseEvent();
        }

        private void RaiseEvent()
        {
            PrintResult?.Invoke(this, EventArgs.Empty);
        }

        public void CancelLast()
        {
            if (_result.Count > 0) { 
                temp = _result.Pop();
            }
            else
            {
                temp = 0;
            }
        }

        private void AddValueToStack(int value)
        {
            _result.Push(value);
        }
    }
}
