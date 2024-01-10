
using Algo.Chapter2.Section2_2;

namespace Algo.Tests;

public class Chapter2_2Test
{
    [Fact]
    public void TestMergeSortTopDown_Work()
    {
        var arr = "SORTEXAMPLE".ToCharArray();
        var sorter = new MergeSorter<char>();
        sorter.Sort(arr);
        Assert.Equal("AEELMOPRSTX", string.Join("", arr));
    }

    [Fact]
    public void TestMergeSortBottomUp_Work()
    {
        var arr = "SORTEXAMPLE".ToCharArray();
        var sorter = new MergeSorterBU<char>();
        sorter.Sort(arr);
        Assert.Equal("AEELMOPRSTX", string.Join("", arr));
    }
}
