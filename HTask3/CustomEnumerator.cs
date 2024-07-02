using System.Collections;

namespace HTask3
{
    internal class CustomEnumerator : IEnumerator<int>
    {
        public int Current { get; private set; } = - 1;

        object IEnumerator.Current => 0;

        public void Dispose(){}

        public bool MoveNext()
        {
            if (Current < 10)
            {
                Current++;
                return true;
            }
            Reset();
            return false;
        }

        public void Reset()
        {
            Current = -1;
        }
    }
}
