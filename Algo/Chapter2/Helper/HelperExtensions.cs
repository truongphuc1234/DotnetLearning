namespace Algo.Chapter2.Helper;

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
        for (int i = 0; i < arr.Length -1; i++)
        {
            if (!arr[i].Less(arr[i + 1]))
            {
                return false;
            }
        }
        return true;
    }

    public static void Exchange<T>(this T[] arr, int i, int j)
    {
        (arr[i], arr[j]) = (arr[j], arr[i]);
    }

    public static void Shuffle<T>(this T[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            var randomId = new Random().Next(arr.Length);
            (arr[i], arr[randomId]) = (arr[randomId], arr[i]);
        }
    }
}
