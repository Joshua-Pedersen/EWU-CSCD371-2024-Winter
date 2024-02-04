using Xunit;

namespace Logger.Tests;

public class EntitiesTests
{

    [Fact]
    public void Student_GivenName_NameMatches()
    {
        // Arrange
        string testNameString = "Alpha Beta Charlie";
        FullName testName = new FullName("Alpha", "Charlie", "Beta");

        // Act
        Student student = new(testName);

        // Assert
        Assert.Equal(testNameString, student.Name);

    }

    [Fact]
    public void Employee_GivenName_NameMatches()
    {
        // Arrange
        string testNameString = "Alpha Beta Charlie";
        FullName testName = new FullName("Alpha", "Charlie", "Beta");

        // Act
        Employee employee = new(testName);

        // Assert
        Assert.Equal(testNameString, employee.Name);

    }

    [Fact]
    public void Book_GivenTitle_NameMatches()
    {
        // Arrange
        string testNameString = "Alpha Charlie";

        // Act
        Book book = new(testNameString);

        // Assert
        Assert.Equal(testNameString, book.Name);
    }
}
