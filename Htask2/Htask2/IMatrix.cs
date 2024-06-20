namespace Htask2
{
    public interface IMatrix<T>
    {
        T this[int indexRowl,int indexCol] { get; set; }
        void PrintMatrix();
    }
}
