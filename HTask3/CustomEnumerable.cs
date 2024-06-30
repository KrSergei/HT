using System.Collections;

namespace HTask3
{
    internal class CustomEnumerable : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator() => new CustomEnumerator();    

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();    
    }
}
