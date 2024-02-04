namespace Logger;

public record class Person(FullName fullName) : BaseEntity
{
    public override string Name { get => fullName.Name; }
    
}
