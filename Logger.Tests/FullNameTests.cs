using Logger.Tests;
using Xunit;
using System;
#nullable enable

namespace Logger.Tests;

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

	[Fact]
	public void FullName_CreatesFullNameWithMiddle_NameMatches()
	{
        string testNameString = "Alpha Beta Charlie";
        FullName testName = new FullName("Alpha", "Charlie", "Beta");

		Assert.Equal(testNameString, testName.Name);
    }

    [Fact]
    public void FullName_CreatesFullNameWithOutMiddle_NameMatches()
    {
        string testNameString = "Alpha Charlie";
        FullName testName = new FullName("Alpha", "Charlie");

        Assert.Equal(testNameString, testName.Name);
    }

}
