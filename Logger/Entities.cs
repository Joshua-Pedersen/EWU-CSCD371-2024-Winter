namespace Logger;

public record class Book(string title) : BaseEntity
{
    public override string Name { get; } = title;
}
public record class Student : Person
{
    public Student(FullName name) : base(name) { }
}
public record class Employee : Person
{
    public Employee(FullName name) : base(name) { }
}                                                                               