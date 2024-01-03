namespace Algo.Chapter1.Section1_3;

public interface IGeneralizedQueue<T> : ICollectable<T>
{
    public void Insert(T item);
    public T Delete(int k);
}
