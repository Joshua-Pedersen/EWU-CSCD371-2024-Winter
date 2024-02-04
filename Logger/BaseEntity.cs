using Logger;
using System;

public abstract class BaseEntity : IEntity
{
	public Guid Id { get; init; }

	public abstract string Name { get; set; }
}
