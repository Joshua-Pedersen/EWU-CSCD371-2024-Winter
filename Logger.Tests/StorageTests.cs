using Xunit;

namespace Logger.Tests;

public class StorageTests
{
    [Fact]
    public void Add_Student_ContainsStudent()
    {
        // Arrange
        Storage storage = new();
        Student student = new(new FullName("First", "Last"));

        // Act
        storage.Add(student);

        // Assert
        Assert.True(storage.Contains(student));
    }

    [Fact]
    public void Add_Employee_ContainsEmployee()
    {
        // Arrange
        Storage storage = new();
        Employee employee = new(new FullName("First", "Last"));

        // Act
        storage.Add(employee);

        // Assert
        Assert.True(storage.Contains(employee));
    }

    [Fact]
    public void Add_Book_ContainsBook()
    {
        // Arrange
        Storage storage = new();
        Book book = new("Foo");

        // Act
        storage.Add(book);

        // Assert
        Assert.True(storage.Contains(book));
    }

    [Fact]
    public void Remove_Student_DoesNotContainStudent()
    {
        // Arrange
        Storage storage = new();
        Student student = new(new FullName("First", "Last"));

        // Act
        storage.Add(student);
        storage.Remove(student);

        // Assert
        Assert.False(storage.Contains(student));
    }

    [Fact]
    public void Remove_Employee_DoesNotContainEmployee()
    {
        // Arrange
        Storage storage = new();
        Employee employee = new(new FullName("First", "Last"));

        // Act
        storage.Add(employee);
        storage.Remove(employee);

        // Assert
        Assert.False(storage.Contains(employee));
    }

    [Fact]
    public void Remove_Book_DoesNotContainBook()
    {
        // Arrange
        Storage storage = new();
        Book book = new("Foo");

        // Act
        storage.Add(book);
        storage.Remove(book);

        // Assert
        Assert.False(storage.Contains(book));
    }


    [Fact]
    public void Get_Student_Entity()
    {
        // Arrange
        Storage storage = new();
        Student student = new(new FullName("First", "Last"));

        // Act
        storage.Add(student);

        // Assert
        Assert.Equal(student, storage.Get(student.Id));
    }

    [Fact]
    public void Get_Employee_Entity()
    {
        // Arrange
        Storage storage = new();
        Employee employee = new(new FullName("First", "Last"));

        // Act
        storage.Add(employee);

        // Assert
        Assert.Equal(employee, storage.Get(employee.Id));
    }

    [Fact]
    public void Get_Book_Entity()
    {
        // Arrange
        Storage storage = new();
        Book book = new("Foo");

        // Act
        storage.Add(book);

        // Assert
        Assert.Equal(book, storage.Get(book.Id));
    }

    [Fact]
    public void Get_WithMultipleEntities_Entity()
    {
        // Arrange
        Storage storage = new();
        Student student1 = new(new FullName("student1", "foo"));
        Student student2 = new(new FullName("student2", "foo"));

        // Act
        storage.Add(student1);
        storage.Add(student2);

        // Assert
        Assert.Equal(student1, storage.Get(student1.Id));
        Assert.Equal(student2, storage.Get(student2.Id));
    }
}
