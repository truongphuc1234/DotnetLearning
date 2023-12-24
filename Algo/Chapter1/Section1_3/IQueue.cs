namespace Algo.Chapter1.Section1_3;

public interface IQueue<T> : ICollectable<T>
{
    public void Enqueue(T item);
    public T Dequeue();
}
