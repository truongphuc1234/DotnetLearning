using System.Collections;

namespace Algo.Chapter1.Section1_3;

public class RandomBag<T> : IBag<T>
{
    private T[] arr = new T[1];
    private int size;

    public void Add(T item)
    {
        if (size == arr.Length)
        {
            Resize(2 * arr.Length);
        }
        arr[size] = item;
        size++;
    }

    public bool IsEmpty() => size == 0;

    public int Size() => size;

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerator<T> GetEnumerator()
    {
        var suffledArray = Shuffle(size);
        for (int i = 0; i < this.size; i++)
        {
            yield return arr[suffledArray[i]];
        }
    }

    private void Resize(int max)
    {
        T[] temp = new T[max];
        for (int i = 0; i < this.size; i++)
        {
            temp[i] = arr[i];
        }
        arr = temp;
    }

    private int[] Shuffle(int n)
    {
        var rand = new Random();
        var tempArr = new int[n];
        for (int i = 0; i < n; i++)
        {
            tempArr[i] = i;
        }
        for (int i = 0; i < n; i++)
        {
            var randIndex = rand.Next(n);
            (tempArr[i], tempArr[randIndex]) = (tempArr[randIndex], tempArr[i]);
        }

        return tempArr;
    }
}
