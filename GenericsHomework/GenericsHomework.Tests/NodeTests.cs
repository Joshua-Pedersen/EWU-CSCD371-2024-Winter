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
        public void Append_AppendMultipleNodes_ContainCorrectValues()
        {
            // Arrange
            int val = 42;
            int val2 = 117;
            int val3 = 19;
            Node<int> originalNode = new(val);

            // Act
            originalNode.Append(val2);
            originalNode.Append(val3);

            // Assert
            Assert.Equal(val, originalNode._value);
            Assert.Equal(val2, originalNode._next._value);
            Assert.Equal(val3, originalNode._next._next._value);
            Assert.Equal(val, originalNode._next._next._next._value);
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


        [Fact]
        public void Append_AppendAlreadyExistingNode_ThrowsException()
        {
            // Arrange
            Node<int> node = new(1);
            node.Append(2);
            node.Append(3);


            // Act and Assert
            Assert.Throws<ArgumentException>(() => node.Append(1));
            Assert.Throws<ArgumentException>(() => node.Append(3));
        }


        [Fact]
        public void Exists_ElementAlreadyExists_ReturnsTrue()
        {
            // Arrange
            Node<int> node = new(1);
            node.Append(2);
            node.Append(3);

            // Act 
            bool result = node.Exists(2);

            // Assert 
            Assert.True(result);
        }


        [Fact]
        public void Exists_ElementDoesntExist_ReturnFalse()
        {
            // Arrange
            Node<int> node = new(1);
            node.Append(2);
            node.Append(3);

            // Act 
            bool result = node.Exists(4);

            // Assert 
            Assert.False(result);
        }


        [Fact]
        public void Exists_SingleElementList_ReturnsTrue()
        {
            // Arrange
            Node<int> node = new(1);

            // Act 
            bool result = node.Exists(1);

            // Assert 
            Assert.True(result);
        }


        [Fact]
        public void Exists_SingleElementList_ReturnsFalse()
        {
            // Arrange
            Node<int> node = new(1);

            // Act 
            bool result = node.Exists(2);

            // Assert 
            Assert.False(result);
        }


        [Fact]
        public void Clear_RemovesAllItems_ContainsOnlyFirstValue()
        {
            // Arrange
            Node<int> node = new(1);
            node.Append(2);
            node.Append(3);

            // Act 
            node.Clear();

            // Assert 
            Assert.Equal(1, node._value);
            Assert.Same(node, node._next);
        }


        [Fact]
        public void Clear_SingleElementList_NothingRemoved()
        {
            // Arrange
            Node<int> node = new(1);

            // Act 
            node.Clear();

            // Assert 
            Assert.Equal(1, node._value);
            Assert.Same(node, node._next);
        }
    }
}