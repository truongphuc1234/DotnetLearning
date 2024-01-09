using Algo.Chapter2.Section2_1;

namespace Algo.Tests;

public class Chapter2_1Test
{
    [Fact]
    public void TestSelectionSort_Work()
    {
        var arr = "SORTEXAMPLE".ToCharArray();
        var sorter = new SelectionSorter();
        sorter.Sort(arr);
        Assert.Equal("AEELMOPRSTX", string.Join("", arr));
    }

    [Fact]
    public void TestInsertionSort_Work()
    {
        var arr = "SORTEXAMPLE".ToCharArray();
        var sorter = new InsertionSorter();
        sorter.Sort(arr);
        Assert.Equal("AEELMOPRSTX", string.Join("", arr));
    }

    [Fact]
    public void TestShellSort_Work()
    {
        var arr = "SORTEXAMPLE".ToCharArray();
        var sorter = new ShellSorter();
        sorter.Sort(arr);
        Assert.Equal("AEELMOPRSTX", string.Join("", arr));
    }

    [Fact]
    public void TestShellSortV2_Work()
    {
        var arr = "SORTEXAMPLE".ToCharArray();
        var sorter = new ShellSorterV2();
        sorter.Sort(arr);
        Assert.Equal("AEELMOPRSTX", string.Join("", arr));
    }

    [Fact]
    public void Test_Ex_2_1_13_Work()
    {
        var client = new DeckSorter();
        var cards = client.PrepareCards();
        client.Sort(cards);
        Assert.True(cards.IsSorted());
    }

    [Fact]
    public void Test_Ex_2_1_14_Work()
    {
        var client = new DeckSorter();
        var cards = client.PrepareCards();
        var newCards = client.DequeueSort(cards);
        // Assert.True(newCards.IsSorted());
        Assert.Equal(1, newCards[0].Rank);
        Assert.Equal(Suit.Spade, newCards[0].Suit);
    }
}
