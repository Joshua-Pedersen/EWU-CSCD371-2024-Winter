namespace Logger;

public record class Person(FullName fullName) : BaseEntity
{
    // Implicit as we are passing in the fullname to be used.
    public override string Name { get => fullName.Name; }
    
}
