namespace FunctionalExtension;


public static class FunctionalExtensionsMethod
{

    private static bool Any<T>(IEnumerator<T> enumerator, Func<T, T, bool> evaluator, T previousItem)
    {
        var moreItems = enumerator.MoveNext();
        return moreItems ? evaluator(previousItem, enumerator.Current) ? true : Any(enumerator, evaluator, enumerator.Current) : false;
    }
}
