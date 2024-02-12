using Xunit;


namespace GenericsHomework.Tests
{
    public class NodeTests
    {
        [Fact]
        public void Node_NewNode_HasValue()
        {
            // Arrange
            int val = 117;

            // Act
            Node<int> testNode = new(val);

            // Assert

            Assert.Equal(val, testNode._value);
        }
        [Fact]
        public void ToString_HasValue_ReturnsString()
        {
            // Arrange
            int val =  42;

            // Act
            Node<int> testNode = new(val);

            // Assert
            Assert.Equal(val.ToString(), testNode.ToString());
        }

        [Fact]
        public void Append_AppendNode_IsOriginalNodeNext()
        {
            // Arrange
            int val = 42;
            int val2 = 117;
            Node<int> originalNode = new(val);

            // Act
            originalNode.Append(val2);

            // Assert
            Assert.Equal(val2, originalNode._next._value);
        }

        [Fact]
        public void ToString_GivenNode_ReturnsCorrectString()
        {
            // Arrange
            int val = 117;
            Node<int> testNode = new(val);

            // Act
            string valString = val.ToString();
            var toStringOutput = testNode.ToString();

            // Assert
            Assert.Equal(valString, toStringOutput);
        }
    }
}