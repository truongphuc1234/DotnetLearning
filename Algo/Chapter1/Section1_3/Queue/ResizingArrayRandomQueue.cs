namespace Algo.Chapter1.Section1_3;

public class ResizingArrayRandomQueue<T> : ResizingArrayQueue<T>
{
    public override T Dequeue()
    {
        if (IsEmpty())
        {
            throw new Exception("Queue is empty");
        }
        var randomIndex = new Random().Next(size) + first;
        if (randomIndex >= arr.Length)
        {
            randomIndex -= arr.Length;
        }
        (arr[first], arr[randomIndex]) = (arr[randomIndex], arr[first]);
        var item = arr[first];
        arr[first] = default;
        first++;
        size--;
        if (first == arr.Length)
        {
            first = 0;
        }
        if (size == arr.Length / 4)
        {
            Resize(arr.Length / 2);
        }
        return item;
    }

    public T Sample()
    {
        if (IsEmpty())
        {
            throw new Exception("Queue is empty");
        }
        int randomIndex = GetRandomIndex();
        return arr[randomIndex];
    }

    private int GetRandomIndex()
    {
        var randomIndex = new Random().Next(size) + first;
        if (randomIndex >= arr.Length)
        {
            randomIndex -= arr.Length;
        }

        return randomIndex;
    }
}
