namespace Logger;

public record class Book(string title) : BaseEntity
{
    // Implicit due to the fact we are passing the name/title in
    public override string Name { get; } = title;
}
public record class Student : Person
{
    // Explicit as Student's name comes from the Person class
    public Student(FullName name) : base(name) { }
}
public record class Employee : Person
{
    // Akin to Student, Explicit as Employee's name comes from the Person class
    public Employee(FullName name) : base(name) { }
}                                                                               