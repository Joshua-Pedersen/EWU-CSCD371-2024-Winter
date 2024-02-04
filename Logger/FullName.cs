using Logger;
using System;

public record FullName
{
	public string FirstName { get; }
	public string LastName { get; }
	public string? MiddleName { get; }


	public FullName(string firstName, string lastName, string? middleName = null)
	{
		FirstName = string.IsNullOrWhiteSpace(firstName) ? throw new ArgumentNullException(nameof(firstName)) : firstName;
		LastName = string.IsNullOrWhiteSpace(lastName) ? throw new ArgumentNullException(nameof(lastName)) : lastName;
		MiddleName = middleName;
	}
}

// I decided to define FullName as a value type because it repersents a single entity with few attributes.
// From what I know value types seem to be the better option in terms of memory usage for minimal objects. 

// As far as immutability goes I chose to make them immutable since in a real world scenario having 
// muttable names may create a vulnerability within the code. I also know from another class i've taken
// that muttable objects are not thread safe, though I don't believe that would be a problem for this
// assignment.
