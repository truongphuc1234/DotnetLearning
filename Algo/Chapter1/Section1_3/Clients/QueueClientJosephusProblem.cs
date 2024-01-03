namespace Algo.Chapter1.Section1_3;

public class QueueClientJosephusProblem()
{
    public int[] Resolve(int step, int size)
    {
        var queue = new LinkedListQueue<int>();
        for (int i = 0; i < size; i++)
        {
            queue.Enqueue(i);
        }
        var order = 1;
        var result = new int[size];
        var index = 0;
        while (!queue.IsEmpty())
        {
            if (order == step)
            {
                result[index] = queue.Dequeue();
                index++;
                order = 1;
            }
            else
            {
                order++;
                queue.Enqueue(queue.Dequeue());
            }
        }
        return result;
    }
}
