using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Xunit;

namespace Logger.Tests;

public class EntitiesTests
{

    [Fact]
    public void Student_GivenName_NameMatches()
    {
        // Arrange
        string testNameString = "Alpha Beta Charlie";
        FullName testName = new("Alpha", "Charlie", "Beta");

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
        FullName testName = new("Alpha", "Charlie", "Beta");

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

    [Fact]
    public void Student_MatchingProperties_AreEqual()
    {
        // Arrange
        FullName testName = new("John", "Doe");

        // Act
        Student student1 = new(testName);
        Student student2 = new(testName) { Id = student1.Id};

        // Assert
        Assert.Equal(student1, student2);
    }

    [Fact]
    public void Student_MatchingProperties_TrueEquality()
    {
        // Arrange
        FullName testName = new("John", "Doe");

        // Act
        Student student1 = new(testName);
        Student student2 = new(testName) { Id = student1.Id };

        // Assert
        Assert.True(student1.Equals(student2));
    }

    [Fact]
    public void Student_SameNameDiffId_NotEqual()
    {
        // Arrange
        FullName testName = new("John", "Doe");

        // Act
        Student student1 = new(testName);
        Student student2 = new(testName);

        // Assert
        Assert.NotEqual(student1, student2);
    }

    [Fact]
    public void Student_SameNameDiffId_FalseEquality()
    {
        // Arrange
        FullName testName = new("John", "Doe");

        // Act
        Student student1 = new(testName);
        Student student2 = new(testName);

        // Assert
        Assert.False(student1.Equals(student2));
    }

    [Fact]
    public void Employee_MatchingProperties_AreEqual()
    {
        // Arrange
        FullName testName = new("John", "Doe");

        // Act
        Employee employee1 = new(testName);
        Employee employee2 = new(testName) { Id = employee1.Id };

        // Assert
        Assert.Equal(employee1, employee2);
    }

    [Fact]
    public void Employee_MatchingProperties_TrueEquality()
    {
        // Arrange
        FullName testName = new("John", "Doe");

        // Act
        Employee employee1 = new(testName);
        Employee employee2 = new(testName) { Id = employee1.Id };

        // Assert
        Assert.True(employee1.Equals(employee2));
    }

    [Fact]
    public void Employee_SameNameDiffId_NotEqual()
    {
        // Arrange
        FullName testName = new("John", "Doe");

        // Act
        Employee employee1 = new(testName);
        Employee employee2 = new(testName);

        // Assert
        Assert.NotEqual(employee1, employee2);
    }

    [Fact]
    public void Employee_SameNameDiffId_FalseEquality()
    {
        // Arrange
        FullName testName = new("John", "Doe");

        // Act
        Employee employee1 = new(testName);
        Employee employee2 = new(testName);

        // Assert
        Assert.False(employee1.Equals(employee2));
    }

    [Fact]
    public void Book_MatchingProperties_AreEqual()
    {
        // Arrange
        string testTitle = "foo";

        // Act
        Book book1 = new(testTitle);
        Book book2 = new(testTitle) { Id = book1.Id };

        // Assert
        Assert.Equal(book1, book2);
    }

    [Fact]
    public void Book_MatchingProperties_TrueEquality()
    {
        // Arrange
        string testTitle = "foo";

        // Act
        Book book1 = new(testTitle);
        Book book2 = new(testTitle) { Id = book1.Id };

        // Assert
        Assert.True(book1.Equals(book2));
    }

    [Fact]
    public void Book_SameNameDiffId_NotEqual()
    {
        // Arrange
        string testTitle = "foo";

        // Act
        Book book1 = new(testTitle);
        Book book2 = new(testTitle);

        // Assert
        Assert.NotEqual(book1, book2);
    }

    [Fact]
    public void Book_SameNameDiffId_FalseEquality()
    {
        // Arrange
        string testTitle = "foo";

        // Act
        Book book1 = new(testTitle);
        Book book2 = new(testTitle);

        // Assert
        Assert.False(book1.Equals(book2));
    }
}
