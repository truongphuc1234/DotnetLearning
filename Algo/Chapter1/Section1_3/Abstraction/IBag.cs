namespace Algo.Chapter1.Section1_3;

public interface IBag<T> : ICollectable<T>
{
    public void Add(T item);
}
