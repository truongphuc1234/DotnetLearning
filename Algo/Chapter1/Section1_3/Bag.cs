using System.Collections;

namespace Algo.Chapter1.Section1_3;

public class Bag<T> : IBag<int>
{
    public void Add(int item)
    {
        throw new NotImplementedException();
    }

    public IEnumerator<int> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    public bool IsEmpty()
    {
        throw new NotImplementedException();
    }

    public int Size()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}
