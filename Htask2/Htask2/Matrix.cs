namespace Htask2
{
    internal class Matrix<T> : IMatrix<T>
    {
        private T[,] _matrix;

        public Matrix(int lengthRow, int lengthCol)
        {
            _matrix = new T[lengthRow, lengthCol];
        }

        public T this[int indexRowl, int indexCol] 
        { 
            get => _matrix[indexRowl, indexCol];
            set => _matrix[indexRowl, indexCol] = value; 
        }

        public void PrintMatrix()
        {
            for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                for (int j = 0; j < _matrix.GetLength(1); j++)
                {
                    Console.Write(_matrix[i,j]+ "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
