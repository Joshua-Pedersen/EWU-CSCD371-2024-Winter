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

            Assert.Equal<int>(val, testNode._value);
        }
        [Fact]
        public void ToString_HasValue_ReturnsString()
        {
            // Arrange
            int val =  42;

            // Act
            Node<int> testNode = new(val);

            // Assert (not generic but I'm guessing they'll remove that requirement again)
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
            Assert.Equal<int>(val2, originalNode._next._value);
        }
    }
}