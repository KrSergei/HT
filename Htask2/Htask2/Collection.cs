namespace Htask2
{
    internal class Collection<T> : IIndexable<T>
    {
        private T[] _arr;

        public Collection(int sizeArr)
        {
            _arr = new T[sizeArr];
        }

        
        public T this[int index] 
        { 
          get => _arr[index]; 
          set => _arr[index] = value; 
        }
    }
}
