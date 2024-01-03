namespace Algo.Chapter1.Section1_3;

public interface IDeque<T> : ICollectable<T>
{
    public void PushLeft(T item);
    public void PushRight(T item);
    public T PopRight();
    public T PopLeft();
}
