namespace Algo.Chapter1.Section1_3;

public interface ISteque<T> : ICollectable<T>
{
    public void Enqueue(T item);
    public void Push(T item);
    public T Pop();
}
