namespace Atividade11.Tests;

public class CustomSorterTests
{
    private readonly CustomSorter _sut;

    public CustomSorterTests()
    {
        _sut = new CustomSorter();
    }

    [Fact]
    public void SortDescending_ShouldReturnSortedList()
    {
        //Arrange
        var list = new List<int> { 1, 3, 2, 5, 4 };

        //Act
        var result = _sut.SortDescending(list);

        //Assert
        var sortedList = new List<int> { 5, 4, 3, 2, 1 };
        Assert.Equal(sortedList, result);
    }

    [Fact]
    public void SortDescending_EmptyList_ShouldReturnEmptyList()
    {
        //Arrange
        var list = new List<int>();

        //Act
        var result = _sut.SortDescending(list);

        //Assert
        Assert.Empty(result);
    }
}
