namespace Algo.Chapter1.Section1_3;

public interface ICollectable<T> : IEnumerable<T>
{
    public bool IsEmpty();
    public int Size();
}
