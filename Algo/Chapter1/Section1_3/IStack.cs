namespace Algo.Chapter1.Section1_3;

public interface IStack<T> : ICollectable<T>
{
    public void Push(T item);
    public T Pop();
}
