using Logger.Tests;
using Xunit;
using System;
#nullable enable


public class FullNameTests
{
	[Fact]
	public void FullName_CreationWithAllProperties_Success()
	{
		// Arrange
		string firstName = "firstName";
		string lastName = "lastName";
		string middleName = "middleName";

		// Act
		var fullName = new FullName(firstName, lastName, middleName);

		// Assert
		Assert.Equal(firstName, fullName.FirstName);
		Assert.Equal(lastName, fullName.LastName);
		Assert.Equal(middleName, fullName.MiddleName);
	}

	[Fact]
	public void FullName_CreationWithoutMiddleName_Success()
	{
		// Arrange
		string firstName = "firstName";
		string lastName = "lastName";

		// Act
		var fullName = new FullName(firstName, lastName);

		// Assert
		Assert.Equal(firstName, fullName.FirstName);
		Assert.Equal(lastName, fullName.LastName);
		Assert.Null(fullName.MiddleName);
	}

	[Fact]
	public void FullName_CreationWithNullFirstName_ThrowsException()
	{
		// Arrange
		string lastName = "lastName";
		
		// Act & Assert
		Assert.Throws<ArgumentNullException>(() => new FullName(null!, lastName));
	}

	[Fact]
	public void FullName_CreationWithNullLastName_ThrowsException()
	{
		// Arrange
		string firstName = "firstName";

		// Act & Assert
		Assert.Throws<ArgumentNullException>(() => new FullName(firstName, null!));
	}


}
