using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment;
public class Node<T> : IEnumerable<T>
{
    public T Value { get; set; }
    public Node<T> Next { get; private set; }

    public Node(T value)
    {
        Value = value;
        Next = this;
    }

    public override string ToString()
    {
        string contents = $"{Value}";
        return contents;
    }

    public void Append(T value)
    {
        if (Exists(value))
        {
            throw new System.ArgumentException("Duplicate Value");
        }


        Node<T> newNode = new(value);
        Node<T> currentNode = this;

        while (currentNode.Next != this)
        {
            currentNode = currentNode.Next;
        }

        currentNode.Next = newNode;
        newNode.Next = this;
    }

    public void Clear()
    {
        if (this.Next == this)
        {
            return;
        }

        Node<T> currentNode = this;

        while (currentNode.Next != this)
        {
            currentNode = currentNode.Next;
        }

        currentNode.Next = this.Next;
        this.Next = this;
    }

    public bool Exists(T value)
    {
        Node<T> currentNode = this;

        if (currentNode.Value!.Equals(value))
        {
            return true;
        }

        currentNode = currentNode.Next;

        while (currentNode != this)
        {
            if (currentNode.Value!.Equals(value))
            {
                return true;
            }
            currentNode = currentNode.Next;
        }

        return false;

    }

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw GetEnumerator();
    }

    public IEnumerable<T> ChildItems(int maximumL)
    {

    }
}
