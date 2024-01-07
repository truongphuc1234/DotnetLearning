namespace Algo.Chapter2.Section2_1;

public static class HelperExtensions
{
    public static bool Less<T>(this T value1, T value2)
        where T : IComparable<T>
    {
        return value1.CompareTo(value2) < 0;
    }

    public static bool IsSorted<T>(this T[] arr)
        where T : IComparable<T>
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i].Less(arr[i + 1]))
            {
                return false;
            }
        }
        return true;
    }
}
